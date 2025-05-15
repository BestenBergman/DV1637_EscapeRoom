using UnityEngine;

public class O_TorchLever : MonoBehaviour
{
    public GameObject flames;
    public GameObject lever;
    
    [HideInInspector] public bool checkOne;
    
    void Start()
    {
        flames.SetActive(false);
        checkOne = lever.GetComponent<O_R2P1>().on;
    }
    
    /// <summary>
    /// Turning lights on/off when switching levers
    /// </summary>
    public void SwitchLights()
    {
        checkOne = lever.GetComponent<O_R2P1>().on;
        if (!checkOne)
        {
            flames.SetActive(false);
        }
        else if (checkOne)
        {
            flames.SetActive(true);
        }
    }

}
