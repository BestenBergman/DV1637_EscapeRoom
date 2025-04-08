using UnityEngine;

public class ButtonSwitchState : MonoBehaviour
{
    public bool isRight;
    public bool isPressed;

    public void SwitchState()
    {
        isPressed = !isPressed;
    }
}
