using UnityEngine;

public class O_KeyPadActivate : MonoBehaviour
{
    public Canvas UI;
    public Canvas keyPad;
    public float maxDist = 10.0f;
    public GameObject pusselTwo;
    public bool keyPadComplete = false;
    public bool keyPadOn = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UI.enabled = true;
        keyPad.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        keyPadComplete = pusselTwo.GetComponent<O_PusselTwoCheck>().pusselTwoComplete;
        if (keyPadComplete)
        {
            KeyPadComplete();
        }
        KeyPadActivate();   
    }

    public void KeyPadActivate()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
            RaycastHit hit;

            if (keyPad.isActiveAndEnabled)
            {
                keyPad.enabled = false;
                keyPadOn = false;
                Cursor.lockState = CursorLockMode.Locked;
                UI.enabled = true;
            }
            else if (Physics.Raycast(ray, out hit, maxDist))
            {
                if (hit.collider.CompareTag("R1_Keypad"))
                {
                    UI.enabled = false;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    keyPad.enabled = true;
                    keyPadOn = true;
                }
            }
        }
    }

    public void KeyPadComplete()
    {
        if (keyPad.isActiveAndEnabled)
        {
            keyPad.enabled = false;
        }
            if (!UI.isActiveAndEnabled)
            {
            Cursor.lockState = CursorLockMode.Locked;
            UI.enabled = true;
            }
    }
}
