using TMPro;
using UnityEngine;

public class T_GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI TimeTxt;
    public GameObject UI;
    public GameObject Trigger;

    public GameObject winScreen;
    public GameObject gameOverScreen;

    private T_HourglassTimer hourglassTimer;
    private T_TriggerEnd trigger;

    private void Start()
    {
        hourglassTimer = UI.GetComponent<T_HourglassTimer>();
        trigger = Trigger.GetComponent<T_TriggerEnd>();
    }

    private void Update()
    {
        if (trigger.GameOver)
        {
            if (hourglassTimer.timer <= 0)
            {
                winScreen.SetActive(true);
            }
            else
            {
                gameOverScreen.SetActive(true);
            }

            TimeTxt.text = "Time Left: "+hourglassTimer.timer.ToString();
        }

    }



}
