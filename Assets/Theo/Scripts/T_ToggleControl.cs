using UnityEngine;

/// <summary>
/// This class controls toggling of a object based on different trigger sources.
/// </summary>
public class T_ToggleControl : MonoBehaviour
{
    // Trigger source for example timer, keypad, etc.
    public GameObject triggerSource;

    // The toggle bool which detimnines if it's active
    public bool isToggled;

    // The GameObject to be enabled or disabled.
    public GameObject objectToControl;

    // Possible trigger source components
    protected T_HourglassTimer hourglass;
    protected O_KeyPadActivate keypad;
    protected T_PressurePlate pressurePlate;
    protected T_PressurePlateManager pressurePlateManager;
    protected T_TorchManager torchManager;

    // Audio clip to play on toggle
    [SerializeField] protected AudioClip audioClip;
    // Ensure sound only plays once
    protected bool playedSound = false;


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
        // Update isToggled depending on the active trigger

        if (hourglass != null && hourglass.startTimer)
        {
            isToggled = false; // Door closes when hourglass timer starts.
        }

        if (keypad != null && keypad.keyPadComplete)
        {
            isToggled = true; // Door opens when keypad is completed.
        }

        if (pressurePlate != null)
        {
            isToggled = pressurePlate.isPressed; // Active while plate is pressed
        }

        if (pressurePlateManager != null && pressurePlateManager.AllConditionsMet)
        {
            isToggled = true; // Conditions met(all pressure plates) to open chest
        }

        if (torchManager != null && torchManager.AllConditionsMet)
        {
            isToggled = false; //Activate Teleport
        }

        if (CompareTag("R1_Door") || CompareTag("TP_3-4"))
        {
            if (audioClip != null && !isToggled && !playedSound)
            {
                PlaySound();
            }
        }
        else
        {
            if (audioClip != null && isToggled && !playedSound)
            {
                PlaySound();
            }
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

    private void PlaySound()
    {
        playedSound = true;
        H_SoundFXManager.instance.PlaySoundFXClip(audioClip, transform.GetChild(0), 1f);
    }

}