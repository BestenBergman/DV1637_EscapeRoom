using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class H_Interact : MonoBehaviour
{
    [HideInInspector] public H_PlayerStats ps;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ps = GetComponent<H_PlayerStats>();
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
            if (ps.ItemTags.Contains(hit.transform.tag))
            {
                PickUpItem(hit.transform.gameObject);
            }
            else if (hit.transform.tag == "Lever")
            {
                hit.transform.gameObject.GetComponent<SlutPussel>().SwitchState();
            }
            else if (hit.transform.tag == "Respawn")
            {
                InteractWithButtons(hit.transform.gameObject);
            }
            else if (ps.hasItem)
            {
                DropItem();
            }
        }
        else if (ps.hasItem)
        {
            DropItem();
        }
    }

    public void PickUpItem(GameObject item)
    {
        if (ps.hasItem)
        {
            gameObject.transform.GetChild(0).transform.GetChild(1).GetComponent<Rigidbody>().isKinematic = false;
            gameObject.transform.GetChild(0).transform.GetChild(1).parent = gameObject.transform.parent;
        }

        ps.hasItem = true;
        item.transform.parent = gameObject.transform.GetChild(0);
        item.transform.localRotation = Quaternion.identity;
        item.transform.localPosition = ps.HoldPos;
        item.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void DropItem()
    {
        gameObject.transform.GetChild(0).transform.GetChild(1).GetComponent<Rigidbody>().isKinematic = false;
        gameObject.transform.GetChild(0).transform.GetChild(1).parent = gameObject.transform.parent;
        ps.hasItem = false;
    }

    public void InteractWithButtons(GameObject button)
    {
        button.transform.parent.GetComponent<ButtonKontroler>().UpdateButtons(button);
        if (button.transform.parent.parent.GetComponent<KontrolerKontrol>().CheckersAreRight())
        {
            Debug.Log("yay");
        }
    }
}
