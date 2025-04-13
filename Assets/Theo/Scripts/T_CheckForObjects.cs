using UnityEngine;

public class T_CheckForObjects : MonoBehaviour
{
    private float stepOffset;

    public CharacterController cc;

    void Start()
    {
        stepOffset = cc.stepOffset;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null)
        {
            cc.stepOffset = 0;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null)
        {
            cc.stepOffset = stepOffset;
        }
    }
}
