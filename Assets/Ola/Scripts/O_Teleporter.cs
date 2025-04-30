using System.Collections;
using UnityEngine;

public class O_Teleporter : MonoBehaviour

{
    [HideInInspector] public GameObject player;
    [HideInInspector] public H_PlayerStats ps;
    public Transform endPosition;
    public bool isTeleporting = false;
    [HideInInspector] public Vector3 tpPosition = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        ps = player.GetComponent<H_PlayerStats>();
        tpPosition = endPosition.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject == player && !ps.hasTeleported)
        {
            isTeleporting = true;
            StartCoroutine("Teleporting");
        }
        
    }

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
            
            //Debug.Log("Good Heavens Marty!");
            yield return new WaitForSeconds(3.0f);
            ps.hasTeleported = false;
        }
        
    }
}
