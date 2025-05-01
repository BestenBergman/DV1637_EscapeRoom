using UnityEngine;

public class T_GateController : MonoBehaviour
{
    public GameObject triggerSource;

    public bool isOpen;
    private GameObject objectToControl;

    // Possible trigger components
    private T_HourglassTimer hourglass;
    private O_KeyPadActivate keypad;
    private T_PressurePlate pressurePlate;

    private void Start()
    {
        // Assume the door is the first child
        objectToControl = transform.GetChild(0).gameObject;

        // Set initial door state based on tag
        if (CompareTag("R1_Door"))
        {
            isOpen = true;
        }
        else
        {
            isOpen = false;
        }

        objectToControl.SetActive(!isOpen);


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
            SetObjectState(false); // Close door when hourglass/timer is active
            return;
        }

        if (keypad != null && keypad.keyPadComplete == true)
        {
            SetObjectState(true); // Open door when keypad is complete
            return;
        }

        if (pressurePlate != null)
        {
            SetObjectState(pressurePlate.isPressed); // Open/close based on plate
        }
    }

    private void SetObjectState(bool open)
    {
        if (isOpen == open) return; // No change needed

        isOpen = open;
        Animation();
        
    }


    private void Animation()
    {
        //Dont have animation...
        objectToControl.SetActive(!isOpen);
    }
}
