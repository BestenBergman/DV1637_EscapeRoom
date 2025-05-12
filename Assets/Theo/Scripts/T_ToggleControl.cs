using UnityEngine;

public class T_ToggleControl : MonoBehaviour
{
    public GameObject triggerSource;

    public bool isToggled;
    public GameObject objectToControl;


    protected T_HourglassTimer hourglass;
    protected O_KeyPadActivate keypad;
    protected T_PressurePlate pressurePlate;
    protected T_PressurePlateManager pressurePlateManager;
    protected T_TorchManager torchManager;

    
    protected virtual void Start()
    {
        if (CompareTag("R1_Door") || CompareTag("TP_3-4"))
        {
            isToggled = true;
        }
        else
        {
            isToggled = false;
        }

        SetObjectState();

        if (triggerSource != null)
        {
            hourglass = triggerSource.GetComponent<T_HourglassTimer>();
            keypad = triggerSource.GetComponent<O_KeyPadActivate>();
            pressurePlate = triggerSource.GetComponent<T_PressurePlate>();
            pressurePlateManager = triggerSource.GetComponent<T_PressurePlateManager>();
            torchManager = triggerSource.GetComponent<T_TorchManager>();
        }
    }

    protected virtual void Update()
    {
        if (hourglass != null && hourglass.startTimer)
        {
            isToggled = false; //Door closes
        }

        if (keypad != null && keypad.keyPadComplete)
        {
            isToggled = true; //Door opens
        }

        if (pressurePlate != null)
        {
            isToggled = pressurePlate.isPressed;
        }

        if (pressurePlateManager != null && pressurePlateManager.AllConditionsMet)
        {
            isToggled = true; //Open chest
        }

        if (torchManager != null && torchManager.AllConditionsMet)
        {
            isToggled = false; //Activate Teleport
        }

        SetObjectState();
    }

    protected virtual void SetObjectState()
    {
        if (objectToControl == null)
        {
            if (transform.childCount > 0)
            {
                objectToControl = transform.GetChild(0).gameObject;
            }
            else
            {
                return;
            }
        }
        objectToControl.SetActive(!isToggled);
    }

}