using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Build;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private ScoreKeeper _scoreKeeper;
    [SerializeField] private ParticleSystem enemyExplosionParticles;
    [SerializeField] private GameObject parent;
    [SerializeField] private int scoreOnKill = 50;

    private void Start()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void OnParticleCollision(GameObject other)
    {
        _scoreKeeper.AddScore(scoreOnKill);
        var newExplosion = Instantiate(enemyExplosionParticles, transform.position, quaternion.identity);
        newExplosion.transform.SetParent(parent.transform);
        newExplosion.Play();
        Destroy(this.gameObject);
    }
}
