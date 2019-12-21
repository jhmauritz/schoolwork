using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
   public void StartGame()
    {
        SceneManager.LoadScene("Level (1)");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartLevel1()
    {
        SceneManager.LoadScene("Level (1)");
    }

    public void RestartLevel2()
    {
        SceneManager.LoadScene("Level (2)");
    }

    public void RestartLevel3()
    {
        SceneManager.LoadScene("Level (3)");
    }

    public void ControlsMenu()
    {
        SceneManager.LoadScene("ControlsMenu");
    }
}
