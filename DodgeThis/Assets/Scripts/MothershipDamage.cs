using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothershipDamage : MonoBehaviour
{
    PlayerHealth pH;
    void Start()
    {
        pH = FindObjectOfType<PlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            pH.playerCurHealth -= collision.gameObject.GetComponent<EnemyStats>().enemyCurHealth;
            collision.gameObject.GetComponent<EnemyStats>().enemyCurHealth = 0;
        }
    }
}
