using System.Collections.Generic;
using UnityEngine;

public class KontrolerKontrol : MonoBehaviour
{
    [HideInInspector] public List<GameObject> kontrolers;

    [Tooltip("Vill ha in de trappor som ska aktiveras när pusslet löses")]
    public GameObject stairs;

    [Tooltip("Ljudet som ska spelas när trappan dyker upp")]
    [SerializeField] private AudioClip stairSound;
    private bool stairsActive;

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
        if (stairsActive)
        {
            H_SoundFXManager.instance.PlaySoundFXClip(stairSound, stairs.transform, 1f);
        }
        stairs.SetActive(true);
    }
}
