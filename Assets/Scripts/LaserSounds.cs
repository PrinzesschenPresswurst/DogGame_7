using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSounds : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void OnLaserFire()
    {
        _audioSource.Play();
    }

    public void OnLaserRelease()
    {
        _audioSource.Stop();
    }
}
