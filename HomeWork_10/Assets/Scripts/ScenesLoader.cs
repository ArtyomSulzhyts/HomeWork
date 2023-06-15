using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesLoader : MonoBehaviour
{
    public void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
