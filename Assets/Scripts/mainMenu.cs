using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        levelLoader.instance.LoadNextLevel();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NextDay()
    {
        gameManager.currentDay += 1;
        levelLoader.instance.LoadSpecificLevel(1);
    }
}
