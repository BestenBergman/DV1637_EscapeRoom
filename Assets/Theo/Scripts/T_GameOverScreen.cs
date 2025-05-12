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

    private bool gameHasEnded;

    private void Start()
    {
        winScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        gameHasEnded = false;

        hourglassTimer = UI.GetComponent<T_HourglassTimer>();
        trigger = Trigger.GetComponent<T_TriggerEnd>();
    }

    private void Update()
    {
        if (trigger.Win && !gameHasEnded)
        {
            gameHasEnded = true;
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;

            winScreen.SetActive(true);

            TimeTxt.text = "Time Left: " + 
                string.Format("{0:00} min {1:00}.{2:000} sec", 
                Mathf.FloorToInt(hourglassTimer.timer / 60), 
                Mathf.FloorToInt(hourglassTimer.timer % 60), 
                Mathf.FloorToInt((hourglassTimer.timer - Mathf.FloorToInt(hourglassTimer.timer)) * 1000f));
        }

        if (hourglassTimer.timer <= -0.1f && !gameHasEnded)
        {
            gameHasEnded = true;
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;

            gameOverScreen.SetActive(true);
        }

    }



}
