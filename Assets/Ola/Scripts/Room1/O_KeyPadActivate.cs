using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class O_KeyPadActivate : MonoBehaviour
{
    [HideInInspector] public H_PlayerStats ps;

    [HideInInspector] public bool keyPadComplete = false;
    [HideInInspector] public bool teleporterActive = false;
    [HideInInspector] public bool keyPadOn = false;

    [HideInInspector] public string code1 = "";
    [HideInInspector] public string code2 = "";
    [HideInInspector] public string code3 = "";

    [Tooltip("The keypad-canvas for this keypad")]
    public Canvas keyPad;

    [Tooltip("The teleporter that will be activated")] 
    public GameObject tpStart;
    
    [Tooltip("The teleporter to which you are teleported")]
    public GameObject tpEnd;
    
    [Tooltip("The gameobject that is named 'Correct' in the keypad UI")]
    public GameObject correct;
    
    [Tooltip("The gameobject that is named 'Wrong' in the keypad UI")]
    public GameObject wrong;

    [Tooltip("First digit in the password")]
    public string p1;

    [Tooltip("Second digit in the password")] 
    public string p2;

    [Tooltip("Third digit in the password")] 
    public string p3;

    [Tooltip("TextMeshPro named 'Input 1' in keypad UI")]
    public TextMeshProUGUI input1;

    [Tooltip("TextMeshPro named 'Input 2' in keypad UI")]
    public TextMeshProUGUI input2;

    [Tooltip("TextMeshPro named 'Input 3' in keypad UI")]
    public TextMeshProUGUI input3;


    void Start()
    {
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<H_PlayerStats>();
        ps.inKeyPad = false;
        keyPad.enabled = false;
        correct.SetActive(false);
        wrong.SetActive(false);
        tpStart.SetActive(false);
        tpEnd.SetActive(false);
    }

    void Update()
    {
        CodeCheck();
        if (keyPadComplete && !teleporterActive)
        {
            StartCoroutine("Closing");
        }
         
    }

    /// <summary>
    /// Switching UI between game and Keypad
    /// </summary>
    public void KeyPadSwitch()
    {
        if (keyPad.isActiveAndEnabled)
        {
            keyPad.enabled = false;
            keyPadOn = false;
            Cursor.lockState = CursorLockMode.Locked;
            ps.inKeyPad = false;
        }
        else
        {
            ps.inKeyPad = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            keyPad.enabled = true;
            keyPadOn = true;
        }
    }

    /// <summary>
    /// Automatic closing of the keypad when completing it
    /// </summary>
    public void KeyPadComplete()
    {
        if (keyPad.isActiveAndEnabled)
        {
            keyPad.enabled = false;
            keyPadOn = false;
            Cursor.lockState = CursorLockMode.Locked;
            ps.inKeyPad = false;
        }
    }
 
    /// <summary>
    /// When three digits have been entered, it checks if they are correct.
    /// </summary>
    public void CodeCheck()
    {
        code1 = input1.text;
        code2 = input2.text;
        code3 = input3.text;

        if (code1 == p1)
        {
            if (code2 == p2)
            {
                if (code3 == p3)
                {
                    keyPadComplete = true;
                    // Spela teleport ljud
                    tpStart.SetActive(true);
                    tpEnd.SetActive(true);
                }
            }
        }
        if (code1 != "" && code2 != "" && code3 != "" && !keyPadComplete)
        {
            StartCoroutine("WrongCode");
        }
    }


    /// <summary>
    /// Resets the digits and shows a green box when entering the correct code.
    /// Also activates the teleporter/corresponding door.
    /// </summary>
    /// <returns></returns>
    IEnumerator Closing()
    {
        teleporterActive = true;
        yield return new WaitForSeconds(0.5f);
        correct.SetActive(true);
        input1.text = "";
        input2.text = "";
        input3.text = "";
        yield return new WaitForSeconds(0.5f);
        KeyPadComplete();
        correct.SetActive(false);
    }


    /// <summary>
    /// Resets the digits and shows a red box when entering the wrong code.
    /// </summary>
    /// <returns></returns>
    IEnumerator WrongCode()
    {
        yield return new WaitForSeconds(0.5f);
        wrong.SetActive(true);
        input1.text = "";
        input2.text = "";
        input3.text = "";
        yield return new WaitForSeconds(0.5f);
        wrong.SetActive(false);

    }
}
