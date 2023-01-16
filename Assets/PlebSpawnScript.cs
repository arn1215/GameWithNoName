using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlebSpawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    

    public List<GameObject> Enemies = new List<GameObject>();

    public float spawnRate = 2;

    

    private float timer = 0;

    public float heightOffset = 8;

    // Start is called before the first frame update
    void Start()
    {
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
            spawnPleb();
            timer = 0;
        }
    }

    void spawnPleb()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        var thing = 
        Instantiate(Enemies[0],
        new Vector3(transform.position.x,
            Random.Range(lowestPoint, highestPoint),
            0),
        transform.rotation);

        thing.SetActive(true);
    }
}
