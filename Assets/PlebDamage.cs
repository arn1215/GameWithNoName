using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlebDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public long damage;

    public PlayerHealth playerHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            damage = 10;
            playerHealth.TakeDamage(10);
        }
    }
}
