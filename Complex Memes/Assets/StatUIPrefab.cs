using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatUIPrefab : MonoBehaviour {

    Character player;

    void Awake()
    {

        player = GameObject.Find("Person").GetComponent<Character>();

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.GetChild(1).GetComponent<Text>().text = player.statManager.getStatByName(this.transform.GetChild(0).GetComponent<Text>().text).statLevel.ToString();


    }
}
