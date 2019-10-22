using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceInventory : MonoBehaviour {

    public int ironValue = 0;
    public int copperValue = 0;
    public int steelValue = 0;
    public int ironOreValue = 0;
    public int copperOreValue = 0;
    public int coalValue = 0;

    private Text ironText;
    private Text copperText;
    private Text steelText;
    private Text ironOreText;
    private Text copperOreText;
    private Text coalText;

    void Awake() {

        ironText = GameObject.Find("Iron Amount").GetComponent<Text>();
        copperText = GameObject.Find("Copper Amount").GetComponent<Text>();
        steelText = GameObject.Find("Steel Amount").GetComponent<Text>();
        ironOreText = GameObject.Find("Iron Ore Amount").GetComponent<Text>();
        copperOreText = GameObject.Find("Copper Ore Amount").GetComponent<Text>();
        coalText = GameObject.Find("Coal Amount").GetComponent<Text>();
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        ironText.text = "" + ironValue;
        copperText.text = "" + copperValue;
        steelText.text = "" + steelValue;
        ironOreText.text = "" + ironOreValue;
        copperOreText.text = "" + copperOreValue;
        coalText.text = "" + coalValue;

	}
}
