using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] 
    Transform _player;
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

    [SerializeField] 
    bool spawnBoss = false;

    void Start()
    {
        timeBtwSpawn = maxTimeBtwSpawn;
        achievementManager = FindObjectOfType<AchievementManager>();
        unlockAchievement = FindObjectOfType<UnlockAchievement>();
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, _player.position);

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

        if (spawnBoss && enemiesKilled == 3)
        {
            SpawnBoss();
            spawnBoss = false;
        }
    }

    void SpawnEnemy()
    {
        for (int i = 0; i < maxEnemiesToSpawn; i++)
        {
            Vector3 randomOffset = new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
            GameObject spawnedEnemy = Instantiate(enemyPrefab, transform.position + randomOffset, Quaternion.identity);
            spawnedEnemy.GetComponent<Enemy>().AddSpawner(this);
        }
    }

    void SpawnBoss()
    {
        Vector3 randomOffset = new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
        Instantiate(bossPrefab, transform.position + randomOffset, Quaternion.identity);
        //Debug.Log("spawned");
    }

    public void EnemyDied()
    {
        enemiesKilled++;
        if (enemiesKilled == 3)
        {
            spawnBoss = true;
        }
        Debug.Log(enemiesKilled);
        switch (enemiesKilled)
        {
            case 1:
                achievementManager.UnlockAchievement("First Blood");
                //PlayerPrefs.SetInt("FirstBloodUnlocked", 1);
                //unlockAchievement.AchievementUnlocked();
                break;
            case 10:
                achievementManager.UnlockAchievement("Decimator");
                //PlayerPrefs.SetInt("DecimatorUnlocked", 1);
                //unlockAchievement.AchievementUnlocked();
                break;
            case 50:
                achievementManager.UnlockAchievement("Annihilator");
                //PlayerPrefs.SetInt("AnnihilatorUnlocked", 1);
                //unlockAchievement.AchievementUnlocked();
                break;
            case 100:
                achievementManager.UnlockAchievement("Reaper");
                //PlayerPrefs.SetInt("ReaperUnlocked", 1);
                //unlockAchievement.AchievementUnlocked();
                break;
            default:
                break;
        }
    }
}
