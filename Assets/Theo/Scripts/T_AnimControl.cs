using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

/// <summary>
/// Controls an Animator parameter based on toggle state.
/// Inherits toggle logic from T_ToggleControl, using base Start and Update methods.
/// </summary>
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

    /// <summary>
    /// Sets the "isToggled" parameter in the Animator based on current toggle state.
    /// </summary>
    protected override void SetObjectState()
    {
        if (anim != null)
        {
            anim.SetBool("isToggled", isToggled);
        }
    }
}