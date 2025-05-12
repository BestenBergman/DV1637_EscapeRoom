using UnityEngine;

public class O_TorchLever : MonoBehaviour
{
    public GameObject flames;
    public GameObject lever;
    //public GameObject handle;
    [HideInInspector] public bool checkOne;
    //[HideInInspector] public bool checkTwo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flames.SetActive(false);
        checkOne = lever.GetComponent<O_R2P1>().on;
    }

    // Update is called once per frame
    void Update()
    {
        Switchlevers();
    }
    public void Switchlevers()
    {
        checkOne = lever.GetComponent<O_R2P1>().on;
        if (!checkOne)
        {
            flames.SetActive(false);
        }
        if (checkOne)
        {
            flames.SetActive(true);
        }
    }

}
