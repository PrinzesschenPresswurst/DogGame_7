using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 10f;
  
    void Update()
    {
        
        //transform.localPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + projectileSpeed);
        transform.localPosition += Vector3.forward * Time.deltaTime * projectileSpeed;
    }
}
