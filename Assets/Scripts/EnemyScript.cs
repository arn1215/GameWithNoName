using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Rigidbody2D rigidBody;

    public float moveSpeed;

    public float rangeToChasePlayer;

    private Vector3 moveDirection;

    public Animator anim;

    public int health = 100;

    public float forceAmount = 10f; // Adjust this value to control the strength of the force

    public float distanceThreshold = 1f;

    public AudioSource enemyHit;
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (
            Vector3
                .Distance(transform.position,
                Character2DController.instance.transform.position) <
            rangeToChasePlayer
        )
        {
            moveDirection =
                Character2DController.instance.transform.position -
                transform.position;
        }
        moveDirection.Normalize();

        rigidBody.velocity = moveDirection * moveSpeed;

        if (rigidBody.velocity.x > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (moveDirection != Vector3.zero)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

        float distance =
            Vector2
                .Distance(transform.position,
                Character2DController.instance.transform.position);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // LilyHealth.instance.DamagePlayer();
            LilyHealth.instance.DamagePlayer();

            // Calculate the direction of the force
            Vector2 forceDirection =
                (
                Character2DController.instance.transform.position -
                transform.position
                ).normalized;

            // Apply the force to the object
            rigidBody.AddForce(-forceDirection * forceAmount);
        }
    }

    public void DamageEnemy(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            KillCount.count += 1;
            enemyHit.Play();
      
            Destroy (gameObject);
        }

    }
}
