using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    Player _player;

    void Start()
    {
        _player = FindObjectOfType<Player>();
    }
    public void Respawn()
    {
        Player.respawnLives--;
        SceneManager.LoadScene("Game");
    }
}
