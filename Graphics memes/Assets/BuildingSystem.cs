
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingSystem : MonoBehaviour {

    public List<Building> buildings = new List<Building>();
    private GameObject selectedObject;
    private GameObject selectedObjGhost;
    public GameObject buildMenuPanel { get; set; }

    public GameObject player;
    private GameObject ghost;


    RaycastHit hit;

    // Use this for initialization
    void Start()
    {

        buildMenuPanel = GameObject.Find("Build Menu");
        player = GameObject.Find("Player");


        buildings.Add(new Building() {

            buildingName = "Floor",
            buildingId = 0001,
            buildingObj = Resources.Load<GameObject>("Prefabs/Floor"),
            buildingGhost = Resources.Load<GameObject>("Prefabs/Floor Ghost"),
            menuButton = GameObject.Find("Floor Button").GetComponent<Button>()

        });
        buildings.Add(new Building() {

            buildingName = "Wall",
            buildingId = 0002,
            buildingObj = Resources.Load<GameObject>("Prefabs/Wall"),
            buildingGhost = Resources.Load<GameObject>("Prefabs/Wall Ghost"),
            menuButton = GameObject.Find("Wall Button").GetComponent<Button>()

        });
        buildings.Add(new Building() {

            buildingName = "Barrier Wall",
            buildingId = 0003,
            buildingObj = Resources.Load<GameObject>("Prefabs/Barrier Wall"),
            buildingGhost = Resources.Load<GameObject>("Prefabs/Barrier Wall Ghost"),
            menuButton = GameObject.Find("Barrier Wall Button").GetComponent<Button>()

        });
        buildings.Add(new Building() {

            buildingName = "Furnace",
            buildingId = 1001,
            buildingObj = Resources.Load<GameObject>("Prefabs/Furnace"),
            buildingGhost = Resources.Load<GameObject>("Prefabs/Furnace Ghost"),
            menuButton = GameObject.Find("Furnace Button").GetComponent<Button>()

        });

        buildings[0].menuButton.onClick.AddListener(SelectFloor);
        buildings[1].menuButton.onClick.AddListener(SelectWall);
        buildings[2].menuButton.onClick.AddListener(SelectBarrier);
        buildings[3].menuButton.onClick.AddListener(SelectFurnace);

    }
	
	// Update is called once per frame
	void Update () {

        if (ghost != null) {

            Debug.Log(ghost);

            ghost.transform.rotation = player.transform.rotation;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100, 5)) {

                Debug.DrawRay(ray.origin, ray.direction, Color.red, 1000.0f);
                Debug.Log(hit.point);

                if (Input.GetMouseButtonDown(0))
                {

                    Destroy(ghost);
                    Instantiate(selectedObject, hit.point, player.transform.rotation);

                }

            }

            ghost.transform.position = hit.point;



        }

	}

    void SelectFloor() {

        selectedObject = buildings[0].buildingObj;
        selectedObjGhost = buildings[0].buildingGhost;
        Debug.Log(selectedObjGhost);
        buildMenuPanel.SetActive(false);
        ghost = Instantiate(selectedObjGhost, hit.point, player.transform.rotation);
        Debug.Log(selectedObject);

    }

    void SelectWall() {

        selectedObject = buildings[1].buildingObj;
        selectedObjGhost = buildings[1].buildingGhost;
        buildMenuPanel.SetActive(false);
        ghost = Instantiate(selectedObjGhost, hit.point, player.transform.rotation);
        Debug.Log(selectedObject);

    }

    void SelectBarrier() {

        selectedObject = buildings[2].buildingObj;
        selectedObjGhost = buildings[2].buildingGhost;
        buildMenuPanel.SetActive(false);
        ghost = Instantiate(selectedObjGhost, hit.point, player.transform.rotation);
        Debug.Log(selectedObject);

    }

    void SelectFurnace() {

        selectedObject = buildings[3].buildingObj;
        selectedObjGhost = buildings[3].buildingGhost;
        buildMenuPanel.SetActive(false);
        ghost = Instantiate(selectedObjGhost, hit.point, player.transform.rotation);
        Debug.Log(selectedObject);

    }

}

public class Building {

    public string buildingName { get; set; }

    public int buildingId { get; set; }

    public GameObject buildingObj { get; set; }

    public GameObject buildingGhost { get; set; }

    public Button menuButton { get; set; }

}
