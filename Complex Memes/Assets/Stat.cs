using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat {

    public string statName;

    public int statID;

    public int statLevel;

    public List<Effect> effectList = new List<Effect>();

    public Stat getCopy() {

        return (Stat)this.MemberwiseClone();

    }

}
