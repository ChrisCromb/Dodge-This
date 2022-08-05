using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public string ammoType = "singleShot";

    public float shootSpeed = 0.2f;
    public float projSpeed = 1f;
    public float projDamage = 1f;

    public GameObject bullet;

    float timer = 0f;
    float powerUpTimer = 0f;

    public SpriteRenderer cannon;
    public Sprite[] cannonSprites;

    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= shootSpeed)
        {
            if (ammoType == "singleShot")
            {
                Shoot();
            }

            if (ammoType == "doubleShot")
            {
                Shoot(new Vector3(-0.1f, 0f, 0f), Quaternion.Euler(0, 0, 0));
                Shoot(new Vector3(0.1f, 0f, 0f), Quaternion.Euler(0, 0, 0));
            }

            if (ammoType == "tripleShot")
            {
                Shoot(new Vector3(-0.15f, 0f, 0f), Quaternion.Euler(0, 0, 0));
                Shoot();
                Shoot(new Vector3(0.15f, 0f, 0f), Quaternion.Euler(0, 0, 0));
            }

            timer = 0f;
        }


        if (powerUpTimer > 0)
        {
            powerUpTimer -= Time.deltaTime;
        }

        if (powerUpTimer < 0 && powerUpTimer > -50) 
        {
            SingleShot();
        }
    }

    void Shoot()
    {
        GameObject b = Instantiate(bullet, transform.position, transform.rotation);
        b.GetComponent<BulletStats>().projSpeed = projSpeed;
        b.GetComponent<BulletStats>().projDamage = projDamage;
    }
    void Shoot(Vector3 offset, Quaternion rot)
    {
        GameObject b = Instantiate(bullet, transform.position + offset, transform.rotation * rot);
        b.GetComponent<BulletStats>().projSpeed = projSpeed;
        b.GetComponent<BulletStats>().projDamage = projDamage;
    }

    public void SingleShot()
    {
        ammoType = "singleShot";
        cannon.sprite = null;
        powerUpTimer = -100;
    }

    public void DoubleShot()
    {
        ammoType = "doubleShot";
        cannon.sprite = cannonSprites[0];
        powerUpTimer = 15;
    }

    public void TripleShot()
    {
        ammoType = "tripleShot";
        cannon.sprite = cannonSprites[1];
        powerUpTimer = 15;
    }
}
