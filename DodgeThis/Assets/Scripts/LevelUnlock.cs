using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUnlock : MonoBehaviour
{
    public string menu;


    public Button level1;
    public Button level2;
    public Button level3;
    public Button level4;
    public Button level5;
    public Button level6;
    public Button level7;
    public Button level8;
    public Button level9;
    public Button level10;
    public Button level11;
    public Button level12;
    public Button level13;
    public Button level14;
    public Button level15;
    public Button level16;
    public Button level17;
    public Button level18;
    public Button level19;
    public Button level20;
    public Button level21;
    public Button level22;
    public Button level23;
    public Button level24;
    public Button level25;
    public Button level26;
    public Button level27;

    public TextMeshProUGUI quest1;
    public TextMeshProUGUI quest2;
    public TextMeshProUGUI quest3;
    public TextMeshProUGUI quest4;
    public TextMeshProUGUI quest5;
    public TextMeshProUGUI quest6;
    public TextMeshProUGUI quest7;
    public TextMeshProUGUI quest8;
    public TextMeshProUGUI quest9;
    public TextMeshProUGUI quest10;
    public TextMeshProUGUI quest11;
    public TextMeshProUGUI quest12;
    public TextMeshProUGUI quest13;
    public TextMeshProUGUI quest14;
    public TextMeshProUGUI quest15;
    public TextMeshProUGUI quest16;
    public TextMeshProUGUI quest17;
    public TextMeshProUGUI quest18;
    public TextMeshProUGUI quest19;
    public TextMeshProUGUI quest20;
    public TextMeshProUGUI quest21;
    public TextMeshProUGUI quest22;
    public TextMeshProUGUI quest23;
    public TextMeshProUGUI quest24;
    public TextMeshProUGUI quest25;
    public TextMeshProUGUI quest26;
    public TextMeshProUGUI quest27;

    public List<Button> buttons = new List<Button>();

    public List<TextMeshProUGUI> achievements = new List<TextMeshProUGUI>();

    void Awake()
    {
        buttons.Add(level1);
        buttons.Add(level2);
        buttons.Add(level3);
        buttons.Add(level4);
        buttons.Add(level5);
        buttons.Add(level6);
        buttons.Add(level7);
        buttons.Add(level8);
        buttons.Add(level9);

        if(menu == "skins" || menu == "trails")
        {
            buttons.Add(level10);
            buttons.Add(level11);
            buttons.Add(level12);
            buttons.Add(level13);
            buttons.Add(level14);
            buttons.Add(level15);
            buttons.Add(level16);
            buttons.Add(level17);
            buttons.Add(level18);
            buttons.Add(level19);
            buttons.Add(level20);
            buttons.Add(level21);
            buttons.Add(level22);
            buttons.Add(level23);
            buttons.Add(level24);
            buttons.Add(level25);
            buttons.Add(level26);
            buttons.Add(level27);

            achievements.Add(quest1);
            achievements.Add(quest2);
            achievements.Add(quest3);
            achievements.Add(quest4);
            achievements.Add(quest5);
            achievements.Add(quest6);
            achievements.Add(quest7);
            achievements.Add(quest8);
            achievements.Add(quest9);
            achievements.Add(quest10);
            achievements.Add(quest11);
            achievements.Add(quest12);
            achievements.Add(quest13);
            achievements.Add(quest14);
            achievements.Add(quest15);
            achievements.Add(quest16);
            achievements.Add(quest17);
            achievements.Add(quest18);
            achievements.Add(quest19);
            achievements.Add(quest20);
            achievements.Add(quest21);
            achievements.Add(quest22);
            achievements.Add(quest23);
            achievements.Add(quest24);
            achievements.Add(quest25);
            achievements.Add(quest26);
            achievements.Add(quest27);
        }

        SettingsData sD = FindObjectOfType<SettingsData>();

        if (menu != "skins" && menu != "trails")
        {
            for (int i = 0; i < sD.unlockedLevel; i++)
            {
                if (i < 9)
                {
                    buttons[i].interactable = true;
                }
            }
        }
        else
        {
            for (int i = 0; i < 27; i++)
            {
                if (menu == "skins")
                {
                    if (sD.skinsUnlocked[i])
                    {
                        buttons[i].interactable = true;
                        achievements[i].enabled = false;
                    }
                    else
                    {
                        achievements[i].enabled = true;
                    }
                }
                if (menu == "trails")
                {
                    if (sD.trailsUnlocked[i])
                    {
                        buttons[i].interactable = true;
                        achievements[i].enabled = false;
                    }
                    else
                    {
                        achievements[i].enabled = true;
                    }
                }
            }
        }
    }

    public void LoadUnlocks(LevelUnlock lU)
    {
        SettingsData sD = FindObjectOfType<SettingsData>();

        if (lU.menu != "skins" && lU.menu != "trails")
        {
            for (int i = 0; i < sD.unlockedLevel; i++)
            {
                if (i < 9)
                {
                    lU.buttons[i].interactable = true;
                }
            }
        }
        else
        {
            for (int i = 0; i < 27; i++)
            {
                if (menu == "skins")
                {
                    if (sD.skinsUnlocked[i])
                    {
                        buttons[i].interactable = true;
                        achievements[i].enabled = false;
                    }
                    else
                    {
                        achievements[i].enabled = true;
                    }
                }
                if (menu == "trails")
                {
                    if (sD.trailsUnlocked[i])
                    {
                        buttons[i].interactable = true;
                        achievements[i].enabled = false;
                    }
                    else
                    {
                        achievements[i].enabled = true;
                    }
                }
            }
        }
    }
}
