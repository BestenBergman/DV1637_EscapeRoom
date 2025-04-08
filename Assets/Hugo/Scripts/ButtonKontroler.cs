using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonKontroler : MonoBehaviour
{
    [HideInInspector]public List<GameObject> buttons;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            buttons.Add(transform.GetChild(i).gameObject);
        }
    }
    public void UpdateButtons(GameObject pressed)
    {
        for(int i = 0;i < buttons.Count; i++)
        {
            if (buttons[i].GetComponent<ButtonSwitchState>().isPressed)
            {
                buttons[i].GetComponent<ButtonSwitchState>().SwitchState();
            }
        }
        pressed.GetComponent<ButtonSwitchState>().SwitchState();
    }

    public bool RightCombination()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (buttons[i].GetComponent<ButtonSwitchState>().isPressed != buttons[i].GetComponent<ButtonSwitchState>().isRight)
            {
                return false;
            }
        }
        return true;
    }
}
