using TMPro;
using UnityEngine;

public class O_KeyPad : MonoBehaviour

{
    [Tooltip("TextMeshPro named 'Input 1' in keypad UI")]
    public TextMeshProUGUI input1;

    [Tooltip("TextMeshPro named 'Input 2' in keypad UI")]
    public TextMeshProUGUI input2;

    [Tooltip("TextMeshPro named 'Input 3' in keypad UI")]
    public TextMeshProUGUI input3;

    /// <summary>
    /// Updating the Keypad-UI with the number that was pressed.
    /// </summary>
    public void KeyPadPress()
    {
        if (input1.text == "")
        {
            input1.text = gameObject.name;
        }
        else if (input2.text == "")
        {
            input2.text = gameObject.name;
        }
        else if (input3.text == "")
        {
            input3.text = gameObject.name;
        }
    }

}
