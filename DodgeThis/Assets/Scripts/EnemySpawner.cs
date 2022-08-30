using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;

    public List<int> enemyType;

    public List<float> enemyTime;

    public List<float> enemyPath;

    public float timer = 0f;

    public float timeFactor = 1f;

    int enemyCounter = 0;
    int amountOfEnemies = 0;

    public bool mirrored = false;

    public GameObject[] paths;

    public bool endlessMode = false;
    public bool randomSide = false;
    public bool randomPath = true;
    public bool active = false;
    int endlessTracker = 1;

    public GameObject youWinPopup;

    public bool win = false;
    public bool lose = false;

    int movementSmall = 1;
    int movementMedium = 1;
    int movementLarge = 1;

    void Awake()
    {
        LevelData lD = FindObjectOfType<LevelData>();
        timeFactor = lD.timeFactor;
        randomSide = lD.randomSide;
        if (gameObject.name == "EnemySpawnerLeft") 
        {
            endlessMode = lD.endlessL;
            if (lD.activeL)
            {
                active = true;
            }
            else
            {
                active = false;
            }
            if (endlessMode == false && active)
            {
                int typeCounter = 0;
                foreach (float type in lD.selectedDataL) //Load enemyType data LEFT
                {
                    if (typeCounter % 3 == 0)
                    {
                        enemyType.Add((int)type);
                    }
                    typeCounter++;
                }

                int timeCounter = 0;
                foreach (float time in lD.selectedDataL) //Load enemyTime data LEFT
                {
                    if (timeCounter % 3 == 1)
                    {
                        enemyTime.Add(time);
                    }
                    timeCounter++;
                }

                int pathCounter = 0;
                foreach (float path in lD.selectedDataL) //Load enemyPath data CENTRE
                {
                    if (pathCounter % 3 == 2)
                    {
                        enemyPath.Add(path);
                    }
                    pathCounter++;
                }
            }
            movementSmall = Random.Range(4, 5);
            movementMedium = Random.Range(1, 3);
            movementLarge = Random.Range(1, 2);
            //Debug.Log("s:" + movementSmall + " m:" + movementMedium + " l:" + movementLarge);
        }
        else if (gameObject.name == "EnemySpawnerRight")
        {
            endlessMode = lD.endlessR;
            if (lD.activeR)
            {
                active = true;
            }
            else
            {
                active = false;
            }
            if (endlessMode == false && active)
            {
                int typeCounter = 0;
                foreach (float type in lD.selectedDataR) //Load enemyType data RIGHT
                {
                    if (typeCounter % 3 == 0)
                    {
                        enemyType.Add((int)type);
                    }
                    typeCounter++;
                }

                int timeCounter = 0;
                foreach (float time in lD.selectedDataR) //Load enemyTime data RIGHT
                {
                    if (timeCounter % 3 == 1)
                    {
                        enemyTime.Add(time);
                    }
                    timeCounter++;
                }

                int pathCounter = 0;
                foreach (float path in lD.selectedDataR) //Load enemyPath data CENTRE
                {
                    if (pathCounter % 3 == 2)
                    {
                        enemyPath.Add(path);
                    }
                    pathCounter++;
                }
            }
        }
        else if (gameObject.name == "EnemySpawnerCentre")
        {
            endlessMode = lD.endlessC;
            if (lD.activeC)
            {
                active = true;
            }
            else
            {
                active = false;
            }
            if (endlessMode == false && active)
            {
                int typeCounter = 0;
                foreach (float type in lD.selectedDataC) //Load enemyType data CENTRE
                {
                    if (typeCounter % 3 == 0)
                    {
                        enemyType.Add((int)type);
                    }
                    typeCounter++;
                }

                int timeCounter = 0;
                foreach (float time in lD.selectedDataC) //Load enemyTime data CENTRE
                {
                    if (timeCounter % 3 == 1)
                    {
                        enemyTime.Add(time);
                    }
                    timeCounter++;
                }

                int pathCounter = 0;
                foreach (float path in lD.selectedDataC) //Load enemyPath data CENTRE
                {
                    if (pathCounter % 3 == 2)
                    {
                        enemyPath.Add(path);
                    }
                    pathCounter++;
                }
            }
        }

    }

    void Start()
    {
        amountOfEnemies = enemyType.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if(amountOfEnemies != enemyCounter)
        {
            timer += Time.deltaTime;
            if(enemyTime[enemyCounter] <= timer)
            {
                GameObject e = Instantiate(enemies[enemyType[enemyCounter]], transform.position, transform.rotation);
                if (mirrored)
                {
                    e.GetComponent<EnemyMovement>().mirrored = true;
                }
                e.GetComponent<EnemyMovement>().SetPath(paths[(int)enemyPath[enemyCounter] - 1], enemyPath[enemyCounter]);
                enemyCounter++;
            }
        }
        else if (amountOfEnemies == enemyCounter && active && endlessMode == false)
        {
            if(GameObject.FindGameObjectWithTag("Enemy") == null && win == false && lose == false)
            {
                //youWinPopup.SetActive(true);
                win = true;
                //FindObjectOfType<UIController>().scoreText.fontSizeMax = 500;
                //FindObjectOfType<SettingsData>().SaveGame();
            }
        }

        if (endlessMode)
        {
            timer += Time.deltaTime * timeFactor;
            if(timer < 0 && FindObjectOfType<EnemyStats>() == null)
            {
                //Debug.Log("Reset timer to 0");
                timer = 0;
            }
            if (timer >= 5)
            {
                int counter = 0;
                for (int i = 0; i < endlessTracker; i++)
                {
                    if(counter > enemies.Length - 1 - 1) // MINUS 2 for the boss which does not spawn in endless
                    {
                        counter = 0;
                    }
                    string side = "";
                    if (randomSide)
                    {
                        int coinToss = Random.Range(0, 2);
                        if(coinToss == 0)
                        {
                            side = "left";
                        }
                        else if(coinToss == 1)
                        {
                            side = "right";
                        }
                    }
                    Vector3 pos = new Vector3(transform.position.x, transform.position.y + i, 0);
                    if (randomSide == true && side == "left")
                    {
                        pos = new Vector3(pos.x * -1, pos.y, 0);                        
                    }
                    GameObject e = Instantiate(enemies[counter], pos, transform.rotation);
                    if (mirrored || (randomSide == true && side == "left"))
                    {
                       e.GetComponent<EnemyMovement>().mirrored = true;
                    }
                    if (randomPath)
                    {
                        if (e.GetComponent<EnemyStats>().enemyType == "small")
                        {
                            e.GetComponent<EnemyMovement>().SetPath(paths[movementSmall - 1], movementSmall);
                        }
                        else if (e.GetComponent<EnemyStats>().enemyType == "medium")
                        {
                            e.GetComponent<EnemyMovement>().SetPath(paths[movementMedium - 1], movementMedium);
                        }
                        else if (e.GetComponent<EnemyStats>().enemyType == "large")
                        {
                            e.GetComponent<EnemyMovement>().SetPath(paths[movementLarge - 1], movementLarge);
                        }
                    }
                    counter++;
                }
                endlessTracker++;
                timer = 0 - endlessTracker * 1.5f;
                movementSmall = Random.Range(4, 6);
                movementMedium = Random.Range(1, 4);
                movementLarge = Random.Range(1, 3);
                //Debug.Log("s:" + movementSmall + " m:" + movementMedium + " l:" + movementLarge);
            }
        }
        //Debug.Log(amountOfEnemies + ", " + enemyCounter);
    }
}
