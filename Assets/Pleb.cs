using UnityEngine;

public class Pleb : MonoBehaviour
{
    public float speed = 5.1f; // adjust this to change the speed of the movement

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }
}
