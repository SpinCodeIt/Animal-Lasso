using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : Movement
{
    public float jumpSpeed;
    public Animator animator;
    public PlayerInput input;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitializeMovement();
    }

    void OnMove(InputValue value)
    {
        if (value.Get<Vector2>().magnitude > 0.1f)
        {
            MoveDirection(value.Get<Vector2>());
            animator.SetFloat("HorizontalSpeed", value.Get<Vector2>().magnitude);
            transform.rotation = Quaternion.Euler(0, Vector2.SignedAngle(value.Get<Vector2>(), Vector2.up), 0);
        }
        else
        {
            MoveDirection(Vector2.zero);
        }
    }

    void OnJump()
    {
        Jump(jumpSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (moveDirection.magnitude == 0f)
        {
            animator.SetFloat("HorizontalSpeed", GetHorizontalSpeed().magnitude);
        }
        MoveUpdate();

    }
}
