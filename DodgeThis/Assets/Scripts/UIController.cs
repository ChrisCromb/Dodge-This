using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider pHealthBar;
    public PlayerHealth pHealth;

    public int score = 0;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        pHealthBar.maxValue = pHealth.playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (pHealthBar.value != pHealth.playerCurHealth)
        {
            pHealthBar.value = pHealth.playerCurHealth;
        }
        if (pHealthBar.maxValue != pHealth.playerMaxHealth)
        {
            pHealthBar.maxValue = pHealth.playerMaxHealth;
        }
        if (scoreText.text != score.ToString())
        {
            scoreText.text = score.ToString();
            /*if (score < 560)
            {*/
                scoreText.fontSizeMax = score/2;
            //}
        }
    }

    public void HealthBarFade(Animator anim)
    {
        anim.Play("New State");
    }
}
