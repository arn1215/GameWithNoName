using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public long maxHealth = 100;

    public long health;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TakeDamage(long damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            Destroy (gameObject);
        }
    }
}
