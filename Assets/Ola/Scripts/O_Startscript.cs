using UnityEngine;

public class O_Startscript : MonoBehaviour
{
    public GameObject door;
    public GameObject chest;
    [SerializeField] private float maxDist = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Starter();
        }

        
    }

    public void Starter()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDist))
        {
            if (hit.collider.CompareTag("R1_Chest"))
            {
                door.transform.position = new Vector3(-10.5f, 5f, -4f);
            }
        }
    }
}
