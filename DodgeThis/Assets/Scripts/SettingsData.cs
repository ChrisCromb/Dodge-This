using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SettingsData : MonoBehaviour
{
    // Start is called before the first frame update
    public float musicVol = 1f;
    public float sfxVol = 1f;

    public Slider musicSlider;
    public Slider sfxSlider;

    public bool newScene = false;
    bool updateSettings = false;

    public int highscore = 0;
    public int unlockedLevel = 1;

    public bool[] skinsUnlocked = new bool[27] { true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
    public bool[] trailsUnlocked = new bool[27] { true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
    public List<Sprite> shipSprites = new List<Sprite>();
    public List<GameObject> shipTrails = new List<GameObject>();
    public List<Material> shipMaterials = new List<Material>();
    //public List<Sprite> shipSprites = new List<Sprite>();   
    public int skinSelected = 0;
    public int trailSelected = 0;

    public int smallSDefeated = 0;
    public int mediumSDefeated = 0;
    public int largeSDefeated = 0;

    //SKIN 0: DEFAULT;   SKIN 1: BEAT THE BOSS OF LEVEL 9;   SKIN 2: GET A SCORE OF OVER 2000 IN ENDLESS;    SKIN 3: GET A SCORE OF OVER 4000 IN ENDLESS;
    //SKIN 4: GET A SCORE OF OVER 6000 IN ENDLESS;   SKIN 5: GET A SCORE OF OVER 8000 IN ENDLESS;   SKIN 6: GET A SCORE OF OVER 10000 IN ENDLESS;    SKIN 7: DEFEAT 50 SMALL SHIPS IN ENDLESS;
    //SKIN 8: DEFEAT 50 MEDIUM SHIPS IN ENDLESS;   SKIN 9: DEFEAT 50 LARGE SHIPS IN ENDLESS;   SKIN 10: DEFEAT 100 SMALL SHIPS IN ENDLESS;   SKIN 11: DEFEAT 100 MEDIUM SHIPS IN ENDLESS;
    //SKIN 12: DEFEAT 100 LARGE SHIPS IN ENDLESS;   SKIN 13: DEFEAT 200 SMALL SHIPS IN ENDLESS;   SKIN 14: DEFEAT 200 MEDIUM SHIPS IN ENDLESS;   SKIN 15: DEFEAT 200 LARGE SHIPS IN ENDLESS;
    //SKIN 16: PLAY ENDLESS MODE 5 TIMES;   SKIN 17: PLAY ENDLESS MODE 15 TIMES;   SKIN 18: VISIT THE KOFI DONATE PAGE;   SKIN 19: FIND THE SECRET ON THE MAIN MENU;
    //SKIN 20: ???;   SKIN 21: ???;   SKIN 22: ???;   SKIN 23: ???;   
    //SKIN 24: ???;   SKIN 25: ???;   SKIN 26: ???;


    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI levelUnlockedText;
    public TextMeshProUGUI musicVolText;
    public TextMeshProUGUI sfxVolText;

    public AudioSource menuMusic;


    void Awake()
    {
        try 
        {
            if (FindObjectsOfType<SettingsData>()[1])
                Destroy(gameObject);
        }

        catch //(Exception e)
        {
            Debug.Log("No duplicate settings could be found");
        }            

        DontDestroyOnLoad(this.gameObject);

        //ResetGame();
        LoadGame();

        foreach (Slider s in FindObjectsOfType<Slider>(true))
        {
            if (s.name == "MusicSlider")
                musicSlider = s;

            if (s.name == "SfxSlider")
                sfxSlider = s;
        }
        /*musicSlider = FindObjectsOfType<Slider>(true)[1];
        if (musicSlider)
            Debug.Log("musicSlider found: " + musicSlider.name);
        else
            Debug.Log("No musicSlider object could be found");

        sfxSlider = FindObjectsOfType<Slider>(true)[0];
        if (sfxSlider)
            Debug.Log("sfxSlider found: " + sfxSlider.name);
        else
            Debug.Log("No sfxSlider object could be found");*/
        try
        {
            musicSlider.value = musicVol;
            sfxSlider.value = sfxVol;
        }
        catch //(Exception e)
        {
            Debug.Log("Testing started from Level scene, no slider to load");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(skinsUnlocked[0].ToString() + skinsUnlocked[1].ToString() + skinsUnlocked[2].ToString() + skinsUnlocked[3].ToString());
        try
        {
            if (highscoreText == null)
            {
                highscoreText = GameObject.Find("Text A").GetComponent<TextMeshProUGUI>();
                levelUnlockedText = GameObject.Find("Text B").GetComponent<TextMeshProUGUI>();
                musicVolText = GameObject.Find("Text C").GetComponent<TextMeshProUGUI>();
                sfxVolText = GameObject.Find("Text D").GetComponent<TextMeshProUGUI>();
            }
            highscoreText.text = "Highscore: " + highscore;
            levelUnlockedText.text = "Level Unlocked: " + unlockedLevel;
            musicVolText.text = "Music Vol: " + musicVol;
            sfxVolText.text = "Sfx Vol: " + sfxVol;
        }
        catch { }
        if(newScene == true)
        {
            if(SceneManager.GetActiveScene().name == "StartMenu")
            {
                updateSettings = true;
            }
            if(updateSettings == true)
            {
                foreach(Slider s in FindObjectsOfType<Slider>(true))
                {
                    if (s.name == "MusicSlider")
                        musicSlider = s;

                    if (s.name == "SfxSlider")
                        sfxSlider = s;
                }
                /*musicSlider = FindObjectsOfType<Slider>(true)[1];
                if (musicSlider)
                    Debug.Log("musicSlider found: " + musicSlider.name);
                else
                    Debug.Log("No musicSlider object could be found");

                sfxSlider = FindObjectsOfType<Slider>(true)[0];
                if (sfxSlider)
                    Debug.Log("sfxSlider found: " + sfxSlider.name);
                else
                    Debug.Log("No sfxSlider object could be found");*/
                musicSlider.value = musicVol;
                sfxSlider.value = sfxVol;
                menuMusic = FindObjectOfType<AudioSource>();
                newScene = false;
                updateSettings = false;
            }
        }
        if (menuMusic != null)
        {
            if (menuMusic.volume != musicVol)
            {
                menuMusic.volume = musicVol;
            }
        }
    }

    public void OpenURL(string URL)
    {
        Debug.Log("Opened URL");
        Application.OpenURL(URL);
    }

    public void UnlockCustomise(int unlockKey)
    {       
        skinsUnlocked[unlockKey] = true;
        trailsUnlocked[unlockKey] = true;        
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

    public void UpdateMusicVol()
    {
        musicVol = musicSlider.value;
        //Debug.Log(musicSlider.value + " " + musicVol);        
    }
    
    public void UpdateSfxVol()
    {
        sfxVol = sfxSlider.value;
    }

    public void SaveGame()
    {
        Debug.Log("Saving");
        EnemySpawner es = GameObject.Find("EnemySpawnerRight").GetComponent<EnemySpawner>();
        UIController uic = FindObjectOfType<UIController>();
        LevelData ld = this.GetComponent<LevelData>();
        SettingsData sd = this.GetComponent<SettingsData>();
        SaveSystem.SaveGame(es, uic, ld, sd);
        LoadGame();
    }

    public void SaveGame(string whatToSave)
    {
        if (whatToSave == "menu")
        {
            Debug.Log("Saving menu settings");
            SettingsData sd = this.GetComponent<SettingsData>();
            SaveSystem.SaveGame(highscore, unlockedLevel, sd);
            LoadGame();
            foreach(LevelUnlock lU in FindObjectsOfType<LevelUnlock>())
            {
                LoadUnlocks(lU);
            }
        }
    }

    public void ResetGame()
    {
        Debug.Log("Resetting");
        SaveSystem.SaveGame();
        LoadGame();
    }

    public void LoadGame()
    {
        Debug.Log("Loading");
        SaveData data = SaveSystem.LoadGame();

        //Debug.Log("Highscore: " + highscore);
        //Debug.Log("Unlocked Level: " + unlockedLevel);
        //Debug.Log("Music Vol: " + musicVol);
        //Debug.Log("Sfx Vol: " + sfxVol);

        highscore = data.highscore;
        unlockedLevel = data.unlockedLevel;
        musicVol = data.musicVol;
        sfxVol = data.sfxVol;
        skinsUnlocked = data.skinsUnlocked;
        trailsUnlocked = data.trailsUnlocked;
        skinSelected = data.skinSelected;
        trailSelected = data.trailSelected;
        smallSDefeated = data.smallSDefeated;
        mediumSDefeated = data.mediumSDefeated;
        largeSDefeated = data.largeSDefeated;

    //Debug.Log("New Highscore: " + highscore);
    //Debug.Log("New Unlocked Level: " + unlockedLevel);
    //Debug.Log("New Music Vol: " + musicVol);
    //Debug.Log("New Sfx Vol: " + sfxVol);
    }
}
