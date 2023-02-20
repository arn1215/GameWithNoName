using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager2 : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;

    public List<GameObject> Enemies = new List<GameObject>();

    [SerializeField]
    Vector2 spawnArea;

    [SerializeField]
    float spawnTimer;

    float timer;

    float spawnChance;

    // Start is called before the first frame update
    void Start()
    {
        spawnChance = 0.009f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            SpawnEnemy();
            timer = spawnTimer;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 position =
            new Vector3(UnityEngine.Random.Range(-spawnArea.x, spawnArea.x),
                UnityEngine.Random.Range(-spawnArea.y, spawnArea.y),
                0f);

        float randomValue = Random.Range(0f, 1f);

        if (randomValue <= spawnChance)
        {
            var thing = Instantiate(Enemies[1], position, transform.rotation);

            thing.SetActive(true);
        }
        else
        {
            var thing = Instantiate(Enemies[0], position, transform.rotation);

            thing.SetActive(true);
        }

        // GameObject newEnemy = Instantiate(enemy);
        // newEnemy.transform.position = position;
    }
}
