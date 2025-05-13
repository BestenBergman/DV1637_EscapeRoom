using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class T_AnimControl : T_ToggleControl
{
    protected Animator anim;

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
        if (anim != null)
        {
            anim.SetBool("isToggled", isToggled);
        }
    }
}