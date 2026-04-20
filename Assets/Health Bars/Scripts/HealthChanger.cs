using UnityEngine;

public class HealthChanger : MonoBehaviour
{
    // Assume that your player or some other script would handle this.
    // This is just a demonstration that will have health count down when space is pressed.
    public float health = 100;
    // The max value is necessary to calculate the percentage used.
    public float maxHealth = 100;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            health -= 10;
        }
    }
}
