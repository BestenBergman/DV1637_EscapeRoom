using System.Collections;
using UnityEngine;

public class O_TP_Mat_Swap : MonoBehaviour
{
    [Tooltip("The materials which the teleporter will use in the swap")]
    public Material[] mList;
    
    private bool started = false;
    private MeshRenderer mR;

    
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

    /// <summary>
    /// Swapping material on the teleporter base 10 times/second to create the illusion of a spinning light.
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
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
