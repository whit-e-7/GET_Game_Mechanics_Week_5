using UnityEngine;
using UnityEngine.UI;  // Import this if using Unity's standard UI Text (not TextMeshPro)

public class ShowKeysPressed : MonoBehaviour
{
    public Text keysPressedText;  // Reference to the Text UI component
    private string keysPressed = "";  // String to hold all pressed keys

    void Update()
    {
        // Check if any key is pressed and update the string
        if (Input.anyKeyDown)
        {
            foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
            {
                // Check if this key was pressed in the current frame
                if (Input.GetKeyDown(key))
                {
                    keysPressed += key.ToString() + " ";  // Add key to the display string
                }
            }

            // Update the UI Text with the pressed keys
            keysPressedText.text = "Keys Pressed: " + keysPressed;
        }
    }
}
