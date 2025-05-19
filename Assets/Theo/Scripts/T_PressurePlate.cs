using UnityEngine;

/// <summary>
/// This class represents a pressure plate trigger.
/// It sets a bool value when a specific object (Player or R3_Box) enters or exits its trigger collider.
/// </summary>
public class T_PressurePlate : MonoBehaviour
{
    // If the pressure plate is currently being pressed.
    public bool isPressed = false;

    // Number of objects currently on the plate.
    private int pressCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "R3_Box" || other.tag == "Player")
        {
            pressCount++;
            isPressed = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "R3_Box" || other.tag == "Player")
        {
            pressCount--;
            if (pressCount < 0)
            {
                pressCount = 0;
            }

            if (pressCount > 0)
            {
                isPressed = true;
            }
            else
            {
                isPressed = false;
            }
        }
    }

}
