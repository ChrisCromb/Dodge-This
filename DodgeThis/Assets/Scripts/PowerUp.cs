using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public string[] powerUps = { "repairKit", "expansionKit", "shootSpeed", "projSpeed", "projDamage", "moveSpeed", "doubleShot", "tripleShot" };
    public SpriteRenderer icon;
    public Sprite[] powerUpIcons = { };

    public AudioClip[] powerUpSfx = { };
    public SpriteRenderer bubble;
    public GameObject sfxPrefab;

    public int power = 0;
    void Awake()
    {
        power = Random.Range(0, powerUps.Length);
        icon.sprite = powerUpIcons[power];
        if(power == 0 || power == 1)
        {
            bubble.color = new Vector4(0f, 1f, 0f, 0.5f);
            GetComponent<AudioSource>().clip = powerUpSfx[0];
        }
        else if(power == 2 || power == 3 || power == 4 || power == 5)
        {
            bubble.color = new Vector4(1f, 0.5f, 0f, 0.5f);
            GetComponent<AudioSource>().clip = powerUpSfx[0];
        }
        else if(power == 6 || power == 7)
        {
            bubble.color = new Vector4(1f, 1f, 0f, 0.5f);
            GetComponent<AudioSource>().clip = powerUpSfx[1];
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.up * 1 * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("HIT!");
        if (collision.CompareTag("Player"))
        {
            if(power == 0) //Heal by half of your max health
            {
                if(collision.gameObject.GetComponent<PlayerHealth>().playerCurHealth + (int)(collision.gameObject.GetComponent<PlayerHealth>().playerMaxHealth / 2) > collision.gameObject.GetComponent<PlayerHealth>().playerMaxHealth)
                {
                    collision.gameObject.GetComponent<PlayerHealth>().playerCurHealth = collision.gameObject.GetComponent<PlayerHealth>().playerMaxHealth;
                }
                else
                {
                    collision.gameObject.GetComponent<PlayerHealth>().playerCurHealth += (int)(collision.gameObject.GetComponent<PlayerHealth>().playerMaxHealth / 2);
                }
                GetComponent<AudioSource>().clip = powerUpSfx[0];
            }

            if (power == 1) //Upgrade max health and heal for the upgraded amount
            {
                collision.gameObject.GetComponent<PlayerHealth>().playerMaxHealth += 5;
                collision.gameObject.GetComponent<PlayerHealth>().playerCurHealth += 5;
            }

            if (power == 2) //Upgrade the amount of bullets shot per second
            {
                collision.gameObject.GetComponent<PlayerShooting>().shootSpeed -= 0.025f;
            }

            if (power == 3) //Upgrade the movement speed of bullets
            {
                collision.gameObject.GetComponent<PlayerShooting>().projSpeed += 0.25f;
            }

            if (power == 4) //Upgrade the damage of bullet hits
            {
                collision.gameObject.GetComponent<PlayerShooting>().projDamage += 0.25f;
            }

            if (power == 5) //Upgrade the movement speed of the player ship
            {
                collision.gameObject.GetComponent<PlayerMovement>().moveSpeed += 0.25f;
            }

            if (power == 6) //Upgrade the amount of bullets fired at once to two
            {
                collision.gameObject.GetComponent<PlayerShooting>().DoubleShot();
            }

            if (power == 7) //Upgrade the amount of bullets fired at once to three
            {
                collision.gameObject.GetComponent<PlayerShooting>().TripleShot();
            }

            //Instantiate
            GameObject sfx = Instantiate(sfxPrefab, transform.position, transform.rotation);
            //sfx.GetComponent<AudioSource>().clip = GetComponent<AudioSource>().clip;
            sfx.GetComponent<AudioSource>().volume = GetComponent<AudioSource>().volume;
            sfx.GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
            Destroy(sfx, 1f);

            Destroy(gameObject);
        }
    }
}
