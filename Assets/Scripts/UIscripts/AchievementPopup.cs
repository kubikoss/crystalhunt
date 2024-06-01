using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class AchievementPopup : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI popupText;
    [SerializeField]
    Canvas canvas;
    public AudioController audioController;

    void Awake()
    {
        Hide();
    }
    public void Show(string message)
    {
        canvas.enabled = true;
        audioController.PlayAchievementSound();
        popupText.gameObject.SetActive(true);
        popupText.text = message;
        StartCoroutine(HideAfterDelay(3.5f));
    }

    public void Hide()
    {
        popupText.gameObject.SetActive(false);
        canvas.enabled = false;
    }
    IEnumerator HideAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Hide();
    }
}
