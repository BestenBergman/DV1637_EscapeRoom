using System.Collections.Generic;
using UnityEngine;

public class KontrolerKontrol : MonoBehaviour
{
    [HideInInspector] public List<GameObject> kontrolers;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            kontrolers.Add(transform.GetChild(i).gameObject);
        }
    }

    /// <summary>
    /// Kollar ifall alla knappsekvenser har r�tt v�rde
    /// </summary>
    /// <returns>true eller false</returns>
    public bool CheckersAreRight()
    {
        Debug.Log(kontrolers);
        for (int i = 0; i < kontrolers.Count; i++)
        {
            if (!kontrolers[i].GetComponent<ButtonKontroler>().RightCombination())
            {
                return false;
            }
        }
        return true;
    }
}
