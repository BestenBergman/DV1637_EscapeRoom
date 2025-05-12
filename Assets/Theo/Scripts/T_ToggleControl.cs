using UnityEngine;

public class T_ToggleControl : MonoBehaviour
{
    public GameObject triggerSource;

    private bool isOpen;
    public GameObject objectToControl;

    // Possible trigger components
    private T_HourglassTimer hourglass;
    private O_KeyPadActivate keypad;
    private T_PressurePlate pressurePlate;
    private T_PressurePlateManager pressurePlateManager;
    private T_TorchManager torchManager;

    //Anim
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();

        //if (objectToControl == null)
        //{
        //    // Assume the door is the first child
        //    objectToControl = transform.GetChild(0).gameObject;
        //}


        // Set initial door state based on tag
        if (CompareTag("R1_Door") /*|| objectToControl.name == "TP_Trigger 3-4"*/)
        {
            isOpen = true;
        }
        else
        {
            isOpen = false;
        }

        //objectToControl.SetActive(!isOpen);


        if (triggerSource != null)
        {
            hourglass = triggerSource.GetComponent<T_HourglassTimer>();
            keypad = triggerSource.GetComponent<O_KeyPadActivate>();
            pressurePlate = triggerSource.GetComponent<T_PressurePlate>();
            pressurePlateManager = triggerSource.GetComponent<T_PressurePlateManager>();
            torchManager = triggerSource.GetComponent<T_TorchManager>();
        }

        UpdateAnimator();

    }

    private void Update()
    {
        bool newState = isOpen;

        if (hourglass != null && hourglass.startTimer)
        {
            newState = true;
        }

        if (keypad != null && keypad.keyPadComplete)
        {
            newState = true;
        }

        if (pressurePlateManager != null && pressurePlateManager.AllConditionsMet)
        {
            newState = true;
        }

        if (torchManager != null && torchManager.AllConditionsMet)
        {
            newState = true;
        }

        if (newState != isOpen)
        {
            isOpen = newState;
            UpdateAnimator();
        }
    }

    private void UpdateAnimator()
    {
        anim.SetBool("isOpen", isOpen);
    }


}
