using UnityEngine;

public class T_PressurePlate : MonoBehaviour
{
    public bool isPressed = false;

    private void OnTriggerEnter(Collider other)
    {
        isPressed = true;

        //if (other.tag == "Item")
        //{
        //    Debug.Log("Box");
        //}
        //if (other.tag == "Player")
        //{
        //    Debug.Log("Player");
        //}
    }
    private void OnTriggerExit(Collider other)
    {
        isPressed = false;
    }

}
