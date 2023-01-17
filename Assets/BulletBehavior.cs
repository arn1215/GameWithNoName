using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public Rigidbody2D bullet;
    public GameObject bulletObj;  
    public int speed = 100; 
    public float position; 
    // Start is called before the first frame update
    void Start()
    {
         position = bulletObj.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
         bullet.velocity = new Vector2(speed, 0f);
         if (bulletObj.transform.position.x - position > 3) {
            Destroy(gameObject);
         }
    }
}
