using UnityEngine;

public class O_TorchLever : MonoBehaviour
{
    [Tooltip("The gameObject which contains the particle system and point light of the torch")]
    public GameObject flames;
    
    [Tooltip("The lever which is paired with the torch")]
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
