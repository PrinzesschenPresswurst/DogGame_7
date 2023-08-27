using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{

    [SerializeField] private AudioClip flyThroughLoop;
    [SerializeField] private AudioClip collideWithTerrain;
    [SerializeField] private AudioClip enemyExplode;
    [SerializeField] private AudioClip playerDeath;
    [SerializeField] private AudioClip bossKill;
    [SerializeField] private AudioClip targetHit;
    [SerializeField] private AudioClip playerWin;
    private AudioSource _audioSource;

    private void Awake() // Singelton Pattern
    {
        int numberOfAudioHandlers = FindObjectsOfType<AudioHandler>().Length;
        if (numberOfAudioHandlers > 1)
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
        _audioSource = GetComponent<AudioSource>();
    }

    public void OnFlyThroughLoop()
    {
        _audioSource.PlayOneShot(flyThroughLoop);
    }

    public void OnTerrainCollide()
    {
        _audioSource.PlayOneShot(collideWithTerrain);
    }

    public void OnEnemyKill(int enemyType)
    {
        if (enemyType == 1) // cat
        {
            _audioSource.PlayOneShot(enemyExplode);
        }
        else if (enemyType == 2) // boss
        {
            _audioSource.PlayOneShot(bossKill);
        }
        
        else if (enemyType == 3) // taget
        {
            _audioSource.PlayOneShot(targetHit);
        }
    }

    public void OnPlayerDeath()
    {
        _audioSource.PlayOneShot(playerDeath);
    }

    public void OnGoalReached()
    {
        _audioSource.PlayOneShot(playerWin);
    }
    
}
