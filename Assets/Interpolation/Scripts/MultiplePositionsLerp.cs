using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MultiplePositionsLerp : MonoBehaviour
{
    public List<Vector3> locations;
    public int targetLocationIndex;
    public float movementDuration;

    public Vector3 moveStartLocation;
    public bool isMoving;
    public float currentTimeMoving;

    void Start()
    {
        moveStartLocation = transform.position;
    }

    void Update()
    {
        // start movement when space is pressed
        if (Input.GetKeyDown(KeyCode.Alpha1) && targetLocationIndex != 0)
        {
            targetLocationIndex = 0;
            currentTimeMoving -= movementDuration;
            isMoving = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && targetLocationIndex != 1)
        {
            targetLocationIndex = 1;
            currentTimeMoving -= movementDuration;
            isMoving = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && targetLocationIndex != 2)
        {
            targetLocationIndex = 2;
            currentTimeMoving -= movementDuration;
            isMoving = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && targetLocationIndex != 3)
        {
            targetLocationIndex = 3;
            currentTimeMoving -= movementDuration;
            isMoving = true;
        }

        // mark as not moving once target is reached
        if (currentTimeMoving > movementDuration)
        {
            currentTimeMoving = movementDuration; // adjust value to not go over
            isMoving = false;
            moveStartLocation = transform.position;
        }

        // count how long we have been moving
        if (isMoving)
        {
            currentTimeMoving += Time.deltaTime;
        }

        transform.position = Vector3.Lerp(moveStartLocation, locations[targetLocationIndex], currentTimeMoving / movementDuration);
    }
}
