using UnityEngine;

[RequireComponent(typeof(H_PlayerStats))]

public class H_Inspect : MonoBehaviour
{
    [HideInInspector] public H_PlayerStats ps;
    private Vector3 oldRot = Vector3.zero;

    private GameObject item = null;

    private void Start()
    {
        ps = GetComponent<H_PlayerStats>();
    }
    private void Update()
    {
        if (ps.isInspecting)
        {
            if (Input.GetMouseButton(0))
            {
                //Vector3 oldRot = new Vector3(item.transform.localRotation.x, item.transform.localRotation.y, item.transform.localRotation.z);
                //Debug.Log(oldRot);
                Vector3 newRot = new Vector3(oldRot.x + Input.GetAxis("Mouse Y"), oldRot.y - Input.GetAxis("Mouse X"), oldRot.z);
                item.transform.localRotation = Quaternion.Euler(newRot);
                oldRot = newRot;
            }
        }
    }
    public void SwitchInspect()
    {
        if (!ps.isInspecting)
        {
            Inspect();
        }
        else
        {
            CloseInspection();
        }
    }
    public void Inspect()
    {
        ps.isInspecting = true;
        item = transform.GetChild(0).GetChild(1).gameObject;
        item.transform.localPosition = ps.InspectPos;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void CloseInspection()
    {
        item.transform.localPosition = ps.HoldPos;
        Cursor.lockState = CursorLockMode.Locked;
        ps.isInspecting= false;
    }
}
