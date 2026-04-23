using UnityEngine;

public class TwoWayMovementLerp : MonoBehaviour
{
    public Vector3 startLocation, endLocation;
    public float movementDuration;

    public bool isMoving;
    public bool isMovingForward;
    public float currentTimeMoving;

    void Update()
    {
        // start movement when space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMoving = true;
            isMovingForward = !isMovingForward; // flips the direction we are moving
        }

        // mark as not moving once target is reached
        if (currentTimeMoving > movementDuration)
        {
            currentTimeMoving = movementDuration; // adjust value to not go over
            isMoving = false;
        }
        if (currentTimeMoving < 0)
        {
            currentTimeMoving = 0; // adjust the value to not go under
            isMoving = false;
        }

        // count how long we have been moving
        if (isMoving)
        {
            if (isMovingForward)
            {
                currentTimeMoving += Time.deltaTime;
            }
            else
            {
                currentTimeMoving -= Time.deltaTime;
            }
        }

        transform.position = Vector3.Lerp(startLocation, endLocation, currentTimeMoving / movementDuration);
    }
}
