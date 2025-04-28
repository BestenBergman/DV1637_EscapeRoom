using UnityEngine;

public class T_GateControl : MonoBehaviour
{
    public GameObject UI;
    public O_KeyPadActivate keypad;
    private bool open;

    private void Start()
    {
        if (gameObject.transform.tag == "Door_1")
        {
            open = true;
        }
        else
        {
            open = false;
        }
    }

    private void Update()
    {
        if (keypad.keyPadComplete && !open)
        {
            open = true;
            gameObject.SetActive(false);
        }

        if (UI.transform.gameObject.GetComponent<T_HourglassTimer>().startTimer == true)
        {
            open = false;
            gameObject.SetActive(true);
        }
    }



}
