using UnityEngine;

public class Movement : GamePhysics
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected void InitializeMovement()
    {
        InitializePhysics();
    }

    // Update is called once per frame
    protected void MoveUpdate()
    {
        PhysicsUpdate();
    }
}
