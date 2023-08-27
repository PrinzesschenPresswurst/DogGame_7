using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    private int _currentScene;

    private void Start()
    {
        _currentScene = SceneManager.GetActiveScene().buildIndex;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(_currentScene+1);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
