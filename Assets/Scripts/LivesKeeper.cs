using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class LivesKeeper : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI livesText;
    private float _lives;
    private PlayerDeathHandler _playerDeathHandler;
    private void Start()
    {
        _lives = 4;
        UpdateLives();
        _playerDeathHandler = FindObjectOfType<PlayerDeathHandler>();
    }

    private void UpdateLives()
    {
        livesText.text = "LIVES: " + _lives;
    }

    public void ReduceLives()
    {
        _lives--;
        UpdateLives();
        CheckDeath();
    }

    private void CheckDeath()
    {
        if (_lives <= 0)
        {
            _playerDeathHandler.PlayerDeathSequence();
        }
    }
}
