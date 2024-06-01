using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingCrystal : MonoBehaviour
{
    static int collectedCrystal = 0;

    AchievementManager achievementManager;
    AudioController audioController;

    void Start()
    {
        achievementManager = FindObjectOfType<AchievementManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioController.PlayCollectSound();
            collectedCrystal++;
            Debug.Log(collectedCrystal);
            Destroy(gameObject);

            if (collectedCrystal == 5)
            {
                achievementManager.UnlockAchievement("Crystalbane Champion");
                //PlayerPrefs.SetInt("CrystalbaneChampionUnlocked", 1);
                //endgame
            }
            else if (collectedCrystal == 3)
            {
                achievementManager.UnlockAchievement("Crystalbane Professional");
                //PlayerPrefs.SetInt("CrystalbaneProfessionalUnlocked", 1);
            }
            else if (collectedCrystal == 1)
            {
                achievementManager.UnlockAchievement("Crystalbane Beginner");
                //PlayerPrefs.SetInt("CrystalbaneBeginnerUnlocked", 1);
            }
        }
    }
}
