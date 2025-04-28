using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class T_HourglassTimer : MonoBehaviour
{
    public TextMeshProUGUI timerTxt;
    public Image imgTimerUp;              
    public Image imgTimerDown;

    public float maxGameTime = 600f;    // Max game time (600 seconds = 10 minutes)
    public float timer;                
    private float lerpSpeed = 3f;

    private void Start()
    {
        timer = maxGameTime;

        imgTimerUp.fillAmount = timer / maxGameTime;
        imgTimerDown.fillAmount = 1f - (timer / maxGameTime);

    }

    private void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;

            if (timer < 0f)
            {
                timer = 0f;
            }   
        }

        // Calculate seconds and milliseconds
        int sec = Mathf.FloorToInt(timer);
        int milli = Mathf.FloorToInt((timer - sec) * 100f);



        // Format the countdown timer text
        string txtTime = string.Format("{0:000}.{1:00}", sec, milli);
        timerTxt.text = txtTime;

        Fill(imgTimerDown, true);
        Fill(imgTimerUp, false);

        ColorChanger();
    }


    private void Fill(Image img, bool isFilling)
    {
        float targetFill;

        if (isFilling)
        {
            targetFill = 1f - (timer / maxGameTime);
        }
        else
        {
            targetFill = timer / maxGameTime;
        }

        img.fillAmount = Mathf.Lerp(img.fillAmount, targetFill, lerpSpeed * Time.deltaTime);
    }

    void ColorChanger()
    {
        imgTimerUp.color = Color.Lerp(Color.red, Color.green, timer / maxGameTime);
        imgTimerDown.color = Color.Lerp(Color.red, Color.green, timer / maxGameTime);
    }
}
