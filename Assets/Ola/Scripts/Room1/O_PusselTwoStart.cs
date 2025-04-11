using System;
using UnityEngine;

public class O_PusselTwoStart : MonoBehaviour
{
    public bool started = false;
    public bool pusselOneCheck = false;
    public bool switched = false;
    public GameObject pusselOne;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Starter();

        if (started && !switched)
        {
            LightSwitch();
        }
    }

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
