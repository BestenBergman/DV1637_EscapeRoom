using System.Threading;
using UnityEngine;

public class O_InputHandler : MonoBehaviour
{
    public O_CameraBasedMovement O_cbm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        O_cbm = GetComponent<O_CameraBasedMovement>();
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
    }
}
