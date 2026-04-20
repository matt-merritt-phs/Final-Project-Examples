using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    // Multiplier for how fast the camera move
    public float sensitivity;

    // Reference to the camera component that is a child of the player
    public Transform cameraTransform;

    // Values to represent current rotation around a given axis
    private float xRotation = 0;
    private float yRotation = 0;

    void Start()
    {
        // This line disables the mouse cursor, which is important so you don't click out
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp the range to prevent flipping

        yRotation += mouseX;

        // Rotation around the x-axis (pitch - up and down) - only on camera
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        // Rotation around the y-axis (yaw - side to side)
        transform.localRotation = Quaternion.Euler(0, yRotation, 0);
    }
}
