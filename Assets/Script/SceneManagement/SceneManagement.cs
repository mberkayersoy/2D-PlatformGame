using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void ReloadGame()
    {
        Cursor.visible = false;
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void Menu() 
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

