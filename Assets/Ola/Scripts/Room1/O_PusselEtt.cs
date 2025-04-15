using UnityEngine;

public class O_PusselEtt : MonoBehaviour
{
    public bool placedCorrectly = false;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == gameObject.tag + "plate")
        {
            placedCorrectly = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == gameObject.tag + "plate")
        {
            placedCorrectly = false;
        }
    }
}
