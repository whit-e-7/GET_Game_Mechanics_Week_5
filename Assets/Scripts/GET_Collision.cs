using UnityEngine;

public class GET_Collision : MonoBehaviour
{
    public AudioClip collisionSound;  // Reference to the sound clip you want to play
    private AudioSource audioSource;  // Reference to the AudioSource component
    private GameManager gameManager;  // Reference to the GameManager script

    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // If no AudioSource is attached, add one dynamically
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Find the GameManager in the scene
        gameManager = FindObjectOfType<GameManager>();
    }

    // This will be called when another collider enters this object's trigger.
    void OnTriggerEnter(Collider other)
    {
        // If the object that collided with this object has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Play the collision sound
            if (collisionSound != null)
            {
                audioSource.PlayOneShot(collisionSound);
            }

            // Increase the score by 100
            if (gameManager != null)
            {
                gameManager.AddScore(100);
            }

            // Destroy the object with the "TriggerObject" tag when the player enters its trigger
            Destroy(gameObject);

            // Show trigger feedback in Console Window
            print("Player Entered Trigger and TriggerObject Destroyed");
        }
    }

    // This will be called when another collider stays inside this object's trigger.
    void OnTriggerStay(Collider other)
    {
        // If the object that stayed in this trigger has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Optionally, add more behavior here while the player is inside the trigger
            print("Player Staying in Trigger");
        }
    }

    // This will be called when another collider exits this object's trigger.
    void OnTriggerExit(Collider other)
    {
        // If the object that exited the trigger has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Optionally, destroy the object if needed
            // Destroy(gameObject);

            // Show trigger feedback in Console Window
            print("Player Exited Trigger");
        }
    }
}