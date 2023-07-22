using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LilyHealth : MonoBehaviour
{
    public static LilyHealth instance;

    public int currentHealth;

    public int maxHealth;

    public AudioSource audio;

    public GameObject deathScreen;

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
        //devtool death
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            currentHealth = 0;
            DamagePlayer();
        }

        // //devtool restart
        // if (Input.GetKeyDown(KeyCode.R))
        // {
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // }
    }

    public void DamagePlayer(int damage = 0)
    {
        //all hits will do only 1 damage unless DamagePlayer is called with the damage amount
        if (damage == 0)
        {
            currentHealth--;
        }
        else
        {
            currentHealth -= damage;
        }
        audio.Play();

        if (currentHealth <= 0)
        {
            Character2DController.instance.gameObject.SetActive(false);
            deathScreen.SetActive(true);
        }
    }

    public void HealPlayer(int healthAmount)
    {
        currentHealth += healthAmount;
    }
}
