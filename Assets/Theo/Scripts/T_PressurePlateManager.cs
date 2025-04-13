using UnityEngine;

public class T_PressurePlateManager : MonoBehaviour
{
    bool hasAllBeenPressed = false;

    private void Start()
    {
        foreach (Transform child in transform)
        {
            Debug.Log(child.name);
        }
    }

    void Update()
    {
        if (!hasAllBeenPressed && AllIsPressed())
        {
            hasAllBeenPressed = true;
        }

        if (hasAllBeenPressed)
        {
            //Debug.Log("Pressed!");
        }
        else
        {
            //Debug.Log("Not Pressed...");
        }


        //if (checkIfAllIsPressed())
        //{
        //    Debug.Log("Pressed!");
        //}
        //else 
        //{
        //    Debug.Log("Not Pressed...");
        //}

    }

    bool AllIsPressed()
    {
        bool allPressed = true;
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            T_PressurePlate pressurePlate = child.GetComponent<T_PressurePlate>();

            if (pressurePlate != null)
            {
                if (!pressurePlate.isPressed)
                {
                    allPressed = false;
                    break; // no need to check further if one is not pressed
                }
            }
        }
        return allPressed;
    }

}
