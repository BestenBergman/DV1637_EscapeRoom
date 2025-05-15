using System.Collections;
using UnityEngine;

public class O_Teleporter : MonoBehaviour

{
    [HideInInspector] public GameObject player;
    [HideInInspector] public H_PlayerStats ps;
    public Transform endPosition;
    public bool isTeleporting = false;
    [HideInInspector] public Vector3 tpPosition = Vector3.zero;

    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ps = player.GetComponent<H_PlayerStats>();
        tpPosition = endPosition.transform.position;
    }

    /// <summary>
    /// Trigger that starts a counter that will teleport the player at the end as long as the player doesn't have teleportation cooldown
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject == player && !ps.hasTeleported)
        {
            isTeleporting = true;
            StartCoroutine("Teleporting");
        }
        
    }

    /// <summary>
    /// Trigger that cancel teleportation if the player steps of before the counter has completed.
    /// Also makes sure there aren't multiple instances of teleportation occuring when the first one has been completed.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isTeleporting = false;
        }
    }   

   


    IEnumerator Teleporting()
    {
        yield return new WaitForSeconds(0.8f);
        if (isTeleporting)
        {
            ps.hasTeleported = true;
            player.transform.position = tpPosition;
            
            
            yield return new WaitForSeconds(3.0f);
            ps.hasTeleported = false;
        }
        
    }
}
