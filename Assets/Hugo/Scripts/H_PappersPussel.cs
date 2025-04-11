using System.Xml.Schema;
using UnityEngine;

public class H_PappersPussel : MonoBehaviour
{
    public GameObject ljus;
    public GameObject x_ax;
    public GameObject y_ax;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 X = x_ax.transform.position - transform.position;
        Vector3 Y = y_ax.transform.position - transform.position;
        Vector3 Z = ljus.transform.position - transform.position;
        float det = Determinant(X, Y, Z);
    }

    private float Determinant(Vector3 u, Vector3 v, Vector3 w)
    {
        return u.x * (v.y * w.z - w.y * v.z) - v.x * (u.y * w.z - w.y * u.z) + w.x * (u.y * v.z - v.y * u.z);
    }
}
