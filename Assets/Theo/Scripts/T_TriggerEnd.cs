using UnityEngine;

public class T_TriggerEnd : MonoBehaviour
{
    public bool GameOver = false;
    public GameObject UI;

    private T_HourglassTimer hourglassTimer;
    private void Start()
    {
        hourglassTimer = UI.GetComponent<T_HourglassTimer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        hourglassTimer.startTimer = false;
        GameOver = true;
    }

}
