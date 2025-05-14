using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

public class H_VoidRespawn : MonoBehaviour
{
    [HideInInspector] public H_PlayerStats ps;
    public TextMeshProUGUI failSafe;

    private void Start()
    {
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<H_PlayerStats>();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (ps.ItemTags.Contains(other.transform.tag))
        {
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
                failSafe.text = "Fail-safe initiated:\n" + other.name + "\nhas been respawned!";
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = other.GetComponent<H_ItemSpawn>().spawnPosition;
                other.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
        StartCoroutine("Failsafe");
    }

    IEnumerator Failsafe()
    {
        yield return new WaitForSeconds(3);
        failSafe.text = "";
    }
}
