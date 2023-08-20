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
    private AudioSource _audioSource;

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

    public void OnEnemyKill()
    {
        _audioSource.PlayOneShot(enemyExplode);
    }

    public void OnPlayerDeath()
    {
        _audioSource.PlayOneShot(playerDeath);
    }
    
}
