using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    [Header("Crash Feedback")] 
    private Component[] _dogRenderers;
    [SerializeField] private ParticleSystem crashParticles;
    [SerializeField] private Material crashMaterial;
    [SerializeField] private ParticleSystem trailParticle;

    [Header("Scores")] [SerializeField] private int scoreOnLoop = 100;
    [SerializeField] private int scoreOnCrashTerrain = -5;

    private PlayerController _playerController;
    private PlayerShoot _playerShoot;
    private ScoreKeeper _scoreKeeper;
    private LivesKeeper _livesKeeper;
    
    private TreeInstance[] _treeInstances;
    private TerrainData _terrain;


    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _playerShoot = GetComponent<PlayerShoot>();
        _dogRenderers = GetComponentsInChildren<MeshRenderer>();
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
        _livesKeeper = FindObjectOfType<LivesKeeper>();
        
        
        _terrain = Terrain.activeTerrain.terrainData;
        _treeInstances =  _terrain.treeInstances;
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Enemy":
                StartCoroutine(DeathSequence());
                Debug.Log("Collision " + other.gameObject.tag);
                other.gameObject.GetComponent<MeshRenderer>().material = crashMaterial;
                break;

            case "Terrain":
                _scoreKeeper.ReduceScore(scoreOnCrashTerrain);
                _livesKeeper.ReduceLives();
                Debug.Log("Collision " + other.gameObject.tag);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Loop":
                _scoreKeeper.AddScore(scoreOnLoop);
                Debug.Log("trigger " + other.gameObject.tag);
                break;
        }
    }

    private IEnumerator DeathSequence()
    {
        _playerController.enabled = false;
        _playerShoot.enabled = false;
        trailParticle.Stop();
        crashParticles.Play();
        foreach (Component dogRenderer in _dogRenderers)
        {
            dogRenderer.GetComponent<MeshRenderer>().enabled = false;
        }

        yield return new WaitForSeconds(1f);
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}