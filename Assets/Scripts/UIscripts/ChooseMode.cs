using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseMode : MonoBehaviour
{
    public void PlayStoryMode()
    {
        SceneManager.LoadScene("Story Mode");
        Time.timeScale = 1;
    }
    public void PlayInfiniteWorld()
    {
        SceneManager.LoadScene("Infinite World");
        Time.timeScale = 1;
    }
}
