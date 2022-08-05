using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    public bool dead = false;
    public bool leftTurret = true;
    public bool commandBridge = true;
    public bool rightTurret = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (commandBridge == false)
        {
            foreach (EnemySpawner eS in FindObjectsOfType<EnemySpawner>())
            {
                eS.endlessMode = false;
            }
            
        }
        if(leftTurret == false && commandBridge == false && rightTurret == false)
        {
            dead = true;
            gameObject.GetComponent<EnemyStats>().enemyCurHealth = 0;
        }
    }
}
