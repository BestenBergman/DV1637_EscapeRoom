using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonKontroler : MonoBehaviour
{
    [HideInInspector]public List<GameObject> buttons;

    [SerializeField] private AudioClip buttonSound;

    private void Start()
    {
        // Tar in alla dess children i en lista
        for (int i = 0; i < transform.childCount; i++)
        {
            buttons.Add(transform.GetChild(i).gameObject);
        }
    }

    /// <summary>
    /// Avaktiverar alla knappar och sedan aktiverar den kanpp
    /// som matas in i funktionen
    /// </summary>
    /// <param name="pressed">GameObjectet till knappen som tryckts ned</param>
    public void UpdateButtons(GameObject pressed)
    {
        for(int i = 0;i < buttons.Count; i++)
        {
            if (buttons[i].GetComponent<ButtonSwitchState>().isPressed)
            {
                buttons[i].GetComponent<ButtonSwitchState>().SwitchState();
            }
        }
        H_SoundFXManager.instance.PlaySoundFXClip(buttonSound, pressed.transform, 1f);
        pressed.GetComponent<ButtonSwitchState>().SwitchState();
    }

    /// <summary>
    /// Kollar om det är rätt knappar som är nedtryckta.
    /// Returnerar true eller false
    /// </summary>
    /// <returns></returns>
    public bool RightCombination()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (buttons[i].GetComponent<ButtonSwitchState>().isPressed != buttons[i].GetComponent<ButtonSwitchState>().IsRight)
            {
                return false;
            }
        }
        return true;
    }
}
