using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddSurvivalTime : MonoBehaviour
{
    [SerializeField] 
    TextMeshProUGUI aliveTimeText;
    float aliveTime;
    AchievementManager achievementManager;
    bool[] unlockedAchievement = new bool[4];
    void Start()
    {
        aliveTime = 0f;
        achievementManager = FindObjectOfType<AchievementManager>();
    }

    void Update()
    {
        aliveTime += Time.deltaTime;
        UnlockAchievement(aliveTime);
        DisplayTime(aliveTime);
    }

    void DisplayTime(float displayTime)
    {
        displayTime += 1;

        float minutes = Mathf.FloorToInt(displayTime / 60);
        float seconds = Mathf.FloorToInt(displayTime % 60);

        aliveTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void UnlockAchievement(float time)
    {
        if (time >= 60f && time <= 61f && !unlockedAchievement[0])
        {
            achievementManager.UnlockAchievement("First Step");
            unlockedAchievement[0] = true;
        }
        else if (time >= 300f && time <= 301f && !unlockedAchievement[1])
        {
            achievementManager.UnlockAchievement("Five Alive");
            unlockedAchievement[1] = true;
        }
        else if (time >= 600f && time <= 601f && !unlockedAchievement[2])
        {
            achievementManager.UnlockAchievement("Decade Defender");
            unlockedAchievement[2] = true;
        }
        else if(time >= 1200f && time <= 1201f && !unlockedAchievement[3])
        {
            achievementManager.UnlockAchievement("Survival Specialist");
            unlockedAchievement[3] = true;
        }
        else if (time >= 1800f && time <= 1801f && !unlockedAchievement[4])
        {
            achievementManager.UnlockAchievement("Ultimate Survivor");
            unlockedAchievement[4] = true;
        }
    }
}
