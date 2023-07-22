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
        spawnChance = 0.03f;
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

        if (spawnTimer > 0.00f)
        {
            spawnTimer -= 0.00000008f;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 position = GenerateRandomPosition();

        float randomValue = Random.Range(0f, 1f);

        if (randomValue <= spawnChance)
        // red skelly
        {
            var thing = Instantiate(Enemies[1], position, transform.rotation);

            thing.SetActive(true);
        }
        else
        // white skelly
        {
            var thing = Instantiate(Enemies[0], position, transform.rotation);

            thing.SetActive(true);
        }

        // GameObject newEnemy = Instantiate(enemy);
        // newEnemy.transform.position = position;
    }

    private Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();

        float f = UnityEngine.Random.value > 0.5f ? -1f : 1f;
        if (UnityEngine.Random.value > 0.5f || true)
        {
            position.x = UnityEngine.Random.Range(-spawnArea.x, spawnArea.x);
            position.y = UnityEngine.Random.Range(-spawnArea.y, spawnArea.y);
        }
        else
        {
            position.y = UnityEngine.Random.Range(-spawnArea.y, spawnArea.y);
            position.x = spawnArea.x * f;
        }

        position.z = 0;

        return position;
    }
}
