using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rigidBody;

    public float moveSpeed;

    public float rangeToChasePlayer;

    public Vector3 moveDirection;

    void Start()
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

        float distance =
            Vector2
                .Distance(transform.position,
                Character2DController.instance.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
