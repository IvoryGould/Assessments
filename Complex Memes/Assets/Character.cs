using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    private int m_Health;
    public int m_MaxHealth;
    private int m_Stamina;
    public int m_MaxStamina;

    public int expToAward;

    public int characterLevel;
    public int characterExp;
    public float expToLevel;
    public float LevelUpExpModifier;

    public int perkPoints = 0;

    public ModifierManager modifierManager;
    public StatManager statManager;
    public SkillManager skillManager;

    public bool hasALevelChanged;
    public bool hasASkillLevelChanged;

    private void Awake()
    {

        statManager = Resources.Load("StatManager") as StatManager;
        skillManager = Resources.Load("SkillManager") as SkillManager;
        modifierManager = Resources.Load("ModifierManager") as ModifierManager;

        ScriptableObject statManagerClone = Instantiate(statManager);
        statManager = statManagerClone as StatManager;

        ScriptableObject skillManagerClone = Instantiate(skillManager);
        skillManager = skillManagerClone as SkillManager;

        ScriptableObject modifierManagerClone = Instantiate(modifierManager);
        modifierManager = modifierManagerClone as ModifierManager;

    }

    // Use this for initialization
    void Start () {



	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space)) {

            AddSkillLevel(1, 2);

        }

        //hasALevelChanged = statManager.incrementStatLevelByID(4);
        //hasASkillLevelChanged = skillManager.AwardExpToSkill(7, 1);


        if (hasALevelChanged == true) {

            ApplyStatEffect();

            hasALevelChanged = false;

        }

        if (hasASkillLevelChanged == true) {

            ApplySkillEffect();
            AddCharacterExp();

            hasASkillLevelChanged = false;

        }

	}

    public void ApplyStatEffect()
    {

        for (int i = 0; i < statManager.statList.Count; i++)
        {

            if (statManager.statList[i].statLevel == 1)
            {

                continue;

            }

            for (int j = 0; j < statManager.statList[i].effectList.Count; j++)
            {

                for (int t = 0; t < modifierManager.modifierList.Count; t++) {

                    if (statManager.statList[i].effectList[j].modifierName == modifierManager.modifierList[t].modifierName) {

                        if (statManager.statList[i].effectList[j].modifierPercentage != 0) //apply percentages
                        {
                            
                            modifierManager.modifierList[t].baseValue *= (statManager.statList[i].effectList[j].modifierPercentage / 100 + 1);

                        }
                        else if (statManager.statList[i].effectList[j].modifierAmount != 0) { //apply hard numbers

                            modifierManager.modifierList[t].baseValue += statManager.statList[i].effectList[j].modifierAmount;

                        }

                    }

                }

            }

        }

    }

    public void ApplySkillEffect() {

        for (int i = 0; i < skillManager.skillList.Count; i++)
        {

            if (skillManager.skillList[i].skillLevel == 1)
            {

                continue;

            }

            for (int j = 0; j < skillManager.skillList[i].effectList.Count; j++)
            {

                for (int t = 0; t < modifierManager.modifierList.Count; t++)
                {

                    if (skillManager.skillList[i].effectList[j].modifierName == modifierManager.modifierList[t].modifierName)
                    {

                        if (skillManager.skillList[i].effectList[j].modifierPercentage != 0) //apply percentages
                        {

                            modifierManager.modifierList[t].baseValue *= (skillManager.skillList[i].effectList[j].modifierPercentage / 100 + 1);

                        }
                        else if (skillManager.skillList[i].effectList[j].modifierAmount != 0)// apply hard numbers
                        {

                            modifierManager.modifierList[t].baseValue += skillManager.skillList[i].effectList[j].modifierAmount;

                        }

                    }

                }

            }

        }

    }

    public void AddCharacterExp() {

        characterExp += expToAward;

        if (characterExp >= expToLevel) {

            characterLevel++;
            perkPoints++;
            characterExp = characterExp - (int)expToLevel;
            expToLevel *= LevelUpExpModifier;

        }

    }

    public void AddSkillLevel(int skillId, int actionId) {

        hasASkillLevelChanged = skillManager.AwardExpToSkill(skillId, actionId);

    }

    public void AddStatLevel(int statId) {

        hasALevelChanged = statManager.incrementStatLevelByID(statId);

    }

}
