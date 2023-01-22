using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStrike : MonoBehaviour

{
    public AudioClip[] projectileSounds;
    public AudioSource projectileSource;
    public GameObject player;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision){


        if (collision.gameObject.tag == "Player") {
            print(collision.gameObject);

            // Destroy(collision.gameObject);
            print("player hit");
        }
        if (collision.gameObject.tag == "Boundary"  && gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Pleb Point"  && gameObject.tag == "Bullet")
        {     
            Destroy(collision.gameObject);
            Destroy(gameObject);
            projectileSource.Play();
        }

    }

    void Update() 
    {
       
    }
}
