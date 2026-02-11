using UnityEngine;

public class Movement : GamePhysics
{
    public float acceleration;
    public float deceleration;
    public float maxspeed;
    private Vector2 moveDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected void InitializeMovement()
    {
        InitializePhysics();
    }

    protected void MoveDirection(Vector2 MoveDirection)
    {
        moveDirection = MoveDirection;
    }

    private void Accelerate()
    {   //If Accelerating to above Maxspeed, slow down until reaching maxspeed;
        if ((GetHorizontalSpeed() + moveDirection * acceleration * Time.deltaTime).magnitude > maxspeed)
        {
            HorizontalMovement((GetHorizontalSpeed() + moveDirection * acceleration * Time.deltaTime).normalized * (GetHorizontalSpeed().magnitude - acceleration * Time.deltaTime));
            if (GetHorizontalSpeed().magnitude < maxspeed)
            {
                HorizontalMovement(GetHorizontalSpeed().normalized * maxspeed);
            }
        }
        else
        {
            //If below maxspeed, accelerate until reaching maxspeed;
            HorizontalMovement((GetHorizontalSpeed() + moveDirection * acceleration * Time.deltaTime));
            if (GetHorizontalSpeed().magnitude > maxspeed)
            {
                HorizontalMovement(GetHorizontalSpeed().normalized * maxspeed);
            }
        }
    }

    private void Decelerate()
    {
        HorizontalMovement(GetHorizontalSpeed().normalized * (GetHorizontalSpeed().magnitude - deceleration * Time.deltaTime));
        if (GetHorizontalSpeed().magnitude <= deceleration * Time.deltaTime)
        {
            HorizontalMovement(Vector2.zero);
        }
    }

    // Update is called once per frame
    protected void MoveUpdate()
    {
        //HorizontalMovement(GetHorizontalSpeed() + moveDirection * acceleration * Time.deltaTime);
        //Deceleration
        Decelerate();
        //Acceleration
        Accelerate();
        PhysicsUpdate();
    }
}
