using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Rendering.HighDefinition;

public class PlayerCollision : MonoBehaviour
{
    [Header("Scores")] 
    [SerializeField] private int scoreOnLoop = 100;
    [SerializeField] private int scoreOnCrashTerrain = -5;
    [SerializeField] private int scoreOnCrashEnemy = -10;

    [Header("Caching stuff")]
    private ScoreKeeper _scoreKeeper;
    private LivesKeeper _livesKeeper;
    private PlayerDeathHandler _playerDeathHandler;
    private AudioHandler _audioHandler;

    private void Start()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
        _livesKeeper = FindObjectOfType<LivesKeeper>();
        _playerDeathHandler = GetComponent<PlayerDeathHandler>();
        _audioHandler = FindObjectOfType<AudioHandler>();
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Enemy":
                _scoreKeeper.ReduceScore(scoreOnCrashEnemy);
                _livesKeeper.ReduceLives();
                _audioHandler.OnTerrainCollide();
                break;

            case "Terrain":
                _scoreKeeper.ReduceScore(scoreOnCrashTerrain);
                _livesKeeper.ReduceLives();
                _audioHandler.OnTerrainCollide();
                break;
            
            case "Obstacle":
                _playerDeathHandler.PlayerDeathSequence();
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Loop":
                _scoreKeeper.AddScore(scoreOnLoop);
                _audioHandler.OnFlyThroughLoop();
                break;
        }
    }
}