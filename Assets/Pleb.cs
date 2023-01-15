using UnityEngine;

public class Pleb : MonoBehaviour
{
    public float speed = 1.1f; // adjust this to change the speed of the movement

    public float value = 1.0f;

    public bool IsFacingLeft = true;

    public PlayerHealth playerHealth;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (IsFacingLeft)
        {
            rb.velocity = new Vector2(-speed, 0f);
        }
        else
        {
            rb.velocity = new Vector2(speed, 0f);
        }
    }

    // public bool IsFacingLeft()
    // {
    //     return transform.localScale.x > Mathf.Epsilon;
    // }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(10);
        }
        if (IsFacingLeft)
        {
            transform.localScale = new Vector2(-1f, transform.localScale.y);
        }
        else
        {
            transform.localScale = new Vector2(1f, transform.localScale.y);
        }
        IsFacingLeft = !IsFacingLeft;
    }
}
