using UnityEngine;

public class O_TorchLever : MonoBehaviour
{
    public GameObject flames;
    public GameObject lever;
    [HideInInspector] public bool check;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flames.SetActive(false);
        check = lever.GetComponent<O_R2P1>().on;
    }

    // Update is called once per frame
    void Update()
    {
        check = lever.GetComponent<O_R2P1>().on;
        if (!check)
        {
            flames.SetActive(false);
        }
        if (check)
        {
            flames.SetActive(true);
        }
    }
}
