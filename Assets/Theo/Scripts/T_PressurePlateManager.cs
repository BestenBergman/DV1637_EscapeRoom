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
