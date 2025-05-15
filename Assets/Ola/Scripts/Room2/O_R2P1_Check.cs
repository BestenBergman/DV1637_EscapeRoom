using UnityEngine;

public class O_R2P1_Check : MonoBehaviour
{
    public GameObject lever1;
    public GameObject lever2;
    public GameObject lever3;
    public GameObject lever4;

    [HideInInspector] public bool lever1Check;
    [HideInInspector] public bool lever2Check;
    [HideInInspector] public bool lever3Check;
    [HideInInspector] public bool lever4Check;
    public bool r2p1Completed = false;

    public GameObject gateDoor;


    void Update()
    {
        if(!r2p1Completed)
        {
            CheckLevers();
        }
    }


    /// <summary>
    /// Checking the position of the levers.
    /// </summary>
    public void CheckLevers()
    {
        lever1Check = lever1.GetComponent<O_R2P1>().on;
        lever2Check = lever2.GetComponent<O_R2P1>().on;
        lever3Check = lever3.GetComponent<O_R2P1>().on;
        lever4Check = lever4.GetComponent<O_R2P1>().on;

        if (lever1Check && !lever2Check && !lever3Check && lever4Check)
        {
            r2p1Completed = true;
            gateDoor.SetActive(false);
        }
    }
}
