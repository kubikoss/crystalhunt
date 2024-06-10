using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] 
    Transform _player;
    [SerializeField]
    Transform _player2;
    switching switching;
    AchievementManager achievementManager;
    UnlockAchievement unlockAchievement;
    public GameObject enemyPrefab;
    public GameObject bossPrefab;


    [SerializeField] 
    float detectionRange;
    [SerializeField] 
    int maxEnemiesToSpawn = 3;
    public int enemiesKilled = 0;

    [SerializeField] 
    float maxTimeBtwSpawn;
    float timeBtwSpawn;
    float distanceToPlayer;

    bool canSpawn = true;

    void Start()
    {
        timeBtwSpawn = maxTimeBtwSpawn;
        achievementManager = FindObjectOfType<AchievementManager>();
        unlockAchievement = FindObjectOfType<UnlockAchievement>();
        switching = FindObjectOfType<switching>();
    }

    void Update()
    {
        if (switching.playerWithSword.activeSelf)
        {
            distanceToPlayer = Vector2.Distance(transform.position, _player.position);
        }
        else if (switching.playerWithBow.activeSelf)
        {
            distanceToPlayer = Vector2.Distance(transform.position, _player2.position);
        }

        if (timeBtwSpawn <= 0)
        {
            if (detectionRange >= distanceToPlayer)
            {
                SpawnEnemy();
            }

            timeBtwSpawn = maxTimeBtwSpawn;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }

        if (enemiesKilled == 3 && canSpawn)
        {
            SpawnBoss();
        }
    }

    void SpawnEnemy()
    {
        for (int i = 0; i < maxEnemiesToSpawn; i++)
        {

            Vector2 randomOffset = new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
            Vector2 spawnPos = new Vector2(transform.position.x, transform.position.y);
            GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPos + randomOffset, Quaternion.identity);
            Enemy enemy = spawnedEnemy.GetComponent<Enemy>();

            switch (GameManager.DifficultyLevel)
            {
                case 1:
                    if (enemy.CompareTag("Enemy"))
                    {
                        enemy.health -= 30;
                        enemy.addXp += 10;
                    }
                    break;
                case 2:
                    if (enemy.CompareTag("Enemy"))
                    {
                        enemy.health += 10;
                        enemy.addXp -= 5;
                    }
                    break;
                case 3:
                    if (enemy.CompareTag("Enemy"))
                    {
                        enemy.health += 20;
                        enemy.addXp -= 10;
                    }
                    break;
            }
            enemy.AddSpawner(this);
        }
    }

    void SpawnBoss()
    {
        if (bossPrefab != null)
        {
            Vector3 randomOffset = new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
            GameObject spawnedBoss = Instantiate(bossPrefab, transform.position + randomOffset, Quaternion.identity);
            Enemy boss = spawnedBoss.GetComponent<Enemy>();
            canSpawn = false;
            switch (GameManager.DifficultyLevel)
            {
                case 1:
                    if (boss.CompareTag("Boss"))
                    {
                        boss.health -= 100;
                        boss.addXp += 50;
                    }
                    break;
                case 2:
                    if (boss.CompareTag("Boss"))
                    {
                        boss.health += 50;
                        boss.addXp -= 25;
                    }
                    break;
                case 3:
                    if (boss.CompareTag("Boss"))
                    {
                        boss.health += 100;
                        boss.addXp -= 50;
                    }
                    break;
                default:
                    break;
            }
        }
    }

    public void EnemyDied()
    {
        enemiesKilled++;
        Debug.Log(enemiesKilled);
        switch (enemiesKilled)
        {
            case 1:
                achievementManager.UnlockAchievement("First Blood");
                break;
            case 10:
                achievementManager.UnlockAchievement("Decimator");
                break;
            case 50:
                achievementManager.UnlockAchievement("Annihilator");
                break;
            case 100:
                achievementManager.UnlockAchievement("Reaper");
                break;
            default:
                break;
        }
    }
}
