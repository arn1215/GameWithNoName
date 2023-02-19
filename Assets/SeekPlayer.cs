using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rigidBody;

    public float moveSpeed = 5f;

    public float rangeToChasePlayer;

    public Vector3 moveDirection;

    public AudioSource audio;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SeekPlayerLogic();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //increment health and delete heart when it has reached player
        if (other.tag == "Player")
        {
            StartCoroutine(PlaySound());
        }
    }

    //function that tracks and follows player with current gameobj
    public void SeekPlayerLogic()
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

        float distance =
            Vector2
                .Distance(transform.position,
                Character2DController.instance.transform.position);
    }

    IEnumerator PlaySound()
    {
        audio.Play();
        LilyHealth.instance.HealPlayer(25);
        yield return new WaitForSeconds(.8f);
        Destroy (gameObject);
    }
}
