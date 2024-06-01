using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    GameObject blud;
    private void Start()
    {
    }
    public void ShowBlud()
    {
        if (blud.gameObject.CompareTag("Player"))
        {
            blud.SetActive(true);
        }
    }
    public void HideBlud()
    {
        if (blud.gameObject.CompareTag("Player"))
        {
            blud.SetActive(false);
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
