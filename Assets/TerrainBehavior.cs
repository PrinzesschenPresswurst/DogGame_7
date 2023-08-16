using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TerrainBehavior : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystemPrefab;

    void OnCollisionEnter(Collision collision) 
    {
        if (collision.collider.CompareTag("Player"))
        {
            ContactPoint contact = collision.contacts[0];
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 position = contact.point;
            Instantiate(particleSystemPrefab, position, rotation);
            particleSystemPrefab.Play();
        }
    }
}
