using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Mathematics;

public class Enemy_Boss : MonoBehaviour
{
    private TextMeshPro _hpText;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material hitMaterial;
    [SerializeField] private ParticleSystem enemyHitParticles;
    [SerializeField] private MeshRenderer hitFeedbackMeshRenderer;
    private Enemy_Hitpoint _enemyHitpoint;
    private int enemyHp;

    private void Start()
    {
        _hpText = GetComponentInChildren<TextMeshPro>();
        _enemyHitpoint = GetComponent<Enemy_Hitpoint>();
        enemyHp = _enemyHitpoint.GetEnemyHp();
        _hpText.text = enemyHp.ToString();
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("collisions: "+ other.gameObject.name);
        ProcessHit();
    }

    public void ProcessHit() 
    {
        enemyHp = _enemyHitpoint.GetEnemyHp();
        _hpText.text = enemyHp.ToString();
        StartCoroutine(EnemyHitFeedback());
    }
    
    private IEnumerator EnemyHitFeedback()
    {
        var newHitExplosion = Instantiate(enemyHitParticles, transform.position,quaternion.identity);
        newHitExplosion.Play();
        hitFeedbackMeshRenderer.material = hitMaterial;
        yield return new WaitForSeconds(0.1f);
        hitFeedbackMeshRenderer.material = defaultMaterial;
    }
}
