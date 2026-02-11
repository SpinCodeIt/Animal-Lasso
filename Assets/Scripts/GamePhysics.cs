using UnityEngine;

public class GamePhysics : MonoBehaviour
{
    //Components
    private Rigidbody rb;
    //Physics Variables
    private float gravity = 0.1f;
    private float xspeed;
    private float yspeed;
    private float zspeed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected void InitializePhysics()
    {
        rb = GetComponent<Rigidbody>();
    }

    //Checks if the rigidbody is grounded
    private float Grounded()
    {
        RaycastHit hit;
        if (rb.SweepTest(Vector3.down, out hit, -yspeed * Time.deltaTime))
        {
            return -hit.distance;
            
        }
        return yspeed ;
    }
    
    protected void Jump(float JumpSpeed)
    {
        yspeed = JumpSpeed;
    }

    protected Vector2 GetHorizontalSpeed()
    {
        return new Vector2(xspeed, zspeed);
    }
    protected void HorizontalMovement(Vector2 HorizontalSpeed)
    {
        xspeed = HorizontalSpeed.x;
        zspeed = HorizontalSpeed.y;
    }

    // Update is called once per frame
    protected void PhysicsUpdate()
    {
        //Gravity
        yspeed -= gravity;
        yspeed = Grounded();
        rb.MovePosition(rb.position + new Vector3(xspeed, yspeed, zspeed) * Time.deltaTime);
    }

}
