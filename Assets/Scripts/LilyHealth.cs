using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilyHealth : MonoBehaviour
{
    public static LilyHealth instance;

    public int currentHealth;

    public int maxHealth;

    public AudioSource audio;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame 
    void Update()
    {
    }

    public void DamagePlayer()
    {
        currentHealth--;
        audio.Play();

        if (currentHealth <= 0)
        {
            Character2DController.instance.gameObject.SetActive(false);
        }
    }
}
