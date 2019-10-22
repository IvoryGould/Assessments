using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ModifierManager", menuName = "ScriptableObject/ModifierManager", order = 3)]
public class ModifierManager : ScriptableObject {

    [SerializeField]
    public List<Modifier> modifierList = new List<Modifier>();

    public Modifier getmodifierByID(int id)
    {

        for (int i = 0; i < modifierList.Count; i++)
        {

            if (modifierList[i].modifierID == id)
            {

                return modifierList[i].getCopy();

            }

        }
        return null;
    }
    public Modifier getmodifierByName(string name)
    {

        for (int i = 0; i < modifierList.Count; i++)
        {

            if (modifierList[i].modifierName.ToLower().Equals(name.ToLower()))
            {

                return modifierList[i].getCopy();

            }

        }

        return null;

    }

}
