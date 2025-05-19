using UnityEngine;

public class H_TriggerEndWalk : MonoBehaviour
{
    [HideInInspector] public H_PlayerStats ps;

    void Start()
    {
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<H_PlayerStats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            other.gameObject.GetComponent<O_CameraBasedMovement>().yRot = 180f;
            ps.fWalk = true;
            ps.fLookDir = Vector2.zero;
            ps.fWalkDir = new Vector3(0, 0, 1);
        }
    }
}
