using System;
using UnityEngine;

public class O_PusselTwoStart : MonoBehaviour
{
    [HideInInspector] public bool started = false;
    [HideInInspector] public bool pusselOneCheck = false;
    [HideInInspector] public bool switched = false;
    
    [Tooltip("The gameobject that holds the first puzzle")]
    public GameObject pusselOne;

    void Update()
    {
        Starter();
        if (started && !switched)
        {
            LightSwitch();
        }
    }

    /// <summary>
    /// Checks if the first puzzle is done and if so
    /// starts the second puzzle with the lights.
    /// </summary>
    public void Starter()
    {
        if (!started)
        {
            pusselOneCheck = pusselOne.GetComponent<O_PusselEttCheck>().pusselEttComplete;
            if (pusselOneCheck)
            {
                started = true;
            }
        }
    }
    /// <summary>
    /// Turns of the lights to reveal the binary code.
    /// </summary>
    public void LightSwitch()
    {
        Array lights = GameObject.FindGameObjectsWithTag("R1_Switchable");
        foreach (GameObject light in lights)
        {
            light.SetActive(false);
        }
        switched = true;
    }


}
