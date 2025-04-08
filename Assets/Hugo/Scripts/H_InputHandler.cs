using UnityEngine;

public class H_InputHandler : MonoBehaviour
{
    [HideInInspector] public O_CameraBasedMovement O_cbm;
    [HideInInspector] public H_Interact H_Int;
    void Start()
    {
        O_cbm = GetComponent<O_CameraBasedMovement>();
        H_Int = GetComponent<H_Interact>();
    }

    // Update is called once per frame
    void Update()
    {
        InputHandler();
    }

    private void InputHandler()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            O_cbm.PlayerMovement();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            H_Int.Interact();
        }
    }
}
