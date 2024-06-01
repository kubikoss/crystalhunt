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
            Vector3 randomOffset = new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
            GameObject spawnedEnemy = Instantiate(enemyPrefab, transform.position + randomOffset, Quaternion.identity);
            spawnedEnemy.GetComponent<Enemy>().AddSpawner(this);
        }
    }

    void SpawnBoss()
    {
        if (bossPrefab != null)
        {
            Vector3 randomOffset = new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
            Instantiate(bossPrefab, transform.position + randomOffset, Quaternion.identity);
            canSpawn = false;
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
