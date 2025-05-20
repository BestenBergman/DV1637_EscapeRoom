using UnityEngine;

public class O_R2P1 : MonoBehaviour
{
    [HideInInspector] public bool on = false;
    
    [Tooltip("The light which is paired with the lever")]
    public GameObject tl;

    [Tooltip("Ljudet som ska spelas när skapen dras i")]
    [SerializeField] private AudioClip leverSound;

    /// <summary>
    /// Switch the lever on/off and turn the
    /// corresponding light on/off 
    /// </summary>
    public void SwitchLever()
    {

        if (!on)
        {
            transform.parent.eulerAngles = new Vector3(0, 0, -16);
            on = true;
            H_SoundFXManager.instance.PlaySoundFXClip(leverSound, transform, 1f);
            tl.GetComponent<O_TorchLever>().SwitchLights();
        }
        else
        {
            transform.parent.eulerAngles = new Vector3(0, 0, 16);
            on = false;
            H_SoundFXManager.instance.PlaySoundFXClip(leverSound, transform, 1f);
            tl.GetComponent<O_TorchLever>().SwitchLights();
        }
    }
}

    
