using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public float playerMaxHealth = 20f;
    public float playerCurHealth = 1f;

    public GameObject explosion;

    public GameObject gameOverPopup;
    public TextMeshProUGUI highScorePopup;


    void Awake()
    {
        gameObject.transform.Find("PlayerSprite").GetComponent<SpriteRenderer>().sprite = FindObjectOfType<SettingsData>().shipSprites[FindObjectOfType<SettingsData>().skinSelected];
        /*if (FindObjectOfType<SettingsData>().trailSelected == 19)
        {
            gameObject.transform.Find("PlayerSprite").localScale = new Vector3(0.5f, 0.5f, 1f);
        }*/
        GameObject trail = Instantiate(FindObjectOfType<SettingsData>().shipTrails[FindObjectOfType<SettingsData>().trailSelected], gameObject.transform);
        if(FindObjectOfType<SettingsData>().trailSelected == 18)
        {
            trail.GetComponent<ParticleSystemRenderer>().material = FindObjectOfType<SettingsData>().shipMaterials[0];
            var m = trail.GetComponent<ParticleSystem>().main;
            m.startSize = 0.2f;
        }
        if (FindObjectOfType<SettingsData>().trailSelected == 19)
        {
            trail.GetComponent<ParticleSystemRenderer>().material = FindObjectOfType<SettingsData>().shipMaterials[1];
            var m = trail.GetComponent<ParticleSystem>().main;
            m.startSize = 0.25f;
        }

        /*
        //gameObject.transform.Find("Engine System").GetComponent<SpriteRenderer>().sprite = FindObjectOfType<SettingsData>().shipSprites[FindObjectOfType<SettingsData>().skinSelected];
        var pSystem = gameObject.transform.Find("Engine System").GetComponent<ParticleSystem>().main;
        var sColour = pSystem.startColor;
        sColour.mode = ParticleSystemGradientMode.RandomColor;
        //pSystem.startColor.mode = ParticleSystemGradientMode.RandomColor;
        ParticleSystem.MinMaxGradient gradient = SetTrail(FindObjectOfType<SettingsData>().trailSelected);
        Gradient g = SetTrail();
        gradient.mode = ParticleSystemGradientMode.RandomColor;
        //gradient.mode = (ParticleSystemGradientMode)GradientMode.Fixed;
        //g.mode = GradientMode.Fixed;
        pSystem.startColor = gradient;
        //pSystem.startColor.mode = ParticleSystemGradientMode.RandomColor;*/
    }
    void Start()
    {
        playerCurHealth = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCurHealth <= 0f)
        {
            GameObject x = Instantiate(explosion, transform.position, transform.rotation);
            x.GetComponent<AudioSource>().volume = FindObjectOfType<SettingsData>().sfxVol;
            bool ePlayed = false;
            foreach(EnemySpawner eS in FindObjectsOfType<EnemySpawner>())
            {
                if(eS.win == false && eS.lose == false)
                {
                    eS.lose = true;
                    gameOverPopup.SetActive(true);
                    if (eS.endlessMode)
                    {
                        if (FindObjectOfType<LevelData>().selectedLevel == 0)
                        {
                            highScorePopup.text = "HIGHSCORE: " + FindObjectOfType<SettingsData>().highscore;
                            highScorePopup.gameObject.SetActive(true);
                        }
                        UIController uIC = FindObjectOfType<UIController>();
                        SettingsData sD = FindObjectOfType<SettingsData>();
                        if(ePlayed == false)
                        {
                            sD.endlessPlayed++;
                            ePlayed = true;
                        }                        

                        if (uIC.score >= 2000 && sD.skinsUnlocked[2] == false)
                        {
                            sD.UnlockCustomise(2); //UNLOCK SKIN 2
                        }
                        if (uIC.score >= 4000 && sD.skinsUnlocked[3] == false)
                        {
                            sD.UnlockCustomise(3); //UNLOCK SKIN 3
                        }
                        if (uIC.score >= 6000 && sD.skinsUnlocked[4] == false)
                        {
                            sD.UnlockCustomise(4); //UNLOCK SKIN 4
                        }
                        if (uIC.score >= 8000 && sD.skinsUnlocked[5] == false)
                        {
                            sD.UnlockCustomise(5); //UNLOCK SKIN 5
                        }
                        if (uIC.score >= 10000 && sD.skinsUnlocked[6] == false)
                        {
                            sD.UnlockCustomise(6); //UNLOCK SKIN 6
                        }
                        if(sD.smallSDefeated >= 50 && sD.skinsUnlocked[7] == false)
                        {
                            sD.UnlockCustomise(7); //UNLOCK SKIN 7
                        }
                        if (sD.mediumSDefeated >= 50 && sD.skinsUnlocked[8] == false)
                        {
                            sD.UnlockCustomise(8); //UNLOCK SKIN 8
                        }
                        if (sD.largeSDefeated >= 50 && sD.skinsUnlocked[9] == false)
                        {
                            sD.UnlockCustomise(9); //UNLOCK SKIN 9
                        }
                        if (sD.smallSDefeated >= 100 && sD.skinsUnlocked[10] == false)
                        {
                            sD.UnlockCustomise(10); //UNLOCK SKIN 10
                        }
                        if (sD.mediumSDefeated >= 100 && sD.skinsUnlocked[11] == false)
                        {
                            sD.UnlockCustomise(11); //UNLOCK SKIN 11
                        }
                        if (sD.largeSDefeated >= 100 && sD.skinsUnlocked[12] == false)
                        {
                            sD.UnlockCustomise(12); //UNLOCK SKIN 12
                        }
                        if (sD.smallSDefeated >= 200 && sD.skinsUnlocked[13] == false)
                        {
                            sD.UnlockCustomise(13); //UNLOCK SKIN 13
                        }
                        if (sD.mediumSDefeated >= 200 && sD.skinsUnlocked[14] == false)
                        {
                            sD.UnlockCustomise(14); //UNLOCK SKIN 14
                        }
                        if (sD.largeSDefeated >= 200 && sD.skinsUnlocked[15] == false)
                        {
                            sD.UnlockCustomise(15); //UNLOCK SKIN 15
                        }
                    }
                    FindObjectOfType<SettingsData>().SaveGame();
                    FindObjectOfType<UIController>().scoreText.fontSizeMax = 500;
                }
            }

            Destroy(gameObject);
        }
    }

    /*public ParticleSystem.MinMaxGradient SetTrail(int trailNum)
    {
        Gradient g = new Gradient();
        GradientColorKey[] colorKey = new GradientColorKey[3];
        colorKey[0].color = Color.red;
        colorKey[0].time = 0.33f;
        colorKey[1].color = Color.blue;
        colorKey[1].time = 0.66f;
        colorKey[2].color = Color.green;
        colorKey[2].time = 1.0f;

        GradientAlphaKey[] alphaKey = new GradientAlphaKey[1];
        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.0f;

        g.SetKeys(colorKey, alphaKey);

        g.SetKeys(new GradientColorKey[3] { new GradientColorKey(Color.green, 0.0f), new GradientColorKey(Color.red, 1.0f), new GradientColorKey(Color.blue, 1.0f) },
            new GradientAlphaKey[3] { new GradientAlphaKey(1f, 0.0f), new GradientAlphaKey(1f, 1.0f), new GradientAlphaKey(1f, 1.0f) }
        );
        ParticleSystem.MinMaxGradient gradient = new ParticleSystem.MinMaxGradient(g);
        gradient.mode = ParticleSystemGradientMode.RandomColor;

        return gradient;

        //return new ParticleSystem.MinMaxGradient(Color.red, Color.blue);
    }

    public Gradient SetTrail()
    {
        Gradient g = new Gradient();
        GradientColorKey[] colorKey = new GradientColorKey[3];
        colorKey[0].color = Color.red;
        colorKey[0].time = 0.33f;
        colorKey[1].color = Color.blue;
        colorKey[1].time = 0.66f;
        colorKey[2].color = Color.green;
        colorKey[2].time = 1.0f;

        GradientAlphaKey[] alphaKey = new GradientAlphaKey[1];
        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.0f;

        g.SetKeys(colorKey, alphaKey);

        g.SetKeys(new GradientColorKey[3] { new GradientColorKey(Color.green, 0.0f), new GradientColorKey(Color.red, 1.0f), new GradientColorKey(Color.blue, 1.0f) },
            new GradientAlphaKey[3] { new GradientAlphaKey(1f, 0.0f), new GradientAlphaKey(1f, 1.0f), new GradientAlphaKey(1f, 1.0f) }
        );

        g.mode = GradientMode.Fixed;
        return g;

        //return new ParticleSystem.MinMaxGradient(Color.red, Color.blue);
    }*/
}
