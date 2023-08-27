using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Canvas gameOverCanvas;
    [SerializeField] private Canvas winCanvas;
    private int _currentScene;
    private AudioHandler _audioHandler;

    private void Start()
    {
        gameOverCanvas.enabled = false;
        winCanvas.enabled = false;
        _currentScene = SceneManager.GetActiveScene().buildIndex;
        _audioHandler = FindObjectOfType<AudioHandler>();
    }

    public IEnumerator OnPlayerDeath()
    {
        gameOverCanvas.enabled = true;
        yield return new WaitForSeconds(1.5f);
        
        SceneManager.LoadScene(_currentScene);
    }

    public IEnumerator OnPlayerReachedGoal()
    {
        int scenes = SceneManager.sceneCountInBuildSettings;
        Debug.Log("scnens: "+scenes);
        Debug.Log("current: " +_currentScene);
        winCanvas.enabled = true;
        _audioHandler.OnGoalReached();
        
        yield return new WaitForSeconds(1f);

        if (_currentScene < scenes-1)
        {
            SceneManager.LoadScene(_currentScene + 1);
        }

        else SceneManager.LoadScene(0);
    }
}
