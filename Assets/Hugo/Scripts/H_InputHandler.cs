using UnityEngine;

[RequireComponent(typeof(O_CameraBasedMovement))]
[RequireComponent(typeof(H_Interact))]
[RequireComponent(typeof(H_Inspect))]
[RequireComponent(typeof(H_PlayerStats))]

public class H_InputHandler : MonoBehaviour
{
    [HideInInspector] public O_CameraBasedMovement O_cbm;
    [HideInInspector] public H_Interact H_Int;
    [HideInInspector] public H_Inspect H_Ispec;
    [HideInInspector] public H_PlayerStats ps;
    [HideInInspector] public O_Hints O_Hints;
    void Start()
    {
        O_cbm = GetComponent<O_CameraBasedMovement>();
        H_Int = GetComponent<H_Interact>();
        H_Ispec = GetComponent<H_Inspect>();
        ps = GetComponent<H_PlayerStats>();
        O_Hints = GetComponent<O_Hints>();
    }

    void Update()
    {
        InputHandler();
    }

    /// <summary>
    /// Har hand om spelarens inputs
    /// </summary>
    private void InputHandler()
    {
        if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && !ps.inKeyPad && !ps.isInspecting && !ps.fWalk)
        {
            O_cbm.PlayerMovement();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            H_Int.Interact();
        }
        if (Input.GetKeyDown(KeyCode.Q) && !ps.inKeyPad && ps.hasItem)
        {
            H_Ispec.SwitchInspect();
        }
        if(Input.GetKeyDown(KeyCode.H) && !ps.fWalk)
        {
            O_Hints.HintChecker();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && !ps.fWalk)
        {
            O_cbm.SprintSwitch();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && !ps.fWalk)
        {
            O_cbm.SprintSwitch();
        }
    }
}
