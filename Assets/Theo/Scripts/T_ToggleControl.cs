using UnityEngine;

public class T_ToggleControl : MonoBehaviour
{
    public GameObject triggerSource;

    public bool isOpen;
    public GameObject objectToControl;

    // Possible trigger components
    private T_HourglassTimer hourglass;
    private O_KeyPadActivate keypad;
    private T_PressurePlate pressurePlate;
    private T_PressurePlateManager pressurePlateManager;
    private T_TorchManager torchManager;

    private void Start()
    {
        if (objectToControl == null)
        {
            // Assume the door is the first child
            objectToControl = transform.GetChild(0).gameObject;
        }


        // Set initial door state based on tag
        if (CompareTag("R1_Door") || objectToControl.name == "TP_Trigger 3-4")
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
            pressurePlateManager = triggerSource.GetComponent<T_PressurePlateManager>();
            torchManager = triggerSource.GetComponent<T_TorchManager>();
        }
    }

    private void Update()
    {
        if (hourglass != null && hourglass.startTimer == true)
        {
            //SetObjectState(false); // Close door when hourglass/timer is active
            isOpen = false;
        }

        if (keypad != null && keypad.keyPadComplete == true)
        {
            //SetObjectState(true); // Open door when keypad is complete
            isOpen = true;
        }

        if (pressurePlateManager != null && pressurePlateManager.AllConditionsMet == true)
        {
            isOpen = true;
        }

        if (torchManager != null && torchManager.AllConditionsMet == true)
        {
            isOpen = false;
        }

        if (pressurePlate != null)
        {
            //tObjectState(pressurePlate.isPressed); // Open/close based on plate
            isOpen = pressurePlate.isPressed;
        }

        SetObjectState();
    }

    private void SetObjectState()
    {
        objectToControl.SetActive(!isOpen);
    }


    private void ActivateObjectAnim()
    {
        //Dont have animation...
        
    }
}
