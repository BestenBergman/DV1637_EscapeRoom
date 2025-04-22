using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class O_KeyPadActivate : MonoBehaviour
{
    [HideInInspector] public H_PlayerStats ps;

    public Canvas UI;
    public Canvas keyPad;

    public GameObject pusselTwo;
    public GameObject tpStart;
    public GameObject tpEnd;
    public GameObject correct;
    public GameObject wrong;

    public bool keyPadComplete = false;
    public bool teleporterActive = false;
    public bool keyPadOn = false;
    
    public string code1 = "";
    public string code2 = "";
    public string code3 = "";

    public string p1;
    public string p2;
    public string p3;

    public TextMeshProUGUI input1;
    public TextMeshProUGUI input2;
    public TextMeshProUGUI input3;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<H_PlayerStats>();
        UI.enabled = true;
        ps.inKeyPad = false;
        keyPad.enabled = false;
        correct.SetActive(false);
        wrong.SetActive(false);
        tpStart.SetActive(false);
        tpEnd.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CodeCheck();
        if (keyPadComplete && !teleporterActive)
        {
            StartCoroutine("Closing");
        }
         
    }

    public void KeyPadSwitch()
    {
        if (keyPad.isActiveAndEnabled)
        {
            keyPad.enabled = false;
            keyPadOn = false;
            Cursor.lockState = CursorLockMode.Locked;
            UI.enabled = true;
            ps.inKeyPad = false;
        }
        else
        {
            UI.enabled = false;
            ps.inKeyPad = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            keyPad.enabled = true;
            keyPadOn = true;
        }
    }

    public void KeyPadComplete()
    {
        if (keyPad.isActiveAndEnabled)
        {
            keyPad.enabled = false;
            keyPadOn = false;
        }
        if (!UI.isActiveAndEnabled)
        {
            Cursor.lockState = CursorLockMode.Locked;
            UI.enabled = true;
            ps.inKeyPad = false;
        }
    }
    IEnumerator Closing()
    {
        teleporterActive = true;
        yield return new WaitForSeconds(0.5f);
        correct.SetActive(true);
        input1.text = "";
        input2.text = "";
        input3.text = "";
        yield return new WaitForSeconds(1.0f);
        KeyPadComplete();
        correct.SetActive(false);

    }

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

    IEnumerator WrongCode()
    {
        yield return new WaitForSeconds(0.5f);
        wrong.SetActive(true);
        input1.text = "";
        input2.text = "";
        input3.text = "";
        yield return new WaitForSeconds(1.0f);
        wrong.SetActive(false);

    }
}
