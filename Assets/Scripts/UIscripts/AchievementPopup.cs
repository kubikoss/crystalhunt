using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class AchievementPopup : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI popupText;

    void Awake()
    {
        Hide();
    }
    public void Show(string message)
    {
        popupText.gameObject.SetActive(true);
        popupText.text = message;
        StartCoroutine(HideAfterDelay(5f));
    }

    public void Hide()
    {
        popupText.gameObject.SetActive(false);
    }
    IEnumerator HideAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Hide();
    }
}
