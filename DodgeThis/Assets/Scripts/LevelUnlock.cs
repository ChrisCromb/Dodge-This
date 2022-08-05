using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public List<Button> buttons = new List<Button>();

    void Start()
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
                    }
                }
                if (menu == "trails")
                {
                    if (sD.trailsUnlocked[i])
                    {
                        buttons[i].interactable = true;
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
                if (lU.menu == "skins")
                {
                    if (sD.skinsUnlocked[i])
                    {
                        lU.buttons[i].interactable = true;
                    }
                }
                if (lU.menu == "trails")
                {
                    if (sD.trailsUnlocked[i])
                    {
                        lU.buttons[i].interactable = true;
                    }
                }
            }
        }
    }
}
