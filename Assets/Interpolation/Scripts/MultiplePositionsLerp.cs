using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MultiplePositionsLerp : MonoBehaviour
{
    public List<Vector3> locations;
    public int targetLocationIndex;
    public float movementDuration;

    private Vector3 moveStartLocation;
    private bool isMoving;
    private float currentTimeMoving;

    void Start()
    {
        moveStartLocation = transform.position;
    }

    void Update()
    {
        // start movement when space is pressed
        if (Input.GetKeyDown(KeyCode.Alpha1) && targetLocationIndex != 0)
        {
            moveStartLocation = transform.position;
            targetLocationIndex = 0;
            currentTimeMoving = 0;
            isMoving = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && targetLocationIndex != 1)
        {
            moveStartLocation = transform.position;
            targetLocationIndex = 1;
            currentTimeMoving = 0;
            isMoving = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && targetLocationIndex != 2)
        {
            moveStartLocation = transform.position;
            targetLocationIndex = 2;
            currentTimeMoving = 0;
            isMoving = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && targetLocationIndex != 3)
        {
            moveStartLocation = transform.position;
            targetLocationIndex = 3;
            currentTimeMoving = 0;
            isMoving = true;
        }

        // mark as not moving once target is reached
        if (currentTimeMoving > movementDuration)
        {
            isMoving = false;
        }

        // count how long we have been moving
        if (isMoving)
        {
            currentTimeMoving += Time.deltaTime;
        }

        transform.position = Vector3.Lerp(moveStartLocation, locations[targetLocationIndex], currentTimeMoving / movementDuration);
    }
}
