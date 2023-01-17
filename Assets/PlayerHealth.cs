using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public long maxHealth = 100;
    public AudioSource damageSound;
    public Text healthText;

    public long health;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthText.text = health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TakeDamage(long damage)
    {
        health = health - damage;
        healthText.text = health.ToString();
        if (health <= 0)
        {
            Destroy (gameObject);
        } else {
            damageSound.Play();
        }
    }
}
