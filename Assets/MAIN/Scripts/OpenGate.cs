using UnityEngine;

public class OpenGate : MonoBehaviour
{
    public O_KeyPadActivate r2_keypad;
    private bool opened;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        if (r2_keypad.keyPadComplete && !opened)
        {
            opened = true;
            gameObject.SetActive(false);
        }
    }
}
