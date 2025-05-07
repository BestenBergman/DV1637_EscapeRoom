using TMPro;
using UnityEngine;

public class O_Hints : MonoBehaviour
{
    public GameObject puzzle1room1;
    public GameObject puzzle2room1;
    public GameObject puzzle1room2;
    public GameObject puzzle2room2;
    public GameObject puzzle1room3;
    public GameObject puzzle2room3;
    public GameObject puzzle1room4;
    public GameObject puzzle2room4;

    public TextMeshProUGUI hint;

    [HideInInspector] public bool first;
    [HideInInspector] public bool second;
    [HideInInspector] public bool third;
    [HideInInspector] public bool fourth;
    [HideInInspector] public bool fifth;
    [HideInInspector] public bool sixth;
    [HideInInspector] public bool seventh;
    [HideInInspector] public bool eighth;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //first = gameObject.GetComponent<O_PusselEttCheck>().pusselEttComplete;
        //second = gameObject.GetComponent<O_KeyPadActivate>().keyPadComplete;
        //third = gameObject.GetComponent<O_R2P1_Check>().r2p1Completed;
        //fourth = gameObject.GetComponent<O_KeyPadActivate>().keyPadComplete;
        //fifth = gameObject.GetComponent<T_ToggleControl>().isOpen;
        //sixth = gameObject.GetComponent<
        //seventh = gameObject.GetComponent<SlutPussel>().puzzleComplete;
        //eighth = gameObject.GetComponent<O_KeyPadActivate>().keyPadComplete;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            HintChecker();
        }
    }

    public void HintChecker()
    {
        first = puzzle1room1.GetComponent<O_PusselEttCheck>().pusselEttComplete;
        second = puzzle2room1.GetComponent<O_KeyPadActivate>().keyPadComplete;
        third = puzzle1room2.GetComponent<O_R2P1_Check>().r2p1Completed;
        fourth = puzzle2room2.GetComponent<O_KeyPadActivate>().keyPadComplete;
        fifth = puzzle1room3.GetComponent<T_ToggleControl>().isOpen;
        //sixth = puzzle2room3.GetComponent<
        seventh = puzzle1room4.GetComponent<SlutPussel>().puzzleComplete;
        eighth = puzzle2room4.GetComponent<O_KeyPadActivate>().keyPadComplete;
        if (!first)
        {
            hint.text = "Stones";
        }
        else if (!second)
        {
            hint.text = "Lights";
        }
        else if (!third)
        {
            hint.text = "Spakar";
        }
        else if (!fourth)
        {
            hint.text = "Papper";
        }
        else if (!fifth)
        {
            hint.text = "Boxes";
        }
        //else if (!sixth)
        //{
        //  hint.text = "Torches";
        //}
        else if (!seventh)
        {
            hint.text = "Shards";
        }
        else if (!eighth)
        {
            hint.text = "Buttons";
        }
        else if (first && second &&  third && fourth && fifth && seventh && eighth)
        {
            hint.text = "RUUUUUN";
        }
        
    }
}
