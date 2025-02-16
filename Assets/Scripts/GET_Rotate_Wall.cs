using UnityEngine;

public class RotateOnClick : MonoBehaviour
{
    public float rotationSpeed = 45f; // How fast the object rotates, degrees per second
    private bool isClicked = false;

    void OnMouseDown()
    {
        // Toggle the rotation state when clicked
        isClicked = !isClicked;
    }

    void Update()
    {
        if (isClicked)
        {
            // Rotate the object around the Y-axis (for example) when clicked
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }
}
