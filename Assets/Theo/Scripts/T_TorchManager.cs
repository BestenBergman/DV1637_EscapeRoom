using UnityEngine;

/// <summary>
/// This script manages a group of torches and checks if all of them have been lit.
/// </summary>
public class T_TorchManager : T_ManagerBase<T_TorchController>
{
    protected override bool IsConditionMet(T_TorchController torch)
    {
        return torch.torchIsEnabled;
    }

    //protected override void PrintOutResult(bool allLit)
    //{
    //    if (allLit)
    //    {
    //        Debug.Log("Lit");
    //    }
    //    else
    //    {
    //        Debug.Log("Not Lit");
    //    }
    //}
}
