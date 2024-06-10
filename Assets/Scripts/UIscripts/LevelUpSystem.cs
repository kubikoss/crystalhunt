using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpSystem : MonoBehaviour
{
    [SerializeField]
    GameObject levelUpMenuUI;

    int addHealth = 20;
    int addDamage = 3;
    int addDefence = 1;

    Player _player;
    CanvasGroup canvasGroup;
    AchievementManager achievementManager;
    public AudioController audioController;

    [SerializeField]
    PlayerAttack swordPlayerAttack;
    [SerializeField]
    ArrowCollider bowPlayerAttack;
    switching switchingScript;

    void Start()
    {
        _player = FindObjectOfType<Player>();
        canvasGroup = levelUpMenuUI.GetComponent<CanvasGroup>();
        achievementManager = FindObjectOfType<AchievementManager>();

        switchingScript= FindObjectOfType<switching>();
        if (switchingScript != null)
        {
            swordPlayerAttack = switchingScript.playerWithSword.GetComponent<PlayerAttack>();
        }
    }

    public void AddDamage()
    {
        if (swordPlayerAttack != null)
        {
            swordPlayerAttack.damage += addDamage;
            if (swordPlayerAttack.damage == 50)
            {
                achievementManager.UnlockAchievement("Force Unleashed");
            }
        }

        ArrowCollider.arrowDamage += addDamage;
        if (ArrowCollider.arrowDamage == 50)
        {
            achievementManager.UnlockAchievement("Archero Champion");
        }

        audioController.PlayLevelUpSound();
        _player.DisablePanel();
        _player.LevelUp();
    }

    public void AddLives()
    {
        _player.currHealth += addHealth;
        _player.maxHealth += addHealth;
        canvasGroup.alpha = 0f;
        if (_player.maxHealth == 200)
        {
            achievementManager.UnlockAchievement("Resilience Fortified");
        }
        audioController.PlayLevelUpSound();
        _player.DisablePanel();
        _player.LevelUp();
    }

    public void AddDefence()
    {
        _player.defence += addDefence;
        canvasGroup.alpha = 0f;
        if (_player.defence == 20)
        {
            achievementManager.UnlockAchievement("Guardian's Shield");
        }
        audioController.PlayLevelUpSound();
        _player.DisablePanel();
        _player.LevelUp();
    }
}
