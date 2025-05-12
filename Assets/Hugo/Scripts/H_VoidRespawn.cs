using System.Linq;
using UnityEngine;

public class H_VoidRespawn : MonoBehaviour
{
    [HideInInspector] public H_PlayerStats ps;

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
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = other.GetComponent<H_ItemSpawn>().spawnPosition;
                other.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}
