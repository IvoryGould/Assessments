using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class Player : MonoBehaviour {

    public GameManager gameManager;
    public List<string> weaponType;

    NavMeshAgent agent;
    bool targeting;
    Character character;
    Dropdown weaponTypeDropdown;

	// Use this for initialization
	void Start () {

        agent = GetComponent<NavMeshAgent>();
        targeting = false;
        character = GetComponent<Character>();
        gameManager = GameObject.Find("CameraHolder").GetComponent<GameManager>();
        weaponTypeDropdown = gameManager.debugPanel.transform.GetChild(1).GetComponent<Dropdown>();
        weaponTypeDropdown.AddOptions(weaponType);

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0)) {

            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {

                targeting = false;

                if (hit.transform.tag == "Terrain")
                {

                    //targeting = false;
                    gameManager.debugPanel.transform.GetChild(0).GetComponent<Text>().text = "No Target";
                    agent.destination = hit.point;

                } else if (hit.transform.tag == "Enemy") {

                    targeting = true;
                    GameObject target = hit.transform.gameObject;
                    gameManager.debugPanel.transform.GetChild(0).GetComponent<Text>().text = target.name;
                    StartCoroutine(Attack(target, weaponTypeDropdown.value));

                }

            }

        }



	}

    IEnumerator Attack(GameObject target, int weaponType) {

        Debug.Log("Trageted Enemy");

        if (weaponType == 0) {

            while (targeting == true) {

                //Debug.Log("Damage" + "" + Random.Range(1, (int)character.modifierManager.getmodifierByID(3).baseValue + 1));
                gameManager.debugPanel.transform.GetChild(2).GetComponent<Text>().text = Random.Range(1, (int)character.modifierManager.getmodifierByID(3).baseValue + 1).ToString();
                yield return new WaitForSeconds(1.0f);

            }
            
        }
        else if (weaponType == 1) {



        }

        yield return null;

    }

}
