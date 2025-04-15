using System.Collections;
using UnityEngine;

public class O_TP_Mat_Swap : MonoBehaviour
{
    public Material[] mList;
    private bool started = false;
    private MeshRenderer mR;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mR = GetComponent<MeshRenderer>();
        
    }

    private void Update()
    {
        if (!started)
        {
            started = true;
            StartCoroutine(MaterialSwap(0));
        }
    }


    IEnumerator MaterialSwap(int i = 0)
    {
        if(i > 3)
        {
            i = 0;
        }
        mR.material = mList[i];
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(MaterialSwap(i + 1));
    }
    
}
