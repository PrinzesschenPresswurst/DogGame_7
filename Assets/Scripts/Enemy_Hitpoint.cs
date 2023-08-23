using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class Enemy_Hitpoint : MonoBehaviour
{
    [Header("Score Stuff")]
    private ScoreKeeper _scoreKeeper;
    [SerializeField] private int scoreOnKill = 50;
    [SerializeField] private int scoreOnHit = 1;
    
    [Header ("HP Stuff")]
    [SerializeField] private int enemyHp = 5;
    
    [Header("Feedback Kill")]
    [SerializeField] private ParticleSystem enemyExplosionParticles;
    private AudioHandler _audioHandler;
    
    [Header("Enemy Type")]
    [SerializeField] private int enemyType = 1;
    
    private GameObject _spawnAtRuntime;

    private void Start()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
        _audioHandler = FindObjectOfType<AudioHandler>();
        _spawnAtRuntime = GameObject.FindWithTag("SpawnAtRuntime");
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("collisions: "+ other.gameObject.name);
        ProcessHit();
        CheckDeath();
    }

    private void ProcessHit()
    {
        _scoreKeeper.AddScore(scoreOnHit);
        enemyHp = enemyHp -1;
    }

    private void CheckDeath()
    {
        if (enemyHp <= 0)
        {
            var newExplosion = Instantiate(enemyExplosionParticles, transform.position, quaternion.identity);
            newExplosion.Play();
            newExplosion.transform.SetParent(_spawnAtRuntime.transform);
            _audioHandler.OnEnemyKill(enemyType);  //TODO make this different between target and cat 
            _scoreKeeper.AddScore(scoreOnKill);
            Destroy(this.gameObject);
        }
    }

    public int GetEnemyHp()
    {
        return enemyHp;
    }
}
