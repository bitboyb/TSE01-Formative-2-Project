using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;
    Vector2 velocity;

    private bool isRunning;

    private void Start()
    {
        isRunning = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && isRunning == false)
        {
            speed = speed + 4;
            isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) && isRunning == true)
        {
            speed = speed - 4;
            isRunning = false;
        }

        velocity.y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        velocity.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(velocity.x, 0, velocity.y);
    }
}
