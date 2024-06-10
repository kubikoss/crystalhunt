using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    Player _player;
    public Scene currentScene;

    void Start()
    {
        _player = FindObjectOfType<Player>();
        currentScene = SceneManager.GetActiveScene();
    } 
    void Update()
    {
        
    }

    public void Respawn()
    {
        if (currentScene.name == "Story Mode")
        {
            Player.respawnLives--;
            SceneManager.LoadScene("Story Mode");
        }
        else if (currentScene.name == "Infinite World")
        {
            SceneManager.LoadScene("Lost");
        }
        
    }
}
