using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private float _score;
    
    private void Awake() // Singelton Pattern
    {
        int numberOfScorekeepers = FindObjectsOfType<ScoreKeeper>().Length;
        if (numberOfScorekeepers > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        _score = 0;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "SCORE: " + _score;
    }

    public void AddScore(int amountToAdd)
    {
        _score = _score + amountToAdd;
        UpdateScore();
    }

    public void ReduceScore(int amountToReduce)
    {
        _score = _score - amountToReduce;
        UpdateScore();
    }
}
