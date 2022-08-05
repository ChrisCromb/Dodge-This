using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStats : MonoBehaviour
{
    public bool player = true;

    public float projSpeed = 1f;
    public float projDamage = 1f;

    public bool explode = false;

    public Sprite[] sprites;
    public GameObject bullet;

    float timer = 1f;

    //Rigidbody2D rB;

    void Start()
    {
        //rB = GetComponent<Rigidbody2D>();
        if (player)
        {
            //gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.green;
            gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites[0];
            gameObject.transform.GetChild(0).rotation = gameObject.transform.GetChild(0).rotation * Quaternion.Euler(0, 0, 90);
        }
        else
        {
            //gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
            gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites[1];
            gameObject.transform.GetChild(0).rotation = gameObject.transform.GetChild(0).rotation * Quaternion.Euler(0, 0, -90);
        }
    }

    void Update()
    {
        if(explode == true && timer > 0)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                Shoot(0f);
                Shoot(45f);
                Shoot(90f);
                Shoot(135f);
                Shoot(180f);
                Shoot(225f);
                Shoot(270f);
                Shoot(315f);
                Destroy(gameObject);
            }
        }
        
        if (player)
        {
            transform.position += transform.up * 10 * projSpeed * Time.deltaTime;
        }
        else
        {
            transform.position += -transform.up * 10 * projSpeed * Time.deltaTime;
        }

        //rB.AddForce(Vector3.up * projSpeed);
        //rB.velocity = new Vector2(0, 50 * projSpeed);

        if (transform.position.y > 5.0f || transform.position.y < -5.0f || transform.position.x < -2.5f || transform.position.x > 2.5f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("HIT!");
        if (player)
        {
            if (collision.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<EnemyStats>().enemyCurHealth -= projDamage;
                Destroy(gameObject);
            }
        }
        else
        {
            if (collision.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<PlayerHealth>().playerCurHealth -= projDamage;
                Destroy(gameObject);
            }
            /*else if(collision.CompareTag("Mothership"))
            {
                //Debug.Log("HIT MSHIP");
                //collision.gameObject.GetComponent<PlayerHealth>().playerCurHealth -= projDamage;
                Destroy(gameObject);
            }*/
        }
    }

    void Shoot(float rot)
    {
        GameObject b = Instantiate(bullet, transform.position, transform.rotation);
        b.GetComponent<BulletStats>().player = false;
        b.GetComponent<BulletStats>().projSpeed = projSpeed;
        b.GetComponent<BulletStats>().projDamage = projDamage;
        b.transform.rotation = Quaternion.Euler(0, 0, rot);
    }
}
