using UnityEngine;

public class O_R2P1 : MonoBehaviour
{
    public bool on = false;
    

    public void SwitchLever()
    {

        if (!on)
        {
            transform.parent.eulerAngles = new Vector3(0, 0, -22.5f);
            on = true;
        }
        else
        {
            transform.parent.eulerAngles = new Vector3(0, 0, 22.5f);
            on = false;
        }
    }
}

    
