using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    

    public List<GameObject> Projectiles = new List<GameObject>();

    public float spawnRate;

    private float timer = 0;

    public float heightOffset = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnRate = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnProjectile();
            timer = 0;
        }
    }

    void spawnProjectile()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        var thing = 
        Instantiate(Projectiles[0],
        new Vector3(transform.position.x,
            Random.Range(lowestPoint, highestPoint),
            0),
        transform.rotation);

        thing.SetActive(true);


        //currently using this to delete a projectile after some time
        StartCoroutine(DeactivateAfterSeconds(2));
        IEnumerator DeactivateAfterSeconds(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            
            //if the projectile has not been destroyed from impact, set it to inactive
            if (thing) {

                thing.SetActive(false);
            }
        }
    }
}
