using UnityEngine;

public class WhiteHorseMovement : Movement
{
    private Transform target;
    private float turnspeed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
        MoveDirection(new Vector2(0, 1f));
        InitializeMovement(15f, 5f, 1f, 0f);
    }

    override public void Accelerate()
    {
        HorizontalMovement(moveDirection * GetHorizontalSpeed().magnitude);
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
        HorizontalMovement(moveDirection * GetHorizontalSpeed().magnitude);
    }

    override public void Decelerate()
    {
        HorizontalMovement(moveDirection * GetHorizontalSpeed().magnitude);
        HorizontalMovement(GetHorizontalSpeed().normalized * (GetHorizontalSpeed().magnitude - deceleration * Time.deltaTime));
        if (GetHorizontalSpeed().magnitude <= deceleration * Time.deltaTime)
        {
            HorizontalMovement(Vector2.zero);
        }
        HorizontalMovement(moveDirection * GetHorizontalSpeed().magnitude);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetVector = (new Vector3(target.position.x, 0f, target.position.z) - new Vector3(transform.position.x, 0f, transform.position.z)).normalized;
        //Debug.Log(targetVector);
        //Debug.Log(new Vector2(target.position.x, target.position.z) - new Vector2(transform.position.x, transform.position.z));
        Vector3 movementVector = Vector3.RotateTowards(new Vector3(moveDirection.x, 0f, moveDirection.y), targetVector, turnspeed * Time.deltaTime, 0f).normalized;
        //Debug.Log(movementVector);
        MoveDirection(new Vector2(movementVector.x, movementVector.z));
        transform.rotation = Quaternion.Euler(0, Vector2.SignedAngle(moveDirection, Vector2.up), 0);
        //Debug.Log(moveDirection);
        MoveUpdate();

    }
}
