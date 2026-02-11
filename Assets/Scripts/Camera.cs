using UnityEngine;

public class Camera : Movement
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
        InitializeMovement(5f, 4f, 1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(new Vector2(target.position.x, target.position.z) - new Vector2(transform.position.x, transform.position.z));
        MoveDirection((new Vector2(0f, target.position.z) - new Vector2(0f, transform.position.z)).normalized);
        //transform.rotation = Quaternion.Euler(0, Vector2.SignedAngle(moveDirection, Vector2.up), 0);
        //Debug.Log(moveDirection);
        MoveUpdate();

    }
}
