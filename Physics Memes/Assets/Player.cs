using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject m_camera;

	// Use this for initialization
	void Start () {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;

	}
	
	// Update is called once per frame
	void Update () {

        Move();
        Rotate();
        Action();

	}

    void Move() {

        float speed = 5;

        if (Input.GetKey(KeyCode.W)) {

            transform.Translate(Vector3.forward * (speed * Time.deltaTime), Space.Self);

        }

        if (Input.GetKey(KeyCode.S))
        {

            transform.Translate(Vector3.forward * (-speed * Time.deltaTime), Space.Self);

        }

        if (Input.GetKey(KeyCode.D))
        {

            transform.Translate(Vector3.right * (speed * Time.deltaTime), Space.Self);

        }

        if (Input.GetKey(KeyCode.A))
        {

            transform.Translate(Vector3.right * (-speed * Time.deltaTime), Space.Self);

        }

    }

    void Rotate() {

        float speed = 3;
        float H = Input.GetAxis("Mouse X") * Time.deltaTime;
        float V = Input.GetAxis("Mouse Y") * Time.deltaTime;

        transform.Rotate(new Vector3(0, H, 0), speed, Space.Self);
        m_camera.transform.Rotate(new Vector3(-V, 0, 0), speed);

    }

    void Action() {

        Ray ray = m_camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {

                if (hit.transform.tag == "xbot")
                {

                    hit.transform.GetComponentInParent<Animator>().enabled = false;
                    //hit.transform.GetComponentInChildren<Rigidbody>().AddForce(Vector3.forward, ForceMode.Impulse);
                    hit.transform.GetComponent<Rigidbody>().AddForceAtPosition(ray.direction * 100, hit.point, ForceMode.Impulse);

                }

            }

        }

        if (Input.GetMouseButton(0))
        {

            if (Physics.Raycast(ray, out hit))
            {

                if (hit.transform.tag == "pickup")
                {

                    hit.transform.position = this.transform.position + ray.direction + this.transform.forward;

                }

            }

        }

    }
}
