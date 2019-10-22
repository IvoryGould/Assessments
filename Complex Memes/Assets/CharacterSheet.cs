using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharacterSheet : MonoBehaviour {

    public List<Skill> combatSkills = new List<Skill>();
    public List<Skill> noncombatSkills = new List<Skill>();

    public Character player;

    public GameObject listElementPrefab;
    public GameObject statElementPrefab;
    private GameObject contentCombat;
    private GameObject contentNonCombat;
    private GameObject contentStats;
    private GameObject scrollViewCombat;
    private GameObject scrollViewNonCombat;
    private GameObject scrollViewStats;
    private GameObject SkillPanel;
    private GameObject StatPanel;
    private GameObject characterLevelBar;
    private GameObject perkPoints;

    string eventClickName;


    void Awake() {

        player = GameObject.Find("Person").GetComponent<Character>();
        contentCombat = GameObject.Find("ContentCombat");
        contentNonCombat = GameObject.Find("ContentNonCombat");
        contentStats = GameObject.Find("Stats Content");
        scrollViewCombat = GameObject.Find("Scroll View Combat");
        scrollViewNonCombat = GameObject.Find("Scroll View NonCombat");
        scrollViewStats = GameObject.Find("Stats Scroll View");
        listElementPrefab = Resources.Load("Skill UI Prefab") as GameObject;
        statElementPrefab = Resources.Load("StatUIPrefab") as GameObject;
        SkillPanel = GameObject.Find("SkillsPanel");
        StatPanel = GameObject.Find("StatsPanel");
        characterLevelBar = GameObject.Find("CharacterLevelBar");
        perkPoints = GameObject.Find("PerkPoints");

    }
         
	// Use this for initialization
	void Start () {

        AllocateToList();
        CombatTab();
        StatsTab();

        for (int i = 0; i < contentCombat.transform.childCount; i++) {

            contentCombat.transform.GetChild(i).GetChild(2).GetComponent<Button>().onClick.AddListener(IndSkillScreenToggle);

        }
        for (int i = 0; i < contentNonCombat.transform.childCount; i++)
        {

            contentNonCombat.transform.GetChild(i).GetChild(2).GetComponent<Button>().onClick.AddListener(IndSkillScreenToggle);

        }
        for (int i = 0; i < contentStats.transform.childCount; i++) {

            contentStats.transform.GetChild(i).GetComponent<Button>().onClick.AddListener(IndStatScreenToggle);

        }

    }
	
	// Update is called once per frame
	void Update () {

        if (SkillPanel.transform.GetChild(1).GetChild(0).GetComponent<Image>().fillAmount >= 1) {

            SkillPanel.transform.GetChild(1).GetChild(0).GetComponent<Image>().fillAmount = 0;

        }

        UpdateUI(eventClickName);


    }


    void AllocateToList() {

        foreach (Skill skill in player.skillManager.skillList) {

            if (skill.skillType == Skill.SkillType.Combat)
            {

                combatSkills.Add(skill);
                GameObject element = Instantiate(listElementPrefab, contentCombat.transform);
                element.transform.GetChild(0).GetComponent<Text>().text = skill.skillName;
                element.transform.GetChild(1).GetComponent<Text>().text = skill.skillLevel.ToString();

            }
            else if (skill.skillType == Skill.SkillType.NonCombat) {

                noncombatSkills.Add(skill);
                GameObject element = Instantiate(listElementPrefab, contentNonCombat.transform);
                element.transform.GetChild(0).GetComponent<Text>().text = skill.skillName;
                element.transform.GetChild(1).GetComponent<Text>().text = skill.skillLevel.ToString();

            }

        }

        foreach (Stat stat in player.statManager.statList) {

            GameObject statElement = Instantiate(statElementPrefab, contentStats.transform);
            statElement.transform.GetChild(0).GetComponent<Text>().text = stat.statName;
            statElement.transform.GetChild(1).GetComponent<Text>().text = stat.statLevel.ToString();

        }

    }

    public void CombatTab() {

        scrollViewCombat.SetActive(true);
        scrollViewNonCombat.SetActive(false);

    }

    public void NonCombatTab() {

        scrollViewCombat.SetActive(false);
        scrollViewNonCombat.SetActive(true);

    }

    public void SkillsTab() {

        SkillPanel.SetActive(true);
        StatPanel.SetActive(false);

    }

    public void StatsTab() {

        SkillPanel.SetActive(false);
        StatPanel.SetActive(true);

    }

    public void IndSkillScreenToggle() {

        eventClickName = EventSystem.current.currentSelectedGameObject.transform.parent.GetChild(0).GetComponent<Text>().text;
        SkillPanel.transform.GetChild(0).GetComponent<Text>().text = player.skillManager.getSkillByName(eventClickName).skillName;
        SkillPanel.transform.GetChild(1).GetChild(0).GetComponent<Image>().fillAmount = player.skillManager.getSkillByName(eventClickName).skillExp / player.skillManager.getSkillByName(eventClickName).expToNextLevel;

    }

    public void IndStatScreenToggle() {

        eventClickName = EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text;
        Debug.Log(eventClickName);
        StatPanel.transform.GetChild(0).GetComponent<Text>().text = player.statManager.getStatByName(eventClickName).statName;

    }

    void UpdateUI(string name) {

        characterLevelBar.transform.GetChild(0).GetComponent<Image>().fillAmount = player.characterExp / player.expToLevel;
        characterLevelBar.transform.GetChild(1).GetComponent<Text>().text = player.characterLevel.ToString();

        perkPoints.transform.GetChild(0).GetComponent<Text>().text = player.perkPoints.ToString();

        SkillPanel.transform.GetChild(1).GetChild(0).GetComponent<Image>().fillAmount = player.skillManager.getSkillByName(name).skillExp / player.skillManager.getSkillByName(name).expToNextLevel;
        SkillPanel.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = player.skillManager.getSkillByName(name).expToNextLevel.ToString();
        SkillPanel.transform.GetChild(1).GetChild(2).GetComponent<Text>().text = player.skillManager.getSkillByName(name).skillExp.ToString();

    }

    public void LevelUpStat() {

        if (player.perkPoints > 0) {

            player.AddStatLevel(player.statManager.getStatByName(StatPanel.transform.GetChild(0).GetComponent<Text>().text).statID);
            player.perkPoints--;

        }

    }
}
