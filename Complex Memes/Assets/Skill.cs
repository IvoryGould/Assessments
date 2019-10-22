using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Skill {

    public string skillName;

    public int skillID;

    public enum SkillType {

        Combat,
        NonCombat

    }

    public SkillType skillType;

    public int skillLevel;

    public int skillExp;
    public float expToNextLevel;

    public List<Action> actionList = new List<Action>();
    public List<Effect> effectList = new List<Effect>();

    public Skill getCopy()
    {

        return (Skill)this.MemberwiseClone();

    }

    public bool incrementSkillLevelByExp()
    {

        if (this.skillExp >= this.expToNextLevel) {

            skillLevel++;

            if (skillExp > expToNextLevel)
            {

                skillExp = skillExp - (int)expToNextLevel;

            }
            else {

                skillExp = 0;

            }

            expToNextLevel *= 1.2f;

        }

        return true;
    }

}
