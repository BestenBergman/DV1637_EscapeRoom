using UnityEngine;

[RequireComponent(typeof(O_CameraBasedMovement))]
[RequireComponent(typeof(H_Interact))]

public class H_InputHandler : MonoBehaviour
{
    [HideInInspector] public O_CameraBasedMovement O_cbm;
    [HideInInspector] public H_Interact H_Int;
    [HideInInspector] public Canvas UI;
    void Start()
    {
        O_cbm = GetComponent<O_CameraBasedMovement>();
        H_Int = GetComponent<H_Interact>();
        UI = GameObject.FindGameObjectWithTag("GameUI").GetComponent<Canvas>();
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
        if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && UI.enabled)
        {
            O_cbm.PlayerMovement();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            H_Int.Interact();
        }
    }
}
