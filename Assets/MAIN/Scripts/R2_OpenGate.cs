using UnityEngine;

public class R2_OpenGate : MonoBehaviour
{
    [HideInInspector] public O_KeyPadActivate r2_keypad;
    private bool opened;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        r2_keypad = GameObject.FindGameObjectWithTag("R2_Keypad").GetComponent<O_KeyPadActivate>();
    }

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
