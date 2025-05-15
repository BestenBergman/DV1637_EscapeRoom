using System.Collections;
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

    [Tooltip("TextMeshPro that is connected to hints")]
    public TextMeshProUGUI hint;

    [HideInInspector] public bool first;
    [HideInInspector] public bool second;
    [HideInInspector] public bool third;
    [HideInInspector] public bool fourth;
    [HideInInspector] public bool fifth;
    [HideInInspector] public bool sixth;
    [HideInInspector] public bool seventh;
    [HideInInspector] public bool eighth;

    [HideInInspector] public H_PlayerStats ps;
    private bool started = false;
   

    void Start()
    {
        ps = GetComponent<H_PlayerStats>();
    }

    void Update()
    {
        if (ps.hasOpenedChest && !started)
        {
            hint.text = "Press (H) for hints";
            started = true;
        }
    }

    /// <summary>
    /// Hintsystem that checks how far along the player is and gives a hint to help with the next puzzle.
    /// </summary>
    public void HintChecker()
    {
        first = puzzle1room1.GetComponent<O_PusselEttCheck>().pusselEttComplete;
        second = puzzle2room1.GetComponent<O_KeyPadActivate>().keyPadComplete;
        third = puzzle1room2.GetComponent<O_R2P1_Check>().r2p1Completed;
        fourth = puzzle2room2.GetComponent<O_KeyPadActivate>().keyPadComplete;
        fifth = puzzle1room3.GetComponent<T_ToggleControl>().isToggled;
        sixth = puzzle2room3.GetComponent<T_TorchManager>().AllConditionsMet;
        seventh = puzzle1room4.GetComponent<SlutPussel>().puzzleComplete;
        eighth = puzzle2room4.GetComponent<O_KeyPadActivate>().keyPadComplete;
        if (!first && !second)
        {
            hint.text = "There are a lot of rocks, maybe they can tell you something!";
            StartCoroutine("ResetHint");
        }
        else if (!second)
        {
            hint.text = "The lights, the door, the keypad, it's all connected!";
            StartCoroutine("ResetHint");
        }
        else if (!third && !fourth)
        {
            hint.text = "The walls are telling you something, push, then pull, then pull some more and finally push through!";
            StartCoroutine("ResetHint");
        }
        else if (!fourth)
        {
            hint.text = "The creators of this place worshipped the sun, maybe you should try to do the same!";
            StartCoroutine("ResetHint");
        }
        else if (!fifth && !sixth)
        {
            hint.text = "I placed all I had, three gifts of weight, but something was still missing. In the end, I had to take the final step myself!";
            StartCoroutine("ResetHint");
        }
        else if (!sixth)
        {
          hint.text = "So much darkness… perhaps it only yields when touched by a flame!";
          StartCoroutine("ResetHint");
        }
        else if (!seventh && !eighth)
        {
            hint.text = "You might have seen these symbols somewhere else, try going back and take a closer look!";
            StartCoroutine("ResetHint");
        }
        else if (!eighth)
        {
            hint.text = "Follow the stars to get to the stairs!";
            StartCoroutine("ResetHint");
        }
        else if (second && fourth && sixth && eighth)
        {
            hint.text = "You're done, GET OUT OF HERE!";
            StartCoroutine("ResetHint");
        }
        
    }

    /// <summary>
    /// Reseting the text to empty
    /// </summary>
    /// <returns></returns>
    IEnumerator ResetHint()
    {
        yield return new WaitForSeconds(5);
        hint.text = "Press (H) for hints";
    }
}
