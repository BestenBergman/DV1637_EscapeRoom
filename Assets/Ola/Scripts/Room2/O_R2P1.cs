using UnityEngine;

public class O_R2P1 : MonoBehaviour
{
    public bool on = false;
    public GameObject tl; 
    
    /// <summary>
    /// Switch the lever on/off and turn the
    /// corresponding light on/off 
    /// </summary>
    public void SwitchLever()
    {

        if (!on)
        {
            transform.parent.eulerAngles = new Vector3(0, 0, -16);
            on = true;
            tl.GetComponent<O_TorchLever>().SwitchLights();
        }
        else
        {
            transform.parent.eulerAngles = new Vector3(0, 0, 16);
            on = false;
            tl.GetComponent<O_TorchLever>().SwitchLights();
        }
    }
}

    
