using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int highscore = 0;
    public int unlockedLevel = 1;
    public float musicVol;
    public float sfxVol;
    public bool[] skinsUnlocked = new bool[27] { true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
    public bool[] trailsUnlocked = new bool[27] { true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
    public int skinSelected = 0;
    public int trailSelected = 0;
    public int smallSDefeated = 0;
    public int mediumSDefeated = 0;
    public int largeSDefeated = 0;

    public SaveData(EnemySpawner es, UIController uic, LevelData ld, SettingsData sd)
    {
        Debug.Log("Highscore: " + highscore + "    uic score: " + uic.score);
        Debug.Log("Unlocked Level: " + unlockedLevel + "    selected level: " + ld.selectedLevel + "    win: " + es.win.ToString());
        Debug.Log("Music Vol: " + musicVol + "    sd music vol: " + sd.musicVol);
        Debug.Log("Sfx Vol: " + sfxVol + "    sd sfx vol: " + sd.sfxVol);
        Debug.Log("Skin Selected: " + skinSelected + "    sd skin selected: " + sd.skinSelected);
        Debug.Log("Trail Selected: " + trailSelected + "    sd trail selected: " + sd.trailSelected);
        //Debug.Log(skinsUnlocked[0].ToString() + skinsUnlocked[1].ToString() + skinsUnlocked[2].ToString() + skinsUnlocked[3].ToString());
        //Debug.Log(sd.skinsUnlocked[0].ToString() + sd.skinsUnlocked[1].ToString() + sd.skinsUnlocked[2].ToString() + sd.skinsUnlocked[3].ToString());
        if (highscore == 0)
        {
            highscore = sd.highscore;
        }
        if(uic.score > highscore && ld.selectedLevel == 0)
        {
            highscore = uic.score;
        }
        if(unlockedLevel == 1)
        {
            unlockedLevel = sd.unlockedLevel;
        }
        if(ld.selectedLevel == unlockedLevel && es.win)
        {
            unlockedLevel = ld.selectedLevel + 1;
        }
        musicVol = sd.musicVol;
        sfxVol = sd.sfxVol;
        skinsUnlocked = sd.skinsUnlocked;
        trailsUnlocked = sd.trailsUnlocked;
        skinSelected = sd.skinSelected;
        trailSelected = sd.trailSelected;
        smallSDefeated = sd.smallSDefeated;
        mediumSDefeated = sd.mediumSDefeated;
        largeSDefeated = sd.largeSDefeated;
    }

    public SaveData(int hs, int ul, SettingsData sd) //Save only audio settings and skins
    {
        Debug.Log("Highscore: " + highscore);
        Debug.Log("Unlocked Level: " + unlockedLevel);
        Debug.Log("Music Vol: " + musicVol + "    sd music vol: " + sd.musicVol);
        Debug.Log("Sfx Vol: " + sfxVol + "    sd sfx vol: " + sd.sfxVol);
        Debug.Log("Skin Selected: " + skinSelected + "    sd skin selected: " + sd.skinSelected);
        Debug.Log("Trail Selected: " + trailSelected + "    sd trail selected: " + sd.trailSelected);
        //Debug.Log(skinsUnlocked[0].ToString() + skinsUnlocked[1].ToString() + skinsUnlocked[2].ToString() + skinsUnlocked[3].ToString());
        //Debug.Log(sd.skinsUnlocked[0].ToString() + sd.skinsUnlocked[1].ToString() + sd.skinsUnlocked[2].ToString() + sd.skinsUnlocked[3].ToString());
        highscore = hs;
        unlockedLevel = ul;
        musicVol = sd.musicVol;
        sfxVol = sd.sfxVol;
        skinsUnlocked = sd.skinsUnlocked;
        trailsUnlocked = sd.trailsUnlocked;
        skinSelected = sd.skinSelected;
        trailSelected = sd.trailSelected;
        smallSDefeated = sd.smallSDefeated;
        mediumSDefeated = sd.mediumSDefeated;
        largeSDefeated = sd.largeSDefeated;
    }

    public SaveData()
    {
        highscore = 0;
        unlockedLevel = 1;
        musicVol = 1f;
        sfxVol = 1f;
        skinsUnlocked = new bool[27] { true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
        trailsUnlocked = new bool[27] { true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
        skinSelected = 0;
        trailSelected = 0;
        smallSDefeated = 0;
        mediumSDefeated = 0;
        largeSDefeated = 0;
}
}
