using UnityEngine;

public class SimpleMoveLerp : MonoBehaviour
{
    public Vector3 startLocation, endLocation;
    public float movementDuration;

    public bool isMoving;
    public float currentTimeMoving;

    void Update()
    {
        // start movement when space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Started movement");
            isMoving = true;
        }

        // mark as not moving once target is reached
        if (currentTimeMoving > movementDuration)
        {
            Debug.Log("Completed movement");
            isMoving = false;
        }

        // count how long we have been moving
        if (isMoving)
        {
            currentTimeMoving += Time.deltaTime;
        }

        transform.position = Vector3.Lerp(startLocation, endLocation, currentTimeMoving / movementDuration);
    }
}
