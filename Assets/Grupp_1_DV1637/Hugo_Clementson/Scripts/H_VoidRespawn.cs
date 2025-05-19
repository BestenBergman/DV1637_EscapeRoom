using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

public class H_VoidRespawn : MonoBehaviour
{
    [HideInInspector] public H_PlayerStats ps;

    [Tooltip("Den TextMeshProGUI som skall användas för att visa om något faller utanför")]
    public TextMeshProUGUI failSafe;

    private void Start()
    {
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<H_PlayerStats>();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (ps.ItemTags.Contains(other.transform.tag))
        {
            //Koll om spelaren håller i "other"
            bool heldByPlayer = false;
            if (other.transform.parent)
            {
                if (other.transform.parent.parent.tag == "Player")
                {
                    heldByPlayer = true;
                }
            }
            if (!heldByPlayer)
            {
                StartCoroutine(Failsafe(other.gameObject));
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = other.GetComponent<H_ItemSpawn>().spawnPosition;
                other.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }

    /// <summary>
    /// Visar failsafe medelandet i tre sekunder
    /// </summary>
    /// <param name="obj">GameObjectet som har fallit ut</param>
    /// <returns></returns>
    IEnumerator Failsafe(GameObject obj)
    {
        failSafe.text = "Fail-safe initiated:\n" + obj.name + "\nhas been respawned!";
        yield return new WaitForSeconds(3);
        failSafe.text = "";
    }
}
