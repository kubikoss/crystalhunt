using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public int health;
    [SerializeField]
    int addPlayerLives = 5;

    public int addXp = 100;
    public int level = 0;

    [SerializeField]
    Player _player;
    [SerializeField]
    Player _player2;
    [SerializeField]
    HealthBar healthbar;
    EnemySpawner enemySpawner;
    switching switching;
    AudioController audioController;
    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _player2 = FindObjectOfType<Player>();
        healthbar = FindObjectOfType<HealthBar>();
        switching = FindObjectOfType<switching>();
        audioController = FindObjectOfType<AudioController>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            audioController.PlayEnemyDeathSound();
            if (enemySpawner != null)
            {
                enemySpawner.EnemyDied();
            }
            if (switching.playerWithSword.activeSelf)
            {
                _player.LevelUp();
                _player.currHealth += addPlayerLives;
                if (_player.currHealth > _player.maxHealth)
                {
                    _player.currHealth = _player.maxHealth;
                }
                GameManager.GameManagerInstance._Player.AddXp(addXp);
                healthbar.SetHealth(_player.currHealth);
                Destroy(gameObject, 0.05f);
            }
            else if (switching.playerWithBow.activeSelf)
            {
                _player2.LevelUp();
                _player2.currHealth += addPlayerLives;
                if (_player2.currHealth > _player2.maxHealth)
                {
                    _player2.currHealth = _player2.maxHealth;
                }
                GameManager.GameManagerInstance._Player2.AddXp(addXp);
                healthbar.SetHealth(_player2.currHealth);
                Destroy(gameObject, 0.05f);
            }
            
        }
    }

    public void AddSpawner(EnemySpawner enemySpawner)
    {
        this.enemySpawner = enemySpawner;
    }
}

