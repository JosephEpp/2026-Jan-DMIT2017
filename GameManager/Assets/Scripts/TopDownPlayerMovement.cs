using System;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownPlayerMovement : MonoBehaviour
{
    public InputAction moveInput;
    private Vector2 movementDirection = Vector2.zero;
    public float movementSpeed = 1.0f;
    public event Action<Vector2> 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        moveInput.Enable();
        moveInput.performed += GetMoveVector();
        moveInput.canceled += GetMoveVector();
    }

    public void GetMoveVector(InputAction.CallbackContext context)
    {
        movementDirection = context.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = 
    }
}
