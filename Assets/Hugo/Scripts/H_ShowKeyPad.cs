using UnityEngine;

public class H_ShowKeyPad : MonoBehaviour
{
    public bool uiActive;
    public GameObject keypad;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        keypad = GameObject.FindGameObjectWithTag("KeypadUI");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateKeypadUI()
    {

    }
}
