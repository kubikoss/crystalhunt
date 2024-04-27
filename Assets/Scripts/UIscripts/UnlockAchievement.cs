using UnityEngine;

public class UnlockAchievement : MonoBehaviour
{
    public GameObject unlockedAchievement;

    void Start()
    {
        unlockedAchievement.SetActive(false);
    }
    public void AchievementUnlocked()
    {
        if (PlayerPrefs.GetInt("FirstBloodUnlocked") == 1)
        {
            unlockedAchievement.SetActive(true);
        }
        if (PlayerPrefs.GetInt("DecimatorUnlocked") == 1)
        {
            unlockedAchievement.SetActive(true);
        }
        if (PlayerPrefs.GetInt("AnnihilatorUnlocked") == 1)
        {
            unlockedAchievement.SetActive(true);
        }
        if (PlayerPrefs.GetInt("ForceUnleashedUnlocked") == 1)
        {
            unlockedAchievement.SetActive(true);
        }
        if (PlayerPrefs.GetInt("ResilienceFortifiedUNlocked") == 1)
        {
            unlockedAchievement.SetActive(true);
        }
        if (PlayerPrefs.GetInt("GuardiansShieldUnlocked") == 1)
        {
            unlockedAchievement.SetActive(true);
        }
        if (PlayerPrefs.GetInt("CrystalbaneChampionUnlocked") == 1)
        {
            unlockedAchievement.SetActive(true);
        }
        if (PlayerPrefs.GetInt("CrystalbaneProfessionalUnlocked") == 1)
        {
            unlockedAchievement.SetActive(true);
        }
        if (PlayerPrefs.GetInt("CrystalbaneBeginnerUnlocked") == 1)
        {
            unlockedAchievement.SetActive(true);
        }
    }
}
