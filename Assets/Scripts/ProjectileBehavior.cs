using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 10f;
  
    void Update()
    {
        transform.localPosition += Vector3.forward * Time.deltaTime * projectileSpeed;
    }
}
