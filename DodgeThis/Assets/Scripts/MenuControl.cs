using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public SettingsData sD;
    public TextMeshProUGUI highscoreText;

    public Slider musicSlider;
    public Slider sfxSlider;

    public GameObject skinsPage;
    GameObject skinsPage1;
    GameObject skinsPage2;
    GameObject skinsPage3;
    public GameObject trailsPage;
    GameObject trailsPage1;
    GameObject trailsPage2;
    GameObject trailsPage3;

    public GameObject hiddenButton;
    public GameObject explosion;

    float secretCounter = 0;

    void Start()
    {
        sD = FindObjectOfType<SettingsData>();
        if (SceneManager.GetActiveScene().name == "StartMenu")
        {
            musicSlider.onValueChanged.AddListener(delegate { sD.UpdateMusicVol(); });
            sfxSlider.onValueChanged.AddListener(delegate { sD.UpdateSfxVol(); });
            musicSlider.onValueChanged.AddListener(delegate { sD.SaveGame("menu"); });
            sfxSlider.onValueChanged.AddListener(delegate { sD.SaveGame("menu"); });
            highscoreText = GameObject.Find("EndlessHighscore").GetComponent<TextMeshProUGUI>();
            highscoreText.text = sD.highscore.ToString();
            skinsPage = gameObject.transform.Find("UnlocksPage").transform.Find("SkinsPage").gameObject;
            skinsPage1 = skinsPage.transform.Find("SkinsPage1").gameObject;
            skinsPage2 = skinsPage.transform.Find("SkinsPage2").gameObject;
            skinsPage3 = skinsPage.transform.Find("SkinsPage3").gameObject;
            trailsPage = gameObject.transform.Find("UnlocksPage").transform.Find("TrailsPage").gameObject;
            trailsPage1 = trailsPage.transform.Find("TrailsPage1").gameObject;
            trailsPage2 = trailsPage.transform.Find("TrailsPage2").gameObject;
            trailsPage3 = trailsPage.transform.Find("TrailsPage3").gameObject;
            hiddenButton = GameObject.Find("HiddenButton");
            SetSprite(sD.skinSelected);
            SetTrail(sD.trailSelected);
        }
    }

    void Update()
    {
        if(sD == null)
        {
            sD = FindObjectOfType<SettingsData>();
            if (SceneManager.GetActiveScene().name == "StartMenu")
            {
                musicSlider.onValueChanged.AddListener(delegate { sD.UpdateMusicVol(); });
                sfxSlider.onValueChanged.AddListener(delegate { sD.UpdateSfxVol(); });
                musicSlider.onValueChanged.AddListener(delegate { sD.SaveGame("menu"); });
                sfxSlider.onValueChanged.AddListener(delegate { sD.SaveGame("menu"); });
                highscoreText = GameObject.Find("EndlessHighscore").GetComponent<TextMeshProUGUI>();
                highscoreText.text = sD.highscore.ToString();
            }
        }
        if (SceneManager.GetActiveScene().name == "StartMenu")
        {
            if(secretCounter > 0) 
            {
                if(secretCounter > 5)
                {
                    sD.UnlockCustomise(19);
                }
                secretCounter -= Time.deltaTime * 5;                
            }

        }
    }
    public void LoadScene(string name)
    {
        FindObjectOfType<SettingsData>().newScene = true;
        SceneManager.LoadScene(name);
    }

    public void PopupMenuToggle(GameObject popup)
    {
        popup.SetActive(!popup.activeInHierarchy);
    }
    public void PopupMenuOff(GameObject popup)
    {
        popup.SetActive(false);
    }

    public void UnlocksMenuSwitch(string main)
    {
        if(main == "skins")
        {
            skinsPage.SetActive(true);
            trailsPage.SetActive(false);
            skinsPage1.SetActive(true);
            skinsPage2.SetActive(false);
            skinsPage3.SetActive(false);
        }
        else if(main == "trails")
        {           
            trailsPage.SetActive(true);
            skinsPage.SetActive(false);
            trailsPage1.SetActive(true);
            trailsPage2.SetActive(false);
            trailsPage3.SetActive(false);
        }
    }

    public void SetSprite(int spriteNum)
    {
        sD.skinSelected = spriteNum;
        try
        {
            Debug.Log("Set sprite");
            GameObject.Find("PlayerSprite").GetComponent<SpriteRenderer>().sprite = sD.shipSprites[sD.skinSelected];
        }
        catch { }
    }
    public void SetTrail(int trailNum)
    {
        sD.trailSelected = trailNum;
        try
        {
            Debug.Log("Set trail");
            Destroy(GameObject.Find("Player").transform.GetChild(2).gameObject); 
            GameObject trail = Instantiate(sD.shipTrails[sD.trailSelected], GameObject.Find("Player").transform);
            if (sD.trailSelected == 18)
            {
                trail.GetComponent<ParticleSystemRenderer>().material = FindObjectOfType<SettingsData>().shipMaterials[0];
                var m = trail.GetComponent<ParticleSystem>().main;
                m.startSize = 0.2f;
            }
            if (sD.trailSelected == 19)
            {
                trail.GetComponent<ParticleSystemRenderer>().material = FindObjectOfType<SettingsData>().shipMaterials[1];
                var m = trail.GetComponent<ParticleSystem>().main;
                m.startSize = 0.25f;
            }
        }
        catch { }
    }

    public void SaveCustomise()
    {
        sD.SaveGame("menu");
    }
    public void UnlockCustomise(int unlockKey)
    {
        FindObjectOfType<SettingsData>().skinsUnlocked[unlockKey] = true;
        FindObjectOfType<SettingsData>().trailsUnlocked[unlockKey] = true;
    }
    public void SecretButton()
    {
        GameObject x = Instantiate(explosion, hiddenButton.transform);
        x.transform.position = new Vector3(0, hiddenButton.transform.position.y + 0.25f, 0);
        //var pS = x.GetComponent<ParticleSystem>().main;
        //pS.startColor = new Color(255/255, 236/255, 0/255, 1f);
        secretCounter++;
    }

    public void LoadLevel(int levelNum)
    {
        FindObjectOfType<LevelData>().LevelSelect(levelNum);
    }

    public void NextLevel()
    {
        if(FindObjectOfType<LevelData>().selectedLevel == 9)
        {
            FindObjectOfType<LevelData>().LevelSelect(9);
        }
        else
        {
            FindObjectOfType<LevelData>().LevelSelect(FindObjectOfType<LevelData>().selectedLevel + 1);
        }
    }
}
