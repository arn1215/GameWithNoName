using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public Rigidbody2D bullet;  
    public int speed = 100;  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         bullet.velocity = new Vector2(speed, 0f);
    }
}
