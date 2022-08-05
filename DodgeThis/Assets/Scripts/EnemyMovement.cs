using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] target;
    float enemySpeed = 1f;
    float speedFactor = 1.0f;
    int current = 0;

    public int loopCount = 0;

    public GameObject path;

    public int heightFactor = 2;
    public int loopStart = 5;

    public bool mirrored = false;

    float time = 0f;

    Vector3 p1;
    Vector3 p2;

    // PATH A: LENGTH - 13; HEIGHT FACTOR - 2; LOOP START - 5 //ZIGZAG
    // PATH B: LENGTH - 2; HEIGHT FACTOR - 2; LOOP START - 0 //FAST ZIGZAG
    // PATH C: LENGTH - 24; HEIGHT FACTOR - 4; LOOP START - 0 //LOOP DE LOOP
    // PATH D: LENGTH - 2; HEIGHT FACTOR - 8; LOOP START - 0 //DOWN
    // PATH E: LENGTH - 6; HEIGHT FACTOR - 2; LOOP START - 0 //DODGE
    // PATH F: LENGTH - 4; HEIGHT FACTOR - 1; LOOP START - 0 //BOSS

    void Start()
    {
        target = new Transform[path.transform.childCount];
        for (int i = 0; i < path.transform.childCount; i++)
        {
            target[i] = path.transform.GetChild(i);
        }
        enemySpeed = gameObject.GetComponent<EnemyStats>().enemyMoveSpeed;
        p1 = transform.position;
        /*Vector3 heightAdjust;
        if (!mirrored)
        {
            heightAdjust = new Vector3(target[current].position.x, target[current].position.y - (loopCount * heightFactor), 0);
        }
        else
        {
            heightAdjust = new Vector3(-target[current].position.x, target[current].position.y - (loopCount * heightFactor), 0);
        }*/
        p2 = transform.position - new Vector3(0, 1, 0);
    }

    void Update()
    {
        //Vector3 heightAdjust;
        time += Time.deltaTime * speedFactor * enemySpeed;
        //Debug.Log("Time: " + time);
        /*if (!mirrored)
        {
            heightAdjust = new Vector3(target[current].position.x, target[current].position.y - (loopCount * heightFactor), 0);
        }
        else
        {
            heightAdjust = new Vector3(-target[current].position.x, target[current].position.y - (loopCount * heightFactor), 0);
        }*/
        
        /*
        if (transform.position != heightAdjust) //target[current].position)
        {
            //Vector3 heightAdjust = new Vector3(target[current].position.x, target[current].position.y - (loopCount * 2), 0);


            //Vector3 pos = Vector3.MoveTowards(transform.position, heightAdjust, enemySpeed * 2 * Time.deltaTime);
            //GetComponent<Rigidbody2D>().MovePosition(pos);

            transform.position = Vector3.Lerp(new Vector3(2, 5, 0), heightAdjust, time);
        }
        else
        {
            //current = (current + 1) % target.Length;
            current = (current + 1);
            if(current == target.Length)
            {
                current = 0;
                loopCount++;
            }

            if(loopCount > 0)
            {
                if(current < loopStart)
                {
                    current = loopStart;        
                }
            }
        }
        */

        if (time >= 1.0f)
        {
            time -= 1.0f;
            if(transform.position.y > 4.75f)
            {
                p1 = p2;
                p2 = p1 - new Vector3(0, 1, 0);
            }
            else
            {
                SetNextPath(p2);
            }
            
        }

        transform.position = Vector3.Lerp(p1, p2, time);

        //Debug.Log("P1: " + p1 + "  P2: " + p2);
    }

    void SetNextPath(Vector3 hA)
    {
        // get next segment of points (p1,p2)

        current = (current + 1);
        if (current == target.Length)
        {
            current = 0;
            loopCount++;
        }

        if (loopCount > 0)
        {
            if (current < loopStart)
            {
                current = loopStart;
            }
        }

        p1 = hA;

        Vector3 heightAdjust;
        if (!mirrored)
        {
            heightAdjust = new Vector3(target[current].position.x, target[current].position.y - (loopCount * heightFactor), 0);
        }
        else
        {
            heightAdjust = new Vector3(-target[current].position.x, target[current].position.y - (loopCount * heightFactor), 0);
        }
        p2 = heightAdjust;

        float distance = (p1 - p2).magnitude; // distance between current segment
        speedFactor = (1.0f / distance); // 10.0f is some custom factor
    }

    public void SetPath(GameObject p, float pathNum)
    {
        path = p;
        if(pathNum == 1)
        {
            heightFactor = 2;
            loopStart = 5;
        }
        if (pathNum == 2)
        {
            heightFactor = 2;
            loopStart = 0;
        }
        if (pathNum == 3)
        {
            heightFactor = 4;
            loopStart = 0;
        }
        if (pathNum == 4)
        {
            heightFactor = 8;
            loopStart = 0;
        }
        if (pathNum == 5)
        {
            heightFactor = 2;
            loopStart = 0;
        }
        if (pathNum == 6)
        {
            heightFactor = 0;
            loopStart = 0;
        }
    }
}
