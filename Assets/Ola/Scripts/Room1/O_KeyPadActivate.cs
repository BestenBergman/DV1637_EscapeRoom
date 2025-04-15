using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class O_KeyPadActivate : MonoBehaviour
{
    public Canvas UI;
    public Canvas keyPad;

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

    [SerializeField] private string pw1;
    [SerializeField] private string pw2;
    [SerializeField] private string pw3;

    public TextMeshProUGUI input1;
    public TextMeshProUGUI input2;
    public TextMeshProUGUI input3;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UI.enabled = true;
        keyPad.enabled = false;
        correct.SetActive(false);
        wrong.SetActive(false);
        tpStart.SetActive(false);
        tpEnd.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!keyPadComplete)
        {
            code1 = input1.text;
            code2 = input2.text;
            code3 = input3.text;
        }
        if (code1 != "" && code2 != "" && code3 != "")
        {
            CodeCheck();
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
        }
        else
        {
            UI.enabled = false;
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
        }
    }
    IEnumerator Closing()
    {
        teleporterActive = true;
        yield return new WaitForSeconds(0.5f);
        input1.text = "";
        input2.text = "";
        input3.text = "";
        correct.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        KeyPadComplete();
        correct.SetActive(false);

    }

    public void CodeCheck()
    {

        if (code1 == pw1 && code2 == pw2 && code3 == pw3)
        {
            keyPadComplete = true;
            tpStart.SetActive(true);
            tpEnd.SetActive(true);
            StartCoroutine(Closing());
        }
        else
        {
            Debug.LogWarning("Garga");
            //StartCoroutine("WrongCode");
        }
        code1 = "";
        code2 = "";
        code3 = "";
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
