using System.Collections;
using UnityEngine;

public class O_Teleporter : MonoBehaviour

{
    [HideInInspector] public GameObject player;
    public Transform endPosition;
    public bool hasTeleported = false;
    public bool isTeleporting = false;
    public bool coroutineStarted = false;
    public bool tpCooldown = false;
    [HideInInspector] public Vector3 tpPosition = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        tpPosition = endPosition.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject == player)
        {
            Debug.Log("Aow)");
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

    IEnumerator TeleportCooldown()
    {
        tpCooldown = true;
        yield return new WaitForSeconds(3.0f);
        tpCooldown = false;
    }


    IEnumerator Teleporting()
    {
        yield return new WaitForSeconds(0.5f);
        if (isTeleporting && !hasTeleported)
        {
            player.transform.position = tpPosition;
            hasTeleported = true;
            Debug.Log("Good Heavens Marty!");
        }
        yield return new WaitForSeconds(3.0f);
        hasTeleported = false;
    }
}
