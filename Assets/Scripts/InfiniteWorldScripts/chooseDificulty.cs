using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chooseDificulty : MonoBehaviour
{
    Enemy enemy;
    void Start()
    {
        enemy = FindObjectOfType<Enemy>();
    }
    void Update()
    {

        if (enemy != null)
        {
            Debug.Log(enemy.health);
        }
    }

    public void Easy()
    {
        GameManager.DifficultyLevel = 1;
    }

    public void Medium()
    {
        GameManager.DifficultyLevel = 2;
    }

    public void Hard()
    {
        GameManager.DifficultyLevel = 3;
    }
}
