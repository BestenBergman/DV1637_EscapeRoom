using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class O_PusselTwoCheck : MonoBehaviour
{
    public TextMeshProUGUI input1;
    public TextMeshProUGUI input2;
    public TextMeshProUGUI input3;
    public GameObject pusselTwo;
    public GameObject tpStart;
    public GameObject tpEnd;
    public bool pusselTwoComplete = false;
    public bool checkStarted = false;
    public string code1 = "";
    public string code2 = "";
    public string code3 = "";
    public GameObject wrong;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wrong.SetActive(false);
        tpStart.SetActive(false);
        tpEnd.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CodeCheck();
    }

    public void CodeCheck()
    {
        code1 = input1.text;
        code2 = input2.text;
        code3 = input3.text;

        if (code1 == "1")
        {
            if (code2 == "1")
            {
                if (code3 == "1")
                {
                    pusselTwoComplete = true;
                    tpStart.SetActive(true);
                    tpEnd.SetActive(true);
                }
            }
        }
        if (code1 != "" && code2 != "" && code3 != "" && !pusselTwoComplete)
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
