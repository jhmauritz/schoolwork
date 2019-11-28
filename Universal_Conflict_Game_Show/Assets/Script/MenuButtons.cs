using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
   public void StartGame()
    {
        Application.LoadLevel("Level (1)");
    }

    public void Credits()
    {
        Application.LoadLevel("Credits");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        Application.LoadLevel(0);
    }
}
