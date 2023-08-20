using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    [Header("Caching stuff")]
    private PlayerController _playerController;
    private PlayerShoot _playerShoot;
    private GameManager _gameManager;
    private AudioHandler _audioHandler;
    private Component[] _dogRenderers;
    
    [Header("Needed Particles")]
    [SerializeField] private ParticleSystem crashParticles;
    [SerializeField] private ParticleSystem trailParticle;
    
    
    void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _playerShoot = GetComponent<PlayerShoot>();
        _dogRenderers = GetComponentsInChildren<MeshRenderer>();
        _gameManager = FindObjectOfType<GameManager>();
        _audioHandler = FindObjectOfType<AudioHandler>();
    }

    public void PlayerDeathSequence()
    {
        _playerController.enabled = false;
        _playerShoot.enabled = false;
        trailParticle.Stop();
        crashParticles.Play();
        _audioHandler.OnPlayerDeath();
        foreach (Component dogRenderer in _dogRenderers)
        {
            dogRenderer.GetComponent<MeshRenderer>().enabled = false;
        }

        StartCoroutine(_gameManager.OnPlayerDeath());
    }
}
