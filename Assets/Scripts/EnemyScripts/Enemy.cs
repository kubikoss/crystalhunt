using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public int health;
    [SerializeField]
    int addPlayerLives = 5;

    public int addXp = 40;
    public int level = 0;

    [SerializeField]
    Player _player;
    [SerializeField]
    HealthBar healthbar;
    AchievementManager achievementManager;
    EnemySpawner enemySpawner;
    private void Start()
    {
        _player = FindObjectOfType<Player>();
        healthbar = FindObjectOfType<HealthBar>();
        achievementManager = FindObjectOfType<AchievementManager>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            if (enemySpawner != null)
            {
                enemySpawner.EnemyDied();
            }
            _player.currHealth += addPlayerLives;
            if (_player.currHealth > _player.maxHealth)
            {
                _player.currHealth = 100;
            }
            GameManager.GameManagerInstance._Player.AddXp(addXp);
            healthbar.SetHealth(_player.currHealth);
            Destroy(gameObject, 0.05f);
        }
    }

    public void AddSpawner(EnemySpawner enemySpawner)
    {
        this.enemySpawner = enemySpawner;
    }
}

