using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Create a reference to whatever script is controlling the resource.
    public HealthChanger healthChanger;

    // Create a reference to the RectTransform component on the mask parent,
    // which behaves slightly differently from our normal transforms.
    public RectTransform healthBarMask;

    // Copy the width value from the RectTransform in the Inspector here.
    public float maxBarSize;

    void Update()
    {
        // Calculate the width of the bar
        float width = healthChanger.health / healthChanger.maxHealth * maxBarSize;

        // Apply width to the transform (assumes no anchoring)
        healthBarMask.sizeDelta = new Vector2(width, healthBarMask.sizeDelta.y);
    }
}
