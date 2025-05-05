using System.Collections;
using UnityEngine;

public class O_StartAnim : MonoBehaviour

{

    public Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Started()
    {
        anim.SetBool("Open", true);
    }
}
