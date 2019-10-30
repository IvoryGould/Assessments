using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject characterSheet;
    //[HideInInspector]
    public GameObject debugPanel;

    private void Awake()
    {

        characterSheet = GameObject.Find("CharacterSheet");
        debugPanel = GameObject.Find("DEBUGOUTPUT");

    }

    // Use this for initialization
    void Start () {



	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Tab)) {

            characterSheet.SetActive(!characterSheet.activeSelf);

        }

	}
}
