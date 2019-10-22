using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatManager", menuName = "ScriptableObject/StatManager", order = 1)]
public class StatManager : ScriptableObject {

    [SerializeField]
    public List<Stat> statList = new List<Stat>();

    public Stat getStatByID(int id) {

        for (int i = 0; i < statList.Count; i++) {

            if (statList[i].statID == id) {

                return statList[i].getCopy();

            }

        }
            return null;
    }
    public Stat getStatByName(string name) {

        for (int i = 0; i < statList.Count; i++) {

            if (statList[i].statName.ToLower().Equals(name.ToLower())) {

                return statList[i].getCopy();

            }

        }

        return null;

    }

    public bool incrementStatLevelByID(int id) { //Level up the stat by it ID

        for (int i = 0; i < statList.Count; i++) {

            if (statList[i].statID == id) {

                statList[i].statLevel++;
                return true;

            }

        }

        return true;

    }

}
