using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    public string enemyType = "";

    public float enemyMaxHealth = 5f;
    public float enemyCurHealth = 1f;

    public float enemyMoveSpeed = 1f;
    public float enemyProjDamage = 1f;
    public float enemyProjSpeed = 1f;

    public GameObject powerUp;
    public GameObject explosion;

    public Slider eHealthBar;

    void Awake()
    {
        int healthMultiplier = FindObjectOfType<UIController>().score / 2000;
        enemyMaxHealth *= (healthMultiplier + 1);
        enemyCurHealth = enemyMaxHealth;
        //eHealthBar = FindObjectOfType<Slider>();
        eHealthBar.maxValue = enemyMaxHealth;
    }

    void Update()
    {
        if (eHealthBar.value != enemyCurHealth)
        {
            eHealthBar.value = enemyCurHealth;
        }
        if (enemyCurHealth <= 0f)
        {
            PowerUpCheck();
            if (FindObjectOfType<PlayerHealth>())
            {
                //if (GameObject.Find("EnemySpawnerRight").GetComponent<EnemySpawner>().lose == false)
                //{
                if(FindObjectOfType<PlayerHealth>().playerCurHealth > 0) { 
                    if (enemyType == "medium")
                    {
                        FindObjectOfType<UIController>().score += 10;
                        if (FindObjectOfType<LevelData>().selectedLevel == 0)
                        {
                            FindObjectOfType<SettingsData>().mediumSDefeated += 1;
                        }
                    }
                    else if (enemyType == "large")
                    {
                        FindObjectOfType<UIController>().score += 15;
                        if (FindObjectOfType<LevelData>().selectedLevel == 0)
                        {
                            FindObjectOfType<SettingsData>().largeSDefeated += 1;
                        }
                    }
                    else if (enemyType == "small")
                    {
                        FindObjectOfType<UIController>().score += 5;
                        if (FindObjectOfType<LevelData>().selectedLevel == 0)
                        {
                            FindObjectOfType<SettingsData>().smallSDefeated += 1;
                        }
                    }
                    else if (enemyType == "boss")
                    {
                        if (gameObject.name == "LeftTurret")
                        {
                            gameObject.transform.parent.GetComponent<BossAI>().leftTurret = false;
                            FindObjectOfType<UIController>().score += 250;
                        }
                        else if (gameObject.name == "CommandBridge")
                        {
                            gameObject.transform.parent.GetComponent<BossAI>().commandBridge = false;
                            FindObjectOfType<UIController>().score += 500;
                        }
                        else if (gameObject.name == "RightTurret")
                        {
                            gameObject.transform.parent.GetComponent<BossAI>().rightTurret = false;
                            FindObjectOfType<UIController>().score += 250;
                        }
                    }
                }
            }

            GameObject x = Instantiate(explosion, transform.position, transform.rotation);
            x.GetComponent<AudioSource>().volume = FindObjectOfType<SettingsData>().sfxVol;
            var pSS = x.GetComponent<ParticleSystem>().main;
            if (enemyType == "medium")
            {
                pSS.startSpeed = new ParticleSystem.MinMaxCurve(0.1f, 1.0f);
            }
            else if (enemyType == "large")
            {
                pSS.startSpeed = new ParticleSystem.MinMaxCurve(0.1f, 2.0f);
            }
            else if (enemyType == "small")
            {
                pSS.startSpeed = new ParticleSystem.MinMaxCurve(0.1f, 0.25f);
            }
            else if (enemyType == "boss")
            {
                if (gameObject.name == "CommandBridge")
                {
                    pSS.startSpeed = new ParticleSystem.MinMaxCurve(0.1f, 4.0f);
                    pSS.duration = 4f;
                    pSS.maxParticles = 1000;
                    var emmission = x.GetComponent<ParticleSystem>().emission;
                    emmission.SetBurst(0, new ParticleSystem.Burst(0f, new ParticleSystem.MinMaxCurve(200f, 250f)));
                }
            }

            Destroy(gameObject);
        }
    }

    void PowerUpCheck()
    {
        if(Random.Range(0.0f, 1.0f) < 0.1f) //1f)
        {
            GameObject p = Instantiate(powerUp, transform.position, transform.rotation);
            p.GetComponent<AudioSource>().volume = FindObjectOfType<SettingsData>().sfxVol;
        }
    }
}
