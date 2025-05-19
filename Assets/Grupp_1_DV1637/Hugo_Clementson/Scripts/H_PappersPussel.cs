using System.Xml.Schema;
using UnityEngine;

public class H_PappersPussel : MonoBehaviour
{
    [Tooltip("Det GameObject som skall användas som ljus punkt")]
    public GameObject ljus;

    [Tooltip("GameObjectet som är på baksidan av pappret")]
    public GameObject back;

    [Tooltip("GameObjectet som är på framsidan av pappret")]
    public GameObject front;

    private MeshRenderer mr;

    [Tooltip("Det material som inte har någon kod på sig")]
    public Material ingenKod;

    [Tooltip("Det material som har koden på sig")]
    public Material visaKod;

    [Tooltip("På vilket avstånd pappret måste vara till ljuset för att visa koden")]
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
