using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerManager : MonoBehaviour
{
    public EnemySpawner spawnerL;
    public EnemySpawner spawnerC;
    public EnemySpawner spawnerR;

    public GameObject youWinPopup;

    bool done = false;

    bool L = false;
    bool C = false;
    bool R = false;

    // Start is called before the first frame update
    void Start()
    {
        if(spawnerL.active == true)
        {
            L = true;
        }
        if (spawnerC.active == true)
        {
            C = true;
        }
        if (spawnerR.active == true)
        {
            R = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (done == false)
        {
            if ((L == false || (L == true && spawnerL.win == true)) && (C == false || (C == true && spawnerC.win == true)) && (R == false || (R == true && spawnerR.win == true)))
            {
                youWinPopup.SetActive(true);
                if(FindObjectOfType<LevelData>().selectedLevel == 9)
                {
                    youWinPopup.transform.GetChild(3).gameObject.SetActive(false);
                }
                FindObjectOfType<UIController>().scoreText.fontSizeMax = 500;
                if(FindObjectOfType<LevelData>().selectedLevel == 9 && FindObjectOfType<SettingsData>().skinsUnlocked[1] == false)
                {
                    FindObjectOfType<SettingsData>().UnlockCustomise(1); //UNLOCK SKIN 1
                }
                FindObjectOfType<SettingsData>().SaveGame();
                done = true;
            }
        }
    }
}
