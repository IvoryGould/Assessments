using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Furnace : MonoBehaviour {

    private Text outputAmount;
    private Dropdown itemDropdown;
    private Slider amountSlider;
    private Button collectButton;
    private GameObject canvas;

    private ResourceInventory resourceInventory;

    void Awake() {

        resourceInventory = GameObject.Find("GUI Canvas").GetComponent<ResourceInventory>();

        this.canvas = this.gameObject.transform.Find("Furnace Canvas").gameObject;

        this.outputAmount = this.canvas.transform.Find("OutputAmount").GetComponent<Text>();
        this.itemDropdown = this.canvas.transform.Find("ItemDropdown").GetComponent<Dropdown>();
        this.amountSlider = this.canvas.transform.Find("ItemSlider").GetComponent<Slider>();
        this.collectButton = this.canvas.transform.Find("CollectButton").GetComponent<Button>();

    }

    // Use this for initialization
    void Start () {

        //this.outputAmount = GameObject.Find("OutputAmount").GetComponent<Text>();
        //this.itemDropdown = GameObject.Find("ItemDropdown").GetComponent<Dropdown>();
        //this.amountSlider = GameObject.Find("ItemSlider").GetComponent<Slider>();
        //this.collectButton = GameObject.Find("CollectButton").GetComponent<Button>();

	}
	
	// Update is called once per frame
	void Update () {

        this.outputAmount.text = "" + this.amountSlider.value;

	}

    public void CollectMetal() {

        if (itemDropdown.value == 0 && resourceInventory.ironOreValue >= 1) {

            resourceInventory.ironOreValue -= (int)amountSlider.value;
            resourceInventory.ironValue += (int)amountSlider.value;

        }

        if (itemDropdown.value == 1 && resourceInventory.copperOreValue >= 1) {

            resourceInventory.copperOreValue -= (int)amountSlider.value;
            resourceInventory.copperValue += (int)amountSlider.value;

        }

        if (itemDropdown.value == 2 && resourceInventory.ironOreValue >= 2 && resourceInventory.coalValue >= 1) {

            resourceInventory.coalValue -= (int)amountSlider.value;
            resourceInventory.ironOreValue -= ((int)amountSlider.value * 2);
            resourceInventory.steelValue += (int)amountSlider.value;

        }

    }

}
