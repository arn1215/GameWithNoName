using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilyBullet : MonoBehaviour
{
    public float speed = 2.0f;

    public Rigidbody2D rigidBody;

    public GameObject impactEffect;

    public int dmgToGive = 100;

    public AudioSource enemyHit;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = transform.right * speed;

        if (rigidBody.velocity.x < 0)
        {
            transform.localScale = new Vector3(0.2f, 0.2f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(0.2f, 0.2f, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            StartCoroutine(PlaySound());

            Instantiate(impactEffect, transform.position, transform.rotation);

            other.GetComponent<EnemyScript>().DamageEnemy(dmgToGive);
        }
    }

    IEnumerator PlaySound()
    {
        enemyHit.Play();
        yield return new WaitForSeconds(0.02f);
        Destroy (gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy (gameObject);
    }
}
