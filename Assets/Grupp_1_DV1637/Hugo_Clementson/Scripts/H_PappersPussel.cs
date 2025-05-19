using System.Xml.Schema;
using UnityEngine;

public class H_PappersPussel : MonoBehaviour
{
    [Tooltip("Det GameObject som skall anv�ndas som ljus punkt")]
    public GameObject ljus;

    [Tooltip("GameObjectet som �r p� baksidan av pappret")]
    public GameObject back;

    [Tooltip("GameObjectet som �r p� framsidan av pappret")]
    public GameObject front;

    private MeshRenderer mr;

    [Tooltip("Det material som inte har n�gon kod p� sig")]
    public Material ingenKod;

    [Tooltip("Det material som har koden p� sig")]
    public Material visaKod;

    [Tooltip("P� vilket avst�nd pappret m�ste vara till ljuset f�r att visa koden")]
    [SerializeField] private float lightDist;
    
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        Vector3 backV = ljus.transform.position - back.transform.position;
        Vector3 frontV = ljus.transform.position - front.transform.position;

        if (lightDist >= backV.magnitude && backV.magnitude > frontV.magnitude)
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
