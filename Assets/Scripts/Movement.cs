using UnityEngine;

public class Movement : GamePhysics
{
    public float acceleration { get; private set; }
    public float deceleration { get; private set; }
    public float maxspeed { get; private set; }
    public Vector2 moveDirection { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected void InitializeMovement(float Maxspeed, float Acceleration, float Deceleration, float Gravity)
    {
        maxspeed = Maxspeed;
        acceleration = Acceleration;
        deceleration = Deceleration;
        InitializePhysics(Gravity);
    }

    protected void MoveDirection(Vector2 MoveDirection)
    {
        moveDirection = MoveDirection;
    }

    virtual public void Accelerate()
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

    virtual public void Decelerate()
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
