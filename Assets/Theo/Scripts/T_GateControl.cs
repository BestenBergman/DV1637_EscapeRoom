using UnityEngine;

public class T_GateControl : MonoBehaviour
{
    public GameObject triggerSource;
    
    public bool isDoorOpen;
    private GameObject door;

    // Possible trigger components
    private T_HourglassTimer hourglass;
    private O_KeyPadActivate keypad;
    private T_PressurePlate pressurePlate;

    private void Start()
    {
        // Assume the door is the first child
        door = transform.GetChild(0).gameObject;

        // Set initial door state based on tag
        if (CompareTag("R1_Door"))
        {
            isDoorOpen = true;
        }
        else
        {
            isDoorOpen = false;
        }

        door.SetActive(!isDoorOpen);


        if (triggerSource != null)
        {
            hourglass = triggerSource.GetComponent<T_HourglassTimer>();
            keypad = triggerSource.GetComponent<O_KeyPadActivate>();
            pressurePlate = triggerSource.GetComponent<T_PressurePlate>();
        }
    }

    private void Update()
    {
        if (hourglass != null && hourglass.startTimer == true)
        {
            SetDoorState(false); // Close door when hourglass/timer is active
            return;
        }

        if (keypad != null && keypad.keyPadComplete == true)
        {
            SetDoorState(true); // Open door when keypad is complete
            return;
        }

        if (pressurePlate != null)
        {
            SetDoorState(pressurePlate.isPressed); // Open/close based on plate
        }
    }

    private void SetDoorState(bool openDoor)
    {
        if (isDoorOpen == openDoor) return; // No change needed

        isDoorOpen = openDoor;
        DoorAnimation();
        
    }


    private void DoorAnimation()
    {
        //Dont have door animation...
        door.SetActive(!isDoorOpen);
    }
}
