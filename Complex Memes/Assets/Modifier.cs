using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Modifier {

    public string modifierName;

    public int modifierID;

    public float baseValue;

    public Modifier getCopy()
    {

        return (Modifier)this.MemberwiseClone();

    }


}
