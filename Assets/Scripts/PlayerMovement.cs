using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : Movement
{
    public float jumpSpeed;
    public PlayerInput input;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitializeMovement();
    }

    void OnMove(InputValue value)
    {
        HorizontalMovement(value.Get<Vector2>());
    }

    void OnJump()
    {
        Jump(jumpSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        MoveUpdate();
    }
}
