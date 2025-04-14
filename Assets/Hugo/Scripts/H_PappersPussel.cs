using System.Xml.Schema;
using UnityEngine;

public class H_PappersPussel : MonoBehaviour
{
    public GameObject ljus;
    public GameObject back;
    public GameObject front;

    private MeshRenderer mr;
    public Material ingenKod;
    public Material visaKod;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 backV = ljus.transform.position - back.transform.position;
        Vector3 frontV = ljus.transform.position - front.transform.position;

        if (3f >= backV.magnitude && backV.magnitude > frontV.magnitude)
        {
            if (mr.material != visaKod)
            {
                mr.material = visaKod;
            }
        }
        else
        {
            if (mr.material != ingenKod)
            {
                mr.material = ingenKod;
            }
        }
    }
}
