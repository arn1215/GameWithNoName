using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Animator animator;

    public AudioClip[] audioArray;

    public Rigidbody2D mainCharacter;

    public AudioSource jump;

    public float jumpForce = 1f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        Vector3 movement =
            new Vector3(Input.GetAxis("Horizontal"),
                Input.GetAxis("Vertical"),
                0.0f);
        // Vector3 vertical = new Vector3(Input.GetAxis("Vertical"), 0.0f, 1.0f);
        transform.position =
            transform.position + movement * Time.deltaTime * 1.2f;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            mainCharacter.AddForce(new Vector2(0f, jumpForce));
            jump.clip = audioArray[Random.Range(0, audioArray.Length)];
            jump.Play();
        }
    }
}
