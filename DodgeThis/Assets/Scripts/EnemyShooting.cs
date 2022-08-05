using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public float timer = 0f;

    public GameObject bullet;

    string eType = "";

    void Start()
    {
        timer += Random.Range(0f, 1f);
        eType = gameObject.GetComponent<EnemyStats>().enemyType;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 3)
        {
            if (eType == "medium")
            {
                Shoot();
            }
            
            if(eType == "large")
            {
                Shoot(new Vector3 (-0.2f, 0f, 0f));
                Shoot();                
                Shoot(new Vector3(0.2f, 0f, 0f));
            }
            if (eType == "boss")
            {
                Shoot();
            }
            timer = 0;
            timer += Random.Range(0f, 1f);
        }
    }

    void Shoot() 
    {
        GameObject b = Instantiate(bullet, transform.position, transform.rotation);
        b.GetComponent<BulletStats>().player = false;
        b.GetComponent<BulletStats>().projSpeed = gameObject.GetComponent<EnemyStats>().enemyProjSpeed;
        b.GetComponent<BulletStats>().projDamage = gameObject.GetComponent<EnemyStats>().enemyProjDamage;
    }

    void Shoot(Vector3 offset)
    {
        GameObject b = Instantiate(bullet, transform.position + offset, transform.rotation);
        b.GetComponent<BulletStats>().player = false;
        b.GetComponent<BulletStats>().projSpeed = gameObject.GetComponent<EnemyStats>().enemyProjSpeed;
        b.GetComponent<BulletStats>().projDamage = gameObject.GetComponent<EnemyStats>().enemyProjDamage;
    }
}
