using UnityEngine;

public class ButtonSwitchState : MonoBehaviour
{
    [Tooltip("S�ger om denna knapp ska vara den r�tta f�r att l�sa pusslet.\n" +
        "Minst och max en per KnappSekvens")]
    public bool IsRight;

    [Tooltip("S�ger om denna knapp �r nedtryckt eller inte")]
    public bool isPressed;

    /// <summary>
    /// Aktiverar eller avaktiverar en knapp
    /// </summary>
    public void SwitchState()
    {
        isPressed = !isPressed;
    }
}
