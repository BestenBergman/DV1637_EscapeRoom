using NUnit.Framework;
using System;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(H_PlayerStats))]

public class H_Inspect : MonoBehaviour
{
    [HideInInspector] public H_PlayerStats ps;
    [HideInInspector] public GameObject pov;

    [Tooltip("Hastigheten man roterar objekt")]
    [SerializeField] private float rotSpeed = 200f;

    private GameObject item = null;

    private void Start()
    {
        ps = GetComponent<H_PlayerStats>();
        pov = gameObject.transform.GetChild(0).gameObject;
    }
    private void Update()
    {
        if (ps.isInspecting)
        {
            float deltaRotX = -Input.GetAxis("Mouse X");
            float deltaRotY = Input.GetAxis("Mouse Y");
            if (Input.GetMouseButton(0))
            {
                //https://www.youtube.com/watch?v=UBIPqG1-KuY
                item.transform.rotation = 
                    Quaternion.AngleAxis(deltaRotX * rotSpeed * Time.deltaTime, pov.transform.up) *
                    Quaternion.AngleAxis(deltaRotY * rotSpeed * Time.deltaTime, pov.transform.right) *
                    item.transform.rotation;
            }
        }
    }

    /// <summary>
    /// Byter mellan att inspektera eller att sluta inspektera
    /// </summary>
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

    /// <summary>
    /// Gör att man inspekterar objektet man har i hanen
    /// </summary>
    public void Inspect()
    {
        ps.isInspecting = true;
        item = transform.GetChild(0).GetChild(1).gameObject;
        item.transform.localPosition = ps.InspectPos;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    /// <summary>
    /// Gör att man slutar inspektera ett objekt
    /// </summary>
    public void CloseInspection()
    {
        item.transform.localPosition = ps.HoldPos;
        Cursor.lockState = CursorLockMode.Locked;
        ps.isInspecting= false;
    }

}
