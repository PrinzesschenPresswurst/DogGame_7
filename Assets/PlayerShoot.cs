using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] float shootCooldown = 0.5f;
    private float _nextShot = 0.1f;
    


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            
            if (Time.time > _nextShot)
            {
                Debug.Log("shoot");
                Instantiate(projectile, transform.position, Quaternion.identity);
                _nextShot = Time.time + shootCooldown;
                Debug.Log("last shoot: " + _nextShot);
            }
        }
    }
    
}
