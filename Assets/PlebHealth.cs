using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlebHealth : MonoBehaviour
{
    public int maxHealth = 100;

    public int health;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TakeDamage(int damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            Destroy (gameObject);
        }
    }
}
