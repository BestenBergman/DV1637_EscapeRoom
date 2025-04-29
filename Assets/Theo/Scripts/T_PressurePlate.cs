using UnityEngine;

/// <summary>
/// This class represents a pressure plate trigger in Unity.
/// It sets a bool value when a specific object (Player or R3_Box) enters or exits its trigger collider.
/// </summary>
public class T_PressurePlate : MonoBehaviour
{
    // Indicates whether the pressure plate is currently being pressed
    public bool isPressed = false;

    // Count of objects currently on the plate
    private int pressCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "R3_Box" || other.tag == "Player")
        {
            pressCount++;

            // Set the isPressed to true when either of the tag objects steps on the plate
            isPressed = true;
        }

        //if (other.tag == "R3_Box")
        //{
        //    Debug.Log("Box");
        //}
        //if (other.tag == "Player")
        //{
        //    Debug.Log("Player");
        //}
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
