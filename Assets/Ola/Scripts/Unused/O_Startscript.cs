using UnityEngine;

public class O_Startscript : MonoBehaviour
{
    public GameObject door;

    public bool timerOn = false;

    public float timer = 0.0f;
    

    
    void Update()
    {
        if (timerOn)
        {
            timer += Time.deltaTime;
        }
    }

    public void Starter()
    {
        if (!timerOn)
            {
                door.transform.localPosition = new Vector3(-4, 3f, 10.25f);
                timerOn = true;
            }
       
    }
}
