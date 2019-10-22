using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(MouseController))]
[RequireComponent(typeof(BuildingSystem))]
public class TPSPersonController : MonoBehaviour
{

    public float movementspeed = 5.0f;
    public float mouseSensitivity = 2.0f;
    public float verticalAngleLimit = 60.0f;
    public float jumpSpeed = 5f;

    float verticalRotation = 0;

    GameObject _inventory;
    GameObject _tooltip;
    GameObject _character;
    GameObject _dropBox;
    public bool showInventory = false;
    float verticalVelocity = 0;

    GameObject inventory;
    GameObject craftSystem;
    GameObject characterSystem;

    Camera firstPersonCamera;
    Animator animator;

    MouseController mouseController;
    BuildingSystem buildingSystem;

    private bool walkToggle = false;
    private bool mouseToggle = false;

    CharacterController characterController;
    // Use this for initialization
    void Start()
    {
        firstPersonCamera = Camera.main.GetComponent<Camera>();
        characterController = GetComponent<CharacterController>();
        mouseController = GetComponent<MouseController>();
        buildingSystem = GetComponent<BuildingSystem>();
        animator = GetComponent<Animator>();

        if (GameObject.FindGameObjectWithTag("Player") != null)
        { 

            PlayerInventory playerInv = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
            if (playerInv.inventory != null)
                inventory = playerInv.inventory;
            if (playerInv.craftSystem != null)
                craftSystem = playerInv.craftSystem;
            if (playerInv.characterSystem != null)
                characterSystem = playerInv.characterSystem;
        }

        buildingSystem.buildMenuPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        KeyboardInput();

        if (!lockMovement())
        {
            //Rotation
            if (mouseToggle != true)
            {
                float rotationLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
                transform.Rotate(0, rotationLeftRight, 0);
            }

            verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            verticalRotation = Mathf.Clamp(verticalRotation, -verticalAngleLimit, verticalAngleLimit);
            //firstPersonCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

            //Movement
            float forwardSpeed = Input.GetAxis("Vertical") * movementspeed;
            float sideSpeed = Input.GetAxis("Horizontal") * movementspeed;

            //walk toggle
            if (Input.GetKeyDown(KeyCode.Period))
            {

                walkToggle = !walkToggle;

            }

            if (Input.GetKey(KeyCode.LeftControl))
            {

                animator.SetBool("IsCrouching", true);
                animator.SetBool("IsIdle", false);

            }
            else {

                animator.SetBool("IsCrouching", false);
                animator.SetBool("IsIdle", true);


            }

            //animation calls
            if (Input.GetKey(KeyCode.W))
            {

                animator.SetFloat("BlendJoggingY", Input.GetAxis("Vertical"));

                if (Input.GetKey(KeyCode.LeftShift))
                {

                    movementspeed = 10.0f;
                    animator.SetBool("IsRunning", true);
                    animator.SetBool("IsJogging", false);
                    animator.SetBool("IsWalking", false);
                    animator.SetBool("IsIdle", false);

                }
                else if (animator.GetBool("IsCrouching") == true)
                {

                    animator.SetBool("IsJogging", true);

                }
                else if (walkToggle == true)
                {

                    movementspeed = 2.5f;
                    animator.SetBool("IsWalking", true);
                    animator.SetBool("IsJogging", false);
                    animator.SetBool("IsRunning", false);
                    animator.SetBool("IsIdle", false);



                }
                else
                {

                    movementspeed = 5.0f;
                    animator.SetBool("IsJogging", true);
                    animator.SetBool("IsRunning", false);
                    animator.SetBool("IsWalking", false);
                    animator.SetBool("IsIdle", false);

                }

            }
            else if (Input.GetKey(KeyCode.S))
            {

                movementspeed = 5.0f;
                animator.SetFloat("BlendJoggingY", Input.GetAxis("Vertical"));
                animator.SetBool("IsJogging", true);
                animator.SetBool("IsRunning", false);

            }
            else if (Input.GetKey(KeyCode.A))
            {

                movementspeed = 5.0f;
                animator.SetFloat("BlendJoggingX", Input.GetAxis("Horizontal"));
                animator.SetBool("IsJogging", true);
                animator.SetBool("IsRunning", false);

            }
            else if (Input.GetKey(KeyCode.D))
            {

                movementspeed = 5.0f;
                animator.SetFloat("BlendJoggingX", Input.GetAxis("Horizontal"));
                animator.SetBool("IsJogging", true);
                animator.SetBool("IsRunning", false);

            }
            else {

                animator.SetFloat("BlendJoggingX", 0);
                animator.SetFloat("BlendJoggingY", 0);

                movementspeed = 5.0f;

                animator.SetBool("IsJogging", false);
                animator.SetBool("IsRunning", false);
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsIdle", true);


            }

            verticalVelocity += Physics.gravity.y * Time.deltaTime;

            if (Input.GetButtonDown("Jump") && characterController.isGrounded)
            {
                animator.SetTrigger("Jump");
                verticalVelocity = jumpSpeed;
            }

            Vector3 speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);

            speed = transform.rotation * speed;

            characterController.Move(speed * Time.deltaTime);
        }

    }


    bool lockMovement()
    {
        if (inventory != null && inventory.activeSelf)
            return true;
        else if (characterSystem != null && characterSystem.activeSelf)
            return true;
        else if (craftSystem != null && craftSystem.activeSelf)
            return true;
        else
            return false;
    }

    void KeyboardInput() {

        if (Input.GetKeyDown(KeyCode.BackQuote))
        {

            mouseToggle = !mouseToggle;

            if (mouseToggle == true) {

                mouseController.wantedMode = CursorLockMode.None;
                mouseController.SetCursorMode();

            } else if(mouseToggle == false) {

                mouseController.wantedMode = CursorLockMode.Locked;
                mouseController.SetCursorMode();

            }

        }

        if (Input.GetKeyDown(KeyCode.B)) {

            if (buildingSystem.buildMenuPanel.activeSelf == false) {

                buildingSystem.buildMenuPanel.SetActive(true);

            }
            else {

                buildingSystem.buildMenuPanel.SetActive(false);

            }

        }


    }

}
