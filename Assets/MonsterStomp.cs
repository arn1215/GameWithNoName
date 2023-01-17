using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStomp : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Weak Point" && gameObject.tag == "Foot")
        {
            print(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }

    void Update() 
    {
       
    }
}
