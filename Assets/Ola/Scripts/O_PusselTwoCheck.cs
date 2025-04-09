using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class O_PusselTwoCheck : MonoBehaviour
{
    public TextMeshProUGUI input1;
    public TextMeshProUGUI input2;
    public TextMeshProUGUI input3;
    public GameObject pusselTwo;
    public bool pusselTwoComplete = false;
    public bool checkStarted = false;
    public string code1 = "";
    public string code2 = "";
    public string code3 = "";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkStarted = pusselTwo.GetComponent<O_PusselTwoStart>().started;
        if (checkStarted && !pusselTwoComplete)
        {
            CodeCheck();
        }
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
                if(code3 == "1")
                {
                    pusselTwoComplete = true;
                    Debug.Log("Yahoooo");
                }
            }
        }
    }
}
