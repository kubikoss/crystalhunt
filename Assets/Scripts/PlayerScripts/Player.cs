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
    public AudioController audioController;

    void Start()
    {
        currHealth = maxHealth;
        healthBar.SetMaxHealth(currHealth);
        achievementManager = FindObjectOfType<AchievementManager>();
        levelUpMenuUI = GameObject.FindGameObjectWithTag("LevelUI");
        playerRespawn = FindObjectOfType<PlayerRespawn>();

        DisablePanel();
    }

    public void TakeDamage(int damage)
    {
        currHealth = currHealth - damage + defence;
        healthBar.SetHealth(currHealth);
        //Debug.Log(currHealth);
    }
    public void isPlayerDead()
    {
        if (currHealth <= 0)
        {
            audioController.PlayPlayerDeathSound();
            playerRespawn.Respawn();
            if (respawnLives == 0)
            {
                SceneManager.LoadScene("Lost");
            }
        }
    }

    public void LevelUp()
    {
        if (xp >= maxXp)
        { 
            EnablePanel();
            xp -= maxXp;
            level++;
            XPAchievement();
        }
    }

    public void AddXp(int xpToAdd)
    {
        xp += xpToAdd;
        LevelUp();
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