using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    public bool endlessL = false;    
    public bool endlessR = true;
    public bool endlessC = false; 

    public int selectedLevel = 0;

    public float timeFactor = 1f;

    public bool activeL = false;
    public bool activeR = false;
    public bool activeC = false;

    public float[,] selectedDataL;
    public float[,] selectedDataR;
    public float[,] selectedDataC;

    public bool randomSide = false;
    public bool randomPath = false;

    // PATHS: A:1, B:2, C:3, D:4, E:5, F:6

    public float[,] levelDataL1 = new float[,] { { 0, 5, 1 }, { 0, 6, 1 }, { 0, 7, 1 }, { 0, 15, 2 }, { 0, 18, 3 }, { 0, 22, 4}, { 0, 23, 5} }; //LEFT SPAWNER: enemyType, enemyTime, enemyPath          1
    public float[,] levelDataR1 = new float[,] { { 0, 10, 1 }, { 0, 11, 1 }, { 0, 12, 1 }, { 0, 15, 2 }, { 0, 18, 3 }, { 0, 22, 4 }, { 0, 23, 5 } }; //RIGHT SPAWNER: enemyType, enemyTime, enemyPath

    public float[,] levelDataL2 = new float[,] { { 0, 5, 1 }, { 0, 6, 1 }, { 0, 7, 1 }, { 0, 8, 1 }, { 1, 15, 4 }, { 0, 16, 4 }, { 0, 17, 4 }, { 0, 18, 4 } }; //LEFT SPAWNER: enemyType, enemyTime, enemyPath           2
    public float[,] levelDataR2 = new float[,] { { 0, 5, 1 }, { 0, 6, 1 }, { 0, 7, 1 }, { 0, 8, 1 }, { 1, 25, 4 }, { 0, 26, 4 }, { 0, 27, 4 }, { 0, 28, 4 } }; //RIGHT SPAWNER: enemyType, enemyTime, enemyPath

    public float[,] levelDataL3 = new float[,] { { 0, 5, 1 }, { 0, 8, 1 }, { 2, 8, 1 }, { 0, 13, 1 }, { 0, 14, 1 }, { 2, 15, 1 }, { 2, 16, 1 }, { 2, 23, 5 }, { 2, 25, 5 }, { 2, 26, 5 } }; //LEFT SPAWNER: enemyType, enemyTime, enemyPath          3
    public float[,] levelDataR3 = new float[,] { { 0, 5, 1 }, { 0, 8, 1 }, { 2, 8, 1 }, { 0, 13, 1 }, { 0, 14, 1 }, { 2, 15, 1 }, { 2, 16, 1 }, { 2, 22, 5 }, { 2, 24, 5}, { 2, 26, 5} }; //RIGHT SPAWNER: enemyType, enemyTime, enemyPath

    public float[,] levelDataL4 = new float[,] { { 0, 5, 3 }, { 0, 7, 3 }, { 0, 9, 3 }, { 2, 10, 5 }, { 2, 11, 3 }, { 2, 11.5f, 3 }, { 2, 12, 3 }, { 2, 12.5f, 3 }, { 2, 13, 3 }, { 2, 13.5f, 3 }, { 0, 14, 5 } }; //LEFT SPAWNER: enemyType, enemyTime, enemyPath          4
    public float[,] levelDataR4 = new float[,] { { 0, 5, 3 }, { 0, 7, 3 }, { 0, 9, 3 }, { 2, 10, 5 }, { 2, 11, 3 }, { 2, 11.5f, 3 }, { 2, 12, 3 }, { 2, 12.5f, 3 }, { 2, 13, 3 }, { 2, 13.5f, 3 }, { 0, 14, 5 } }; //RIGHT SPAWNER: enemyType, enemyTime, enemyPath

    public float[,] levelDataL5 = new float[,] { { 0, 5, 1 }, { 1, 6, 1 }, { 2, 7, 1 }, { 0, 11, 2 }, { 1, 12, 2 }, { 2, 13, 2 }, { 0, 17, 3 }, { 1, 18, 3 }, { 2, 19, 3 }, { 0, 23, 4 }, { 1, 24, 4 }, { 2, 25, 4 } }; //LEFT SPAWNER: enemyType, enemyTime, enemyPath          5
    public float[,] levelDataR5 = new float[,] { { 0, 8, 1 }, { 1, 9, 1 }, { 2, 10, 1 }, { 0, 14, 2 }, { 1, 15, 2 }, { 2, 16, 3 }, { 0, 20, 3 }, { 1, 21, 3 }, { 2, 22, 3 }, { 0, 26, 4 }, { 1, 27, 4 }, { 2, 28, 4 } }; //RIGHT SPAWNER: enemyType, enemyTime, enemyPath

    public float[,] levelDataL6 = new float[,] { { 2, 5, 1 }, { 2, 8, 1 }, { 2, 9, 1 }, { 2, 12, 1 }, { 2, 13, 1 }, { 2, 14, 1 }, { 2, 17, 1 }, { 2, 18, 1 }, { 2, 19, 1 }, { 2, 20, 1 }, { 2, 23, 1 }, { 2, 24, 1 }, { 2, 25, 1 }, { 2, 26, 1 }, { 2, 27, 1 } }; //LEFT SPAWNER: enemyType, enemyTime, enemyPath          6
    public float[,] levelDataR6 = new float[,] { { 2, 10, 5 }, { 2, 20, 5 }, { 2, 30, 5 }, { 2, 35, 5 } }; //RIGHT SPAWNER: enemyType, enemyTime, enemyPath

    public float[,] levelDataL7 = new float[,] { { 1, 5, 1 }, { 1, 8, 5 }, { 2, 9, 2 }, { 1, 12, 5 }, { 1, 14, 1 }, { 2, 15, 5 }, { 2, 16, 2 }, { 2, 18, 1 }, { 2, 20, 1 }, { 2, 22, 1 }, { 2, 34, 3 }, { 2, 35, 3 }, { 2, 36, 3 }, { 2, 37, 3 }, { 1, 38, 3 } }; //LEFT SPAWNER: enemyType, enemyTime, enemyPath          7
    public float[,] levelDataR7 = new float[,] { { 1, 5, 1 }, { 1, 8, 5 }, { 2, 9, 2 }, { 1, 12, 5 }, { 1, 14, 1 }, { 2, 15, 5 }, { 2, 16, 2 }, { 2, 26, 1 }, { 2, 28, 1 }, { 2, 30, 1 }, { 2, 34, 3 }, { 2, 35, 3 }, { 2, 36, 3 }, { 2, 37, 3 }, { 1, 38, 3 } }; //RIGHT SPAWNER: enemyType, enemyTime, enemyPath

    public float[,] levelDataL8 = new float[,] { { 1, 5, 4 }, { 0, 8, 4 }, { 0, 11, 1 }, { 2, 12, 2 }, { 2, 12.5f, 2 }, { 1, 13, 3 }, { 2, 13, 2 }, { 2, 13.5f, 2 }, { 0, 14, 1 }, { 2, 14, 2 }, { 2, 14.5f, 2 }, { 1, 15, 2 }, { 2, 15, 2 }, { 2, 15.5f, 2 }, { 0, 16, 5 }, { 2, 16, 2 }, { 2, 16.5f, 2 } }; //LEFT SPAWNER: enemyType, enemyTime, enemyPath          8
    public float[,] levelDataR8 = new float[,] { { 0, 5, 4 }, { 1, 8, 4 }, { 0, 11, 1 }, { 2, 12, 2 }, { 2, 12.5f, 2 }, { 0, 13, 3 }, { 2, 13, 2 }, { 2, 13.5f, 2 }, { 1, 14, 1 }, { 2, 14, 2 }, { 2, 14.5f, 2 }, { 0, 15, 2 }, { 2, 15, 2 }, { 2, 15.5f, 2 }, { 1, 16, 5 }, { 2, 16, 2 }, { 2, 16.5f, 2 } }; //RIGHT SPAWNER: enemyType, enemyTime, enemyPath

    public float[,] levelDataL9 = new float[,] { { 3, 1, 6 } }; //LEFT SPAWNER: enemyType, enemyTime          9
    public float[,] levelDataR9 = new float[,] { { 3, 1, 6 } }; //RIGHT SPAWNER: enemyType, enemyTime
    public float[,] levelDataC9 = new float[,] { { 3, 1, 6 } }; //CENTRE SPAWNER: enemyType, enemyTime

    public void LevelSelect(int levelNum)
    {
        //Debug.Log("lN: " + levelNum);
        if (levelNum == 0)
        {
            endlessL = false;            
            endlessR = true;
            endlessC = false;
            selectedDataL = null;
            selectedDataR = null;
            selectedDataC = null;
            timeFactor = 1f;
            activeL = false;
            activeR = true;
            activeC = false;
            randomSide = true;
            randomPath = true;
            selectedLevel = 0;
        }
        else if (levelNum == 1)
        {
            endlessL = false;            
            endlessR = false;
            endlessC = false;
            selectedDataL = levelDataL1;
            selectedDataR = levelDataR1;
            selectedDataC = null;
            timeFactor = 1f;
            activeL = true;
            activeR = true;
            activeC = false;
            randomSide = false;
            randomPath = false;
            selectedLevel = 1;
        }
        else if(levelNum == 2)
        {
            endlessL = false;            
            endlessR = false;
            endlessC = false;
            selectedDataL = levelDataL2;
            selectedDataR = levelDataR2;
            selectedDataC = null;
            timeFactor = 1f;
            activeL = true;
            activeR = true;
            activeC = false;
            randomSide = false;
            randomPath = false;
            selectedLevel = 2;
        }
        else if (levelNum == 3)
        {
            endlessL = false;            
            endlessR = false;
            endlessC = false;
            selectedDataL = levelDataL3;
            selectedDataR = levelDataR3;
            selectedDataC = null;
            timeFactor = 1f;
            activeL = true;
            activeR = true;
            activeC = false;
            randomSide = false;
            randomPath = false;
            selectedLevel = 3;
        }
        else if (levelNum == 4)
        {
            endlessL = false;            
            endlessR = false;
            endlessC = false;
            selectedDataL = levelDataL4;
            selectedDataR = levelDataR4;
            selectedDataC = null;
            timeFactor = 1f;
            activeL = true;
            activeR = true;
            activeC = false;
            randomSide = false;
            randomPath = false;
            selectedLevel = 4;
        }
        else if (levelNum == 5)
        {
            endlessL = false;            
            endlessR = false;
            endlessC = false;
            selectedDataL = levelDataL5;
            selectedDataR = levelDataR5;
            selectedDataC = null;
            timeFactor = 1f;
            activeL = true;
            activeR = true;
            activeC = false;
            randomSide = false;
            randomPath = false;
            selectedLevel = 5;
        }
        else if (levelNum == 6)
        {
            endlessL = false;           
            endlessR = false;
            endlessC = false;
            selectedDataL = levelDataL6;
            selectedDataR = levelDataR6;
            selectedDataC = null;
            timeFactor = 1f;
            activeL = true;
            activeR = true;
            activeC = false;
            randomSide = false;
            randomPath = false;
            selectedLevel = 6;
        }
        else if (levelNum == 7)
        {
            endlessL = false;           
            endlessR = false;
            endlessC = false;
            selectedDataL = levelDataL7;
            selectedDataR = levelDataR7;
            selectedDataC = null;
            timeFactor = 1f;
            activeL = true;
            activeR = true;
            activeC = false;
            randomSide = false;
            randomPath = false;
            selectedLevel = 7;
        }
        else if (levelNum == 8)
        {
            endlessL = false;            
            endlessR = false;
            endlessC = false;
            selectedDataL = levelDataL8;
            selectedDataR = levelDataR8;
            selectedDataC = null;
            timeFactor = 1f;
            activeL = true;
            activeR = true;
            activeC = false;
            randomSide = false;
            randomPath = false;
            selectedLevel = 8;
        }
        else if (levelNum == 9)
        {
            endlessL = true;           
            endlessR = true;
            endlessC = false;
            selectedDataL = null;
            selectedDataR = null;
            selectedDataC = levelDataC9;
            timeFactor = 0.5f;
            activeL = true;
            activeR = true;
            activeC = true;
            randomSide = false;
            randomPath = false;
            selectedLevel = 9;
        }
    }
}
