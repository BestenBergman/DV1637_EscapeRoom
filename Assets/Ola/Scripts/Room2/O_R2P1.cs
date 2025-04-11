using UnityEngine;

public class O_R2P1 : MonoBehaviour
{
    public bool on = false;
    public int tmpAngle = 0;

    public void SwitchLever(GameObject lever)
    {

        if (!on)
        {
            lever.transform.parent.eulerAngles = new Vector3(0, 0, -22.5f);
            on = true;
        }
        else
        {
            lever.transform.parent.eulerAngles = new Vector3(0, 0, 22.5f);
            on = false;
        }
    }
}

    
