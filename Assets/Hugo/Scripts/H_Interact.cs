using UnityEngine;

public class H_Interact : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f));
        if (Physics.Raycast(ray, out hit, 3f))
        {
            if (hit.transform.tag == "Lever")
            {
                hit.transform.gameObject.GetComponent<SlutPussel>().SwitchState();
            }
        }
    }
}
