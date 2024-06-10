using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomEnemy : MonoBehaviour
{
    public GameObject[] bossPrefabs;
    public GameObject[] enemyPrefabs;
    public float spawnCooldown = 10f;

    private float spawnTimer;
    void Start()
    {
        spawnTimer = spawnCooldown;
    }
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            ProbabilitySpawn();
            spawnTimer = spawnCooldown;
        }
    }

    void ProbabilitySpawn()
    {
        float probability = Random.Range(0f, 1f);

        if (probability <= 0.7f)
        {
            SpawnEnemy();
        }
        else
        {
            SpawnBoss();
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefabs != null)
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyPrefab = enemyPrefabs[enemyIndex];

            Instantiate(enemyPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        }
    }

    void SpawnBoss()
    {
        if (bossPrefabs != null)
        {
            int bossIndex = Random.Range(0, bossPrefabs.Length);
            GameObject bossPrefab = bossPrefabs[bossIndex];

            Instantiate(bossPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        }
    }

}
