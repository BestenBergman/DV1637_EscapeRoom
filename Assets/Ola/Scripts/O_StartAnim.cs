using System.Collections;
using UnityEngine;

public class O_StartAnim : MonoBehaviour

{
    public Animator anim;

   
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    /// <summary>
    /// Starting animation for the "Starter-Chest"
    /// </summary>
    public void Started()
    {
        anim.SetBool("Open", true);
    }
}
