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
    private TextMeshPro _hpText;
    
    [Header("Feedback Kill")]
    [SerializeField] private ParticleSystem enemyExplosionParticles;
    private AudioHandler _audioHandler;

    [Header("Feedback Hit")]
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material hitMaterial;
    [SerializeField] private ParticleSystem enemyHitParticles;
    private MeshRenderer _meshRenderer;
    [SerializeField] private bool enemyIsBoss = false;

    private void Start()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
        _audioHandler = FindObjectOfType<AudioHandler>();
        if (enemyIsBoss!)
        {
            _hpText = GetComponentInChildren<TextMeshPro>();
            _hpText.text = enemyHp.ToString();
        }
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("collisions: "+ other.gameObject.name);
        ProcessHit();
        CheckDeath();
    }

    private void ProcessHit() // TODO extract into own script that is only on boss
    {
        _scoreKeeper.AddScore(scoreOnHit);
        enemyHp = enemyHp -1;
        if (enemyIsBoss!)
        {
            _hpText.text = enemyHp.ToString();
            StartCoroutine(EnemyHitFeedback());
        }
    }
    
    private IEnumerator EnemyHitFeedback()
    {
        var newHitExplosion = Instantiate(enemyHitParticles, transform.position, quaternion.identity);
        newHitExplosion.Play();
        _meshRenderer.material = hitMaterial;
        yield return new WaitForSeconds(0.1f);
        _meshRenderer.material = defaultMaterial;
    }

    private void CheckDeath()
    {
        if (enemyHp <= 0)
        {
            var newExplosion = Instantiate(enemyExplosionParticles, transform.position, quaternion.identity);
            newExplosion.Play();
            _audioHandler.OnEnemyKill();  //TODO make this different between target and cat 
            _scoreKeeper.AddScore(scoreOnKill);
            Destroy(this.gameObject);
        }
    }
}
