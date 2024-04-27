using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currHealth;
    public int defence = 0;
    public int level;
    public static int respawnLives = 3;
    public int xp = 0;
    private int maxXp = 100;

    public HealthBar healthBar;
    AchievementManager achievementManager;
    GameObject levelUpMenuUI;
    PlayerRespawn playerRespawn;
    //private GameManager gameManager;

    void Start()
    {
        currHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        achievementManager = FindObjectOfType<AchievementManager>();
        levelUpMenuUI = GameObject.FindGameObjectWithTag("LevelUI");
        playerRespawn = FindObjectOfType<PlayerRespawn>();

        DisablePanel();
        //gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        LevelUp();
    }

    public void TakeDamage(int damage)
    {
        currHealth = currHealth - damage + defence;
        healthBar.SetHealth(currHealth);
    }
    public void isPlayerDead()
    {
        if (currHealth <= 0)
        {
            playerRespawn.Respawn();
            if (respawnLives == 0)
            {
                SceneManager.LoadScene("Lost");
            }
        }
    }
    
    public void LevelUp()
    {
        while(xp >= maxXp)
        {
            xp -= 100;
            level++;
            EnablePanel();
            XPAchievement();
        }
    }

    public void AddXp(int xpToAdd)
    {
        xp += xpToAdd;
        LevelUp();
        Debug.Log(xp);
    }

    void XPAchievement()
    {
        switch (level)
        {
            case 20:
                achievementManager.UnlockAchievement("Master of the Realm");
                break;
            case 15:
                achievementManager.UnlockAchievement("Seasoned Warrior");
                break;
            case 10:
                achievementManager.UnlockAchievement("Battle-Hardened");
                break;
            case 5:
                achievementManager.UnlockAchievement("Novice Conqueror");
                break;
            case 1:
                achievementManager.UnlockAchievement("Initiate Adventurer");
                break;
            default:
                break;
        }
    }

    public void DisablePanel()
    {
        CanvasGroup canvasGroup = levelUpMenuUI.GetComponent<CanvasGroup>();

        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        Time.timeScale = 1f;
    }

    public void EnablePanel()
    {
        CanvasGroup canvasGroup = levelUpMenuUI.GetComponent<CanvasGroup>();

        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

        Time.timeScale = 0f;
    }
}
