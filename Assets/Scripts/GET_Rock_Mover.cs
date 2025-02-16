
using UnityEngine;

public class MoveRock : MonoBehaviour
{
    public float baseMoveSpeed = 0.5f; // Default slow speed
    public float maxMoveSpeed = 2f; // Maximum speed when holding the M key
    private float currentMoveSpeed; // Current speed of the rock
    private bool isPlayerNear = false; // Check if player is near the object
    private GameObject player; // The player object

    void Start()
    {
        player = GameObject.FindWithTag("Player"); // Find the player by tag
        currentMoveSpeed = baseMoveSpeed; // Initialize current speed to base speed
    }

    void Update()
    {
        // Check if the player is near the rock and the "M" key is pressed or held down
        if (isPlayerNear && Input.GetKey(KeyCode.M))
        {
            // Increase speed as the "M" key is held
            currentMoveSpeed = Mathf.Lerp(baseMoveSpeed, maxMoveSpeed, Time.time);
            MoveRockAlongX();
        }
        else if (isPlayerNear && Input.GetKeyUp(KeyCode.M))
        {
            // Reset to base speed when the "M" key is released
            currentMoveSpeed = baseMoveSpeed;
        }
    }

    void MoveRockAlongX()
    {
        // Move the rock along the X-axis using the current speed
        transform.Translate(Vector3.right * currentMoveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the rock's trigger area
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the player leaves the rock's trigger area
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }
}
