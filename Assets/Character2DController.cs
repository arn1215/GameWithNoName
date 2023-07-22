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

    public float spawnRate = 0.9f;

    public AudioSource audioSrc;

    private float timer = 0;

    // POWER UPS
    public float pewPewTier = 1;

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
            transform.localScale = new Vector3(-1.00f, 1.00f, 1f);
            projectileOrigin.localScale = new Vector3(-1f, -1f, 0f);
        }
        else
        {
            transform.localScale = new Vector3(1.00f, 1.00f, 1f);
            projectileOrigin.localScale = new Vector3(1f, 1f, 0f);
        }

        //=======================================================================//rotate arm
        Vector2 offset =
            new Vector2(mousePosition.x - screenPoint.x,
                mousePosition.y - screenPoint.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        //firepoint.rotation makes it so lily can fire bullets in the direction the mouse is
        projectileOrigin.rotation = Quaternion.Euler(0, 0, angle);

        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnProjectiles();
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

    void SpawnProjectiles()
    {
        int killCount = 0;
        killCount = KillCount.count / 2;
        switch (killCount / 2)
        {
            case 25:
                pewPewTier = 2;
                break;
            case 50:
                pewPewTier = 3;
                break;
            case 75:
                pewPewTier = 4;
                break;
            default:
                break;
        }

        // Spawn projectile in the current direction (TIER 1)
        GameObject firstProjectile =
            Instantiate(theProjectile, firePoint.position, firePoint.rotation);
        SetProjectileOrientation(firstProjectile, firePoint.right);
        audioSrc.Play();

        // Calculate the direction from firePoint to mouse position
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = firePoint.position.z;
        Vector3 directionToMouse =
            camera.ScreenToWorldPoint(mousePosition) - firePoint.position;
        directionToMouse.Normalize();

        // Calculate the opposite direction
        Vector3 oppositeDirection = -directionToMouse;

        // Spawn another projectile in the opposite direction (TIER 2)
        if (pewPewTier > 1)
        {
            Quaternion oppositeRotation =
                Quaternion
                    .Euler(0,
                    0,
                    Mathf.Atan2(oppositeDirection.y, oppositeDirection.x) *
                    Mathf.Rad2Deg);
            GameObject secondProjectile =
                Instantiate(theProjectile,
                firePoint.position,
                oppositeRotation);
            SetProjectileOrientation(secondProjectile, -firePoint.right);
        }

        // Spawn two more going up and down  (TIER 3)
        if (pewPewTier > 2)
        {
            GameObject thirdProjectile =
                Instantiate(theProjectile,
                firePoint.position,
                Quaternion.Euler(0, 0, 90));
            SetProjectileOrientation(thirdProjectile, -firePoint.right);

            GameObject fourthProjectile =
                Instantiate(theProjectile,
                firePoint.position,
                Quaternion.Euler(0, 0, 270));
            SetProjectileOrientation(fourthProjectile, -firePoint.right);
        }

        // // Spawn four more going up and down (TIER 4)
        if (pewPewTier > 3)
        {
            GameObject fifthProjectile =
                Instantiate(theProjectile,
                firePoint.position,
                Quaternion.Euler(0, 0, 45));
            SetProjectileOrientation(fifthProjectile, -firePoint.right);

            GameObject sixthProjectile =
                Instantiate(theProjectile,
                firePoint.position,
                Quaternion.Euler(0, 0, 135));
            SetProjectileOrientation(sixthProjectile, -firePoint.right);

            GameObject seventhProjectile =
                Instantiate(theProjectile,
                firePoint.position,
                Quaternion.Euler(0, 0, 225));
            SetProjectileOrientation(seventhProjectile, -firePoint.right);

            GameObject eightProjectile =
                Instantiate(theProjectile,
                firePoint.position,
                Quaternion.Euler(0, 0, 315));
            SetProjectileOrientation(eightProjectile, -firePoint.right);
        }
    }

    void SetProjectileOrientation(GameObject projectile, Vector3 direction)
    {
        Vector3 localScale = projectile.transform.localScale;
        localScale.x = Mathf.Abs(localScale.x) * Mathf.Sign(direction.x);
        projectile.transform.localScale = localScale;
    }
}
