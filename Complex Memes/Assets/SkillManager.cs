using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillManager", menuName = "ScriptableObject/SkillManager", order = 2)]
public class SkillManager : ScriptableObject {

    [SerializeField]
    public List<Skill> skillList = new List<Skill>();

    public Skill getSkillByID(int id)
    {

        for (int i = 0; i < skillList.Count; i++)
        {

            if (skillList[i].skillID == id)
            {

                return skillList[i].getCopy();

            }

        }
        return null;
    }
    public Skill getSkillByName(string name)
    {

        for (int i = 0; i < skillList.Count; i++)
        {

            if (skillList[i].skillName.ToLower().Equals(name.ToLower()))
            {

                return skillList[i].getCopy();

            }

        }

        return null;

    }

    public void incrementSkillLevelByID(int id) //Level up the skill by it ID
    { 

        for (int i = 0; i < skillList.Count; i++)
        {

            if (skillList[i].skillID == id)
            {

                skillList[i].skillLevel++;

            }

        }

    }

    public bool AwardExpToSkill(int skillID, int actionID) {

        for (int i = 0; i < skillList.Count; i++) {

            if (skillList[i].skillID == skillID) {

                for (int j = 0; j < skillList[i].actionList.Count; j++) {

                    if (skillList[i].actionList[j].actionID == actionID) {

                        skillList[i].skillExp += skillList[i].actionList[j].actionExpValue;

                    }

                }

                return skillList[i].incrementSkillLevelByExp();

            }

        }

        return false;

    }

}
