using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
    private int currentScene;
    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(currentScene);
    }
    public void NextScene()
    {
        SceneManager.LoadScene(currentScene+1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
