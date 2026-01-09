using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputAction moveInput;
    private Vector3 movementDirection = Vector3.zero;
    [SerializeField] private float moveSpeed = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveInput.Enable();
        moveInput.performed += GetMoveVector;
        moveInput.canceled += GetMoveVector;
    }

    public void GetMoveVector(InputAction.CallbackContext context)
    {
        var tmp = context.ReadValue<Vector2>();

        movementDirection = new Vector3(tmp.x, 0, tmp.y);
    }

    public void Update()
    {
        transform.position += movementDirection * moveSpeed * Time.deltaTime;
    }
}
