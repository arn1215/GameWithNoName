using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlebSpawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> Enemies = new List<GameObject>();

    public float spawnRate = 2;

    public float dropChance;

    private float timer = 0;

    public float heightOffset = 8;

    // Start is called before the first frame update
    void Start()
    {
        dropChance = 0.1f;
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
        RandomEnemy();
    }

    public void RandomEnemy()
    {
        float randomValue = Random.Range(0f, 1f);

        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        if (randomValue <= dropChance)
        {
            var thing =
                Instantiate(Enemies[1],
                new Vector3(transform.position.x,
                    Random.Range(lowestPoint, highestPoint),
                    0),
                transform.rotation);

            thing.SetActive(true);
        }
        else
        {
            var thing =
                Instantiate(Enemies[0],
                new Vector3(transform.position.x,
                    Random.Range(lowestPoint, highestPoint),
                    0),
                transform.rotation);

            thing.SetActive(true);
        }
    }
}
