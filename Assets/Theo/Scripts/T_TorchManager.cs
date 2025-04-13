using UnityEngine;

public class T_TorchManager : MonoBehaviour
{
    bool hasAllBeenLit = false;

    private void Update()
    {
        if (!hasAllBeenLit && allTorchesLit())
        {
            hasAllBeenLit = true;
        }

        if (hasAllBeenLit)
        {
            Debug.Log("Lit!");
        }
        else
        {
            Debug.Log("Not Lit...");
        }
    }


    bool allTorchesLit()
    {
        bool allPressed = true;
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            T_TorchController torch = child.GetComponent<T_TorchController>();

            if (torch != null)
            {
                if (!torch.torchIsEnabled)
                {
                    allPressed = false;
                    break; // no need to check further if one is not pressed
                }
            }
        }
        return allPressed;
    }
}
