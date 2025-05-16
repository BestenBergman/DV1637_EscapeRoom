using System.Collections;
using UnityEngine;

public class O_StartAnim : MonoBehaviour

{
    [HideInInspector] public Animator anim;

    public AudioClip openSound;

   
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    /// <summary>
    /// Starting animation for the "Starter-Chest"
    /// </summary>
    public void Started()
    {
        H_SoundFXManager.instance.PlaySoundFXClip(openSound, transform, 1f);
        anim.SetBool("Open", true);
    }
}
