using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2DController : MonoBehaviour
{
    public float MovementSpeed = 3;

    public Transform projectileOrigin;

    public Vector2 moveInput;

    public Rigidbody2D rigidBody;

    private void Start()
    {
    }

    private void Update()
    {
        //track player input
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        rigidBody.velocity = MovementSpeed * moveInput;

        //calculate angle of projectile
        Vector3 mousePosition = Input.mousePosition;
        Vector3 screenPoint =
            Camera.main.WorldToScreenPoint(transform.localPosition);

        //rotate arm
        Vector2 offset =
            new Vector2(mousePosition.x - screenPoint.x,
                mousePosition.y - screenPoint.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        projectileOrigin.rotation = Quaternion.Euler(0, 0, angle);
    }

    void spawnProjectile()
    {
    }
}
