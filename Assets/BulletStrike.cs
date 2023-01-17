using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStrike : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Pleb Point" && gameObject.tag == "Bullet")
        {
            print(collision.gameObject);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    void Update() 
    {
       
    }
}
