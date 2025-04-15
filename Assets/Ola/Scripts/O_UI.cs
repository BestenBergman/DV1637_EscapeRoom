using TMPro;
using UnityEngine;

public class O_UI : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameObject startChest;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = startChest.GetComponent<O_Startscript>().timer.ToString("0.00");
    }
}
