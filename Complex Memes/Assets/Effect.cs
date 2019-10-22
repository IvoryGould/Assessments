using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Effect {

    public string Name; //Name of Effect

    public int ID;

    public string modifierName; //Name of Value to be Modified

    public float modifierPercentage; //Percentage to modify by

    public int modifierAmount; //Number to add

    public Effect getCopy()
    {

        return (Effect)this.MemberwiseClone();

    }

}
