using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui : MonoBehaviour
{
    public Character2DController characterFireRate;
    // Start is called before the first frame update
    void Start()
    {
      
     StartCoroutine(perkMessage()); 
    }

     

    // Update is called once per frame
    void Update()
    {
        characterFireRate.spawnRate -= 100f; 
    }
    

    IEnumerator perkMessage(){
        
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
