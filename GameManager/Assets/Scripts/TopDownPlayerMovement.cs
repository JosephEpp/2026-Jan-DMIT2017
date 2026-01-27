using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownPlayerMovement : MonoBehaviour
{

    public InputAction moveInput;
    private Vector2 movementDirection = Vector2.zero;
    public float moveSpeed = 1.0f;
    public event Action<Vector2> OnMove;
    
    void Awake()
    {
        moveInput.Enable();
        moveInput.performed += GetMoveVector;
        moveInput.canceled += GetMoveVector;
    }

    public void GetMoveVector(InputAction.CallbackContext context)
    {
        movementDirection = context.ReadValue<Vector2>();
        OnMove?.Invoke(movementDirection);
         
    }

    public void Update()
    {
        transform.position += new Vector3(movementDirection.x, movementDirection.y, 0) * moveSpeed * Time.deltaTime;
    }
}
