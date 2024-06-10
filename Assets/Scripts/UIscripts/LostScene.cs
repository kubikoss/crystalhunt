using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
    switching switching;
    void Start()
    {
        _player = FindObjectOfType<Player>();
        playerAttack = FindObjectOfType<PlayerAttack>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
        switching = FindObjectOfType<switching>();
    }

    void Update()
    {
        /*if (switching.playerWithSword.activeSelf)
        {
            levelText.text = "Level: " + _player.level.ToString();
            attackText.text = "Attack: " + playerAttack.damage.ToString();
            defenceText.text = "Defence: " + _player.defence.ToString();
            enemiesKilledText.text = "Enemies Killed: " + enemySpawner.enemiesKilled.ToString();
        }
        else if (switching.playerWithBow.activeSelf)
        {
            levelText.text = "Level: " + switching.GetComponent<Player>().level.ToString();
            attackText.text = "Attack: " + switching.GetComponent<PlayerAttack>().damage.ToString();
            defenceText.text = "Defence: " + switching.GetComponent<Player>().defence.ToString();
            enemiesKilledText.text = "Enemies Killed: " + enemySpawner.enemiesKilled.ToString();
        }*/
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
