using UnityEngine;

/// <summary>
/// This script manages a group of pressure plates and checks if all of them have been pressed.
/// </summary>
public class T_PressurePlateManager : T_ManagerBase<T_PressurePlate>
{
    protected override bool IsConditionMet(T_PressurePlate pressurePlate)
    {
        return pressurePlate.isPressed;
    }

    //protected override void PrintOutResult(bool allPressed)
    //{
    //    if (allPressed)
    //    {
    //        Debug.Log("Pressed!");
    //    }
    //    else
    //    {
    //        Debug.Log("Not Pressed...");
    //    }
    //}
}



//public class T_PressurePlateManager : MonoBehaviour
//{
//    // This becomes true once all pressure plates have been pressed once.
//    public bool allBeenPressed = false;

//    void Update()
//    {
//        // If all pressure plates are pressed or have been pressed at once
//        if (!allBeenPressed && AllIsPressed())
//        {
//            allBeenPressed = true;
//        }

//        //if (allPressed)
//        //{
//        //    Debug.Log("Pressed!");
//        //}
//        //else
//        //{
//        //    Debug.Log("Not Pressed...");
//        //}
//    }

//    /// <summary>
//    /// Checks each child object to see if it's a pressure plate and whether it has been pressed.
//    /// </summary>
//    /// <returns>True if all plates are pressed</returns>
//    bool AllIsPressed()
//    {
//        // Loop through all child objects of this GameObject.
//        for (int i = 0; i < transform.childCount; i++)
//        {
//            Transform child = transform.GetChild(i);
//            T_PressurePlate pressurePlate = child.GetComponent<T_PressurePlate>();

//            if (pressurePlate != null)
//            {
//                // if one is not pressed, return false immediately.
//                if (!pressurePlate.isPressed)
//                {
//                    return false;
//                }
//            }
//        }
//        // If the loop completes without returning false, all plates are pressed.
//        return true;
//    }

//}
