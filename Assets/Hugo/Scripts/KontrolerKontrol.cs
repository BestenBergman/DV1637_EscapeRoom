using System.Collections.Generic;
using UnityEngine;

public class KontrolerKontrol : MonoBehaviour
{
    [HideInInspector] public List<GameObject> kontrolers;

    [Tooltip("Vill ha in de trappor som ska aktiveras när pusslet löses")]
    public GameObject stairs;

    private void Start()
    {
        stairs.SetActive(false);
        for (int i = 0; i < transform.childCount; i++)
        {
            kontrolers.Add(transform.GetChild(i).gameObject);
        }
    }

    /// <summary>
    /// Kollar ifall alla knappsekvenser har rätt värde
    /// </summary>
    /// <returns>true eller false</returns>
    public bool CheckersAreRight()
    {
        for (int i = 0; i < kontrolers.Count; i++)
        {
            if (!kontrolers[i].GetComponent<ButtonKontroler>().RightCombination())
            {
                return false;
            }
        }
        return true;
    }
    /// <summary>
    /// Aktiverar slut trappan i rum 4
    /// </summary>
    public void ActivateStairs()
    {
        stairs.SetActive(true);
    }
}
