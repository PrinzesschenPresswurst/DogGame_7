using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private InputAction movement;
    [SerializeField] private float moveSpeed = 20f;
    
    [Header("Rotation")]
    [SerializeField] private float pitchFactor = 30f;
    [SerializeField] private float yawFactor = 30f;
    [SerializeField] private float rollFactor = 30f;
    [SerializeField] private float positionPitchFactor = 0.5f;

    private float _inputH;
    private float _inputV;
    private Vector3 _currentPos;

    private void OnEnable()
    {
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }

    private void Start()
    {
        transform.Translate(Vector3.zero);
    }

    private void Update()
    {
        //Get input from input system
        _inputH = movement.ReadValue<Vector2>().x;
        _inputV = movement.ReadValue<Vector2>().y;
        _currentPos = transform.localPosition;
        
        HandleMovement();
        AddRotation();
    }
    
    private void HandleMovement()
    {
        // make input a controllable number
        float translateX = _inputH * Time.deltaTime * moveSpeed;
        float translateY = _inputV * Time.deltaTime * moveSpeed;

        //define the new pos and clamp it so dog doesnt go off the screen
        float newXPos = _currentPos.x + translateX;
        float clampedNewXPos = Mathf.Clamp(newXPos, -10f, 10f);
        float newYPos = _currentPos.y + translateY;
        float clampedNewYPos = Mathf.Clamp(newYPos,-5f,5.5f);
       
        // actually move
        transform.localPosition = new Vector3(clampedNewXPos, clampedNewYPos, 0);
    }
    
    private void AddRotation()
    {
        
        float pitch = pitchFactor * _inputV + transform.localPosition.y * positionPitchFactor;
        float yaw = _currentPos.x * yawFactor ;
        float roll = _inputH * rollFactor;
        
       transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }
}
