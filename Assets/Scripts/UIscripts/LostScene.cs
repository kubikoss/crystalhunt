using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LostScene : MonoBehaviour
{
    Player _player;
    PlayerAttack playerAttack;
    EnemySpawner enemySpawner;

    [SerializeField]
    TextMeshProUGUI levelText;
    [SerializeField]
    TextMeshProUGUI attackText;
    [SerializeField]
    TextMeshProUGUI defenceText;
    [SerializeField]
    TextMeshProUGUI enemiesKilledText;
    void Start()
    {
        _player = FindObjectOfType<Player>();
        playerAttack = FindObjectOfType<PlayerAttack>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Update()
    {
        levelText.text = "Level: " + _player.level.ToString();
        attackText.text = "Attack: " + playerAttack.damage.ToString();
        defenceText.text = "Defence: " + _player.defence.ToString();
        enemiesKilledText.text = "Enemies Killed: " + enemySpawner.enemiesKilled.ToString();
    }
}
