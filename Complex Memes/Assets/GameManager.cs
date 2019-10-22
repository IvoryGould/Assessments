using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject characterSheet;

	// Use this for initialization
	void Start () {

        characterSheet = GameObject.Find("CharacterSheet");

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Tab)) {

            characterSheet.SetActive(!characterSheet.activeSelf);

        }

	}
}
