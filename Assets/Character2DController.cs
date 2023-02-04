using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2DController : MonoBehaviour
{
    public static Character2DController instance;

    public float MovementSpeed = 3;

    public Transform projectileOrigin;

    public Vector2 moveInput;

    public Rigidbody2D rigidBody;

    public Animator anim;

    private Camera camera;

    public GameObject theProjectile;

    public Transform firePoint;

    public float spawnRate = 0.5f;

    public AudioSource audioSrc;

    private float timer = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        //track player input
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        //keeps player speed even when going diagonal
        moveInput.Normalize();

        rigidBody.velocity = MovementSpeed * moveInput;

        //calculate angle of projectile
        Vector3 mousePosition = Input.mousePosition;
        Vector3 screenPoint =
            camera.WorldToScreenPoint(transform.localPosition);

        if (mousePosition.x < screenPoint.x)
        {
            transform.localScale = new Vector3(-1.69f, 1.69f, 1f);
            projectileOrigin.localScale = new Vector3(-1f, -1f, 0f);
        }
        else
        {
            transform.localScale = new Vector3(1.69f, 1.69f, 1f);
            projectileOrigin.localScale = new Vector3(1f, 1f, 0f);
        }

        //=======================================================================//rotate arm
        Vector2 offset =
            new Vector2(mousePosition.x - screenPoint.x,
                mousePosition.y - screenPoint.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        projectileOrigin.rotation = Quaternion.Euler(0, 0, angle);

        //firepoint.rotation makes it so lily can fire bullets in the direction the mouse is
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnProjectile();
            timer = 0;
        }

        //=====================================================================walking animation
        if (moveInput != Vector2.zero)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }



    }

    public void speedUp()
    {
        spawnRate -= 0.5f;
    }

    void spawnProjectile()
    {
        Instantiate(theProjectile, firePoint.position, firePoint.rotation);
        audioSrc.Play();
    }
}
