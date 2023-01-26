using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilyBullet : MonoBehaviour
{
    public float speed = 1.0f;

    public Rigidbody2D rigidBody;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = transform.right * speed;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    } 
}
