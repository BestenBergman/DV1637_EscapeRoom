using UnityEngine;

/// <summary>
/// This class is a 
/// </summary>
public class T_ToggleControl : MonoBehaviour
{
    // The GameObject that contains trigger source for example timer, keypad, etc.
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

    [SerializeField] protected AudioClip audioClip;
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