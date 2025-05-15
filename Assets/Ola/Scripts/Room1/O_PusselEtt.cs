using UnityEngine;

public class O_PusselEtt : MonoBehaviour
{
    public bool placedCorrectly = false;
    
    /// <summary>
    /// Check to see if the stone placed on the plate is the right one
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == gameObject.tag + "plate")
        {
            placedCorrectly = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == gameObject.tag + "plate")
        {
            placedCorrectly = false;
        }
    }
}
