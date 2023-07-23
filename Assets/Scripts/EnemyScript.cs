using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Rigidbody2D rigidBody;

    public GameObject healthAsset;

    public float moveSpeed;

    public float rangeToChasePlayer;

    private Vector3 moveDirection;

    public Animator anim;

    public int health = 100;

    public float forceAmount = 10f; // Adjust this value to control the strength of the force

    public float distanceThreshold = 1f;

    public float dropChance;

    public AudioSource enemyHit;

    public bool isShooter;

    public GameObject projectile;

    public Transform firePoint;

    public float fireRate;

    private float fireCounter;

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
            transform.localScale = new Vector3(-0.5f, 0.5f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1f);
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

        //shooting logic
        if (isShooter)
        {
            fireCounter -= Time.deltaTime;

            if (fireCounter <= 0)
            {
                fireCounter = fireRate;
                Instantiate(projectile, transform.position, transform.rotation);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // LilyHealth.instance.DamagePlayer();
            LilyHealth.instance.DamagePlayer(10);

            // Calculate the direction of the force
            Vector2 forceDirection =
                (
                Character2DController.instance.transform.position -
                transform.position
                ).normalized;

            // Apply the force to the object
            rigidBody.AddForce(-forceDirection * forceAmount);
        }
        else if (other.CompareTag("Boundary"))
        {
            // Ignore collision with the obstacle
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other, true);
        }
    }

    public void DamageEnemy(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            KillCount.count += 1;
            XPSystem.xpFromKills += 1;

            Destroy (gameObject);
            RandomDrop();

            // if (Character2DController.instance.spawnRate > 0.3f)
            // {
            //     Character2DController.instance.speedUp();
            // }
            // todo why was this here? its erring out now that there are 2 projectiles
        }
    }

    public void RandomDrop()
    {
        float randomValue = Random.Range(0f, 1f);
        Debug.Log (randomValue);
        if (randomValue <= dropChance)
        {
            Instantiate(healthAsset, transform.position, transform.rotation);
        }
    }
}
