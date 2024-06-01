using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpSystem : MonoBehaviour
{
    [SerializeField]
    GameObject levelUpMenuUI;

    int addHealth = 20;
    int addDamage = 5;
    int addDefence = 5;

    Player _player;
    PlayerAttack pA;
    CanvasGroup canvasGroup;
    AchievementManager achievementManager;
    ArrowCollider arrowCollider;
    public AudioController audioController;

    void Start()
    {
        pA = FindObjectOfType<PlayerAttack>();
        _player = FindObjectOfType<Player>();
        canvasGroup = levelUpMenuUI.GetComponent<CanvasGroup>();
        achievementManager = FindObjectOfType<AchievementManager>();
        arrowCollider = FindObjectOfType<ArrowCollider>();
    }

    public void AddDamage()
    {
        pA.damage += addDamage;
        arrowCollider.arrowDamage += addDamage;
        if (pA.damage == 50)
        {
            achievementManager.UnlockAchievement("Force Unleashed");
            //PlayerPrefs.SetInt("ForceUnleashedUnlocked", 1);
        }
        audioController.PlayLevelUpSound();
        _player.DisablePanel();
        _player.LevelUp();
        //Debug.Log(pA.damage);
    }
    public void AddLives()
    {
        _player.currHealth += addHealth;
        _player.maxHealth += addHealth;
        canvasGroup.alpha = 0f;
        if (_player.maxHealth == 200)
        {
            achievementManager.UnlockAchievement("Resilience Fortified");
            //PlayerPrefs.SetInt("ResilienceFortifiedUnlocked", 1);
        }
        audioController.PlayLevelUpSound();
        _player.DisablePanel();
        _player.LevelUp();
        //Debug.Log(_player.maxHealth);
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
        audioController.PlayLevelUpSound();
        _player.DisablePanel();
        _player.LevelUp();
        //Debug.Log(_player.defence);
    }
}
