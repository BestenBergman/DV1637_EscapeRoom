using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class T_AnimControl : T_ToggleControl
{
    protected Animator anim;

    [SerializeField] private AudioClip audioClip;
    private bool playedSound = false;

    protected override void Start()
    {
        anim = GetComponent<Animator>();

        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void SetObjectState()
    {
        if (audioClip != null && isToggled && !playedSound)
        {
            playedSound = true;
            H_SoundFXManager.instance.PlaySoundFXClip(audioClip, transform.GetChild(0), 1f);
        }
        if (anim != null)
        {
            anim.SetBool("isToggled", isToggled);
        }
    }
}