using UnityEngine;
using UnityEngine.UIElements;

public class SlutPussel : MonoBehaviour
{
    public RightChild bBF;
    public RightChild rBF;
    public RightChild gBF;

    public GameObject hW;
    public Material m1;
    public Material m2;

    [SerializeField] private bool active;

    private void Start()
    {
        active = false;
    }
    private void Update()
    {
        if (active)
        {
            CheckShards();
        }
    }

    public void SwitchState()
    {
        if (active)
        {
            active = false;
            hW.GetComponent<MeshRenderer>().material = m1;
        }
        else
        {
            active = true;
        }
    }

    public void CheckShards()
    {
        if (bBF.HasRightChild() && rBF.HasRightChild() && gBF.HasRightChild())
        {
            hW.GetComponent<MeshRenderer>().material = m2;
        }
        else
        {
            hW.GetComponent<MeshRenderer>().material = m1;
        }
    }
}
