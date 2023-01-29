using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilyBullet : MonoBehaviour
{
    public float speed = 2.0f;

    public Rigidbody2D rigidBody;

    public GameObject impactEffect;

    public int dmgToGive = 100;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = transform.right * speed;

        if (rigidBody.velocity.x < 0)
        {
            transform.localScale = new Vector3(0.5f, -0.5f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            other.GetComponent<EnemyScript>().DamageEnemy(dmgToGive);
            Destroy (gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy (gameObject);
    }
}
