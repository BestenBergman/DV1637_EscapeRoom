using TMPro;
using UnityEngine;

public class O_KeyPad : MonoBehaviour

    {
    public TextMeshProUGUI input1;
    public TextMeshProUGUI input2;
    public TextMeshProUGUI input3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KeyPadPress()
    {
        if (input1.text == "")
        {
            input1.text = gameObject.name;
        }
        else if (input2.text == "")
        {
            input2.text = gameObject.name;
        }
        else if (input3.text == "")
        {
            input3.text = gameObject.name;
        }
    }

}
