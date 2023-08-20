using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Laser")]
    [SerializeField] private GameObject[] laserParticles;
    private LaserSounds _laserSounds;
    
    [Header("Projectile")]
    [SerializeField] private GameObject projectile;
    [SerializeField] private float shootCooldown = 0.5f;
    private float _nextShot = 0.1f;

    private void Start()
    {
        _laserSounds = FindObjectOfType<LaserSounds>();
    }

    private void Update()
    {
        ShootProjectile();
        ShootLaser();
    }

    private void ShootLaser()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (var laser in laserParticles)
            {
                var laserSystem = laser.GetComponent<ParticleSystem>();
                laserSystem.Play();
                _laserSounds.OnLaserFire();
            }
        }
        
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            foreach (var laser in laserParticles)
            {
                var laserSystem = laser.GetComponent<ParticleSystem>();
                laserSystem.Stop();
                _laserSounds.OnLaserRelease();
            }
        };
    }

    private void ShootProjectile()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (Time.time > _nextShot)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                _nextShot = Time.time + shootCooldown;
            }
        }
    }
}
