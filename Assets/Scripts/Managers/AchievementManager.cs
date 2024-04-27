using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    AchievementPopup achievementPopup;

    private Dictionary<string, bool> achievementStatuses = new Dictionary<string, bool>();

    void Start()
    {
        achievementPopup = FindObjectOfType<AchievementPopup>();
    }

    public void UnlockAchievement(string achievementName)
    {
        if (!achievementStatuses.ContainsKey(achievementName))
        {
            achievementStatuses.Add(achievementName, true);
            achievementPopup.Show(achievementName + " Unlocked!");
        }
    }
}
