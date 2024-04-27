using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpSystem : MonoBehaviour
{
    [SerializeField]
    GameObject levelUpMenuUI;

    int addMaxHealth = 20;
    int addDamage = 5;
    int addDefence = 5;

    Player _player;
    PlayerAttack pA;
    CanvasGroup canvasGroup;
    AchievementManager achievementManager;

    void Start()
    {
        pA = FindObjectOfType<PlayerAttack>();
        _player = FindObjectOfType<Player>();
        canvasGroup = levelUpMenuUI.GetComponent<CanvasGroup>();
        achievementManager = FindObjectOfType<AchievementManager>();
    }

    public void AddDamage()
    {
        pA.damage += addDamage;
        if (pA.damage == 50)
        {
            achievementManager.UnlockAchievement("Force Unleashed");
            //PlayerPrefs.SetInt("ForceUnleashedUnlocked", 1);
        }
        _player.DisablePanel();
        Debug.Log(pA.damage);
    }
    public void AddLives()
    {
        _player.maxHealth += addMaxHealth;
        canvasGroup.alpha = 0f;
        if (_player.maxHealth == 200)
        {
            achievementManager.UnlockAchievement("Resilience Fortified");
            //PlayerPrefs.SetInt("ResilienceFortifiedUnlocked", 1);
        }
        _player.DisablePanel();
        Debug.Log(_player.maxHealth);
    }

    public void AddDefence()
    {
        _player.defence += addDefence;
        canvasGroup.alpha = 0f;
        if (_player.defence == 20)
        {
            achievementManager.UnlockAchievement("Guardian's Shield");
            //PlayerPrefs.SetInt("GuardiandsShieldUnlocked", 1);
        }
        _player.DisablePanel();
        Debug.Log(_player.defence);
    }
}
