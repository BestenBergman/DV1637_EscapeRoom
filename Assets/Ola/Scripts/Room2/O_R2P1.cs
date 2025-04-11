using UnityEngine;

public class O_R2P1 : MonoBehaviour
{
    public bool on = false;
    public int tmpAngle = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SwitchLever();
    }

    public void SwitchLever()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            if (Physics.Raycast(ray, out hit, 10f))
            {
                if (hit.transform.tag == "R2_PuzzleLever")
                {
                    Debug.Log(hit.transform.gameObject.name);
                    
                    if (!on)
                    {
                        hit.transform.gameObject.transform.parent.eulerAngles = new Vector3(0, 0, -22.5f);
                        on = true;
                    }
                    else
                    {
                        hit.transform.gameObject.transform.parent.eulerAngles = new Vector3(0, 0, 22.5f);
                        on = false;
                    }
                }
            }
        }
    }
}

    
