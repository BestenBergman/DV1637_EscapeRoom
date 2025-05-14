using UnityEngine;

public class ButtonSwitchState : MonoBehaviour
{
    [Tooltip("Säger om denna knapp ska vara den rätta för att lösa pusslet.\n" +
        "Minst och max en per KnappSekvens")]
    public bool IsRight;

    [Tooltip("Säger om denna knapp är nedtryckt eller inte")]
    public bool isPressed;

    private Vector3 startPos;
    private void Start()
    {
        startPos = transform.localPosition;
    }
    /// <summary>
    /// Aktiverar eller avaktiverar en knapp
    /// </summary>
    public void SwitchState()
    {
        transform.localPosition = !isPressed ? startPos + new Vector3(0, 0, 0.1f) : startPos;
        isPressed = !isPressed;
    }
}
