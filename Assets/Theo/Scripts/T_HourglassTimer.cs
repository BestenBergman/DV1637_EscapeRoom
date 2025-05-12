using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class T_HourglassTimer : MonoBehaviour
{
    public TextMeshProUGUI timerTxt;
    public Image imgTimerUp;              
    public Image imgTimerDown;

    public float maxGameTime = 600f;    // Max game time (600 seconds = 10 minutes)
    public float timer;                
    private float lerpSpeed = 3f;


    public bool startTimer = false;
    private Vignette vid;


    private void Start()
    {
        timer = maxGameTime;

        imgTimerUp.fillAmount = timer / maxGameTime;
        imgTimerDown.fillAmount = 1f - (timer / maxGameTime);

    }

    private void Update()
    {
        if (startTimer)
        {
            if (timer > 0f)
            {
                timer -= Time.deltaTime;

                if (timer < 0f)
                {
                    timer = -0.1f;
                }
            }

            // Calculate seconds and milliseconds
            int min = Mathf.FloorToInt(timer / 60);
            int sec = Mathf.FloorToInt(timer % 60);



            // Format the countdown timer text
            string txtTime = string.Format("{0:00}:{1:00}", min, sec);
            timerTxt.text = txtTime;

            vid.intensity.value = Mathf.Clamp(1f - timer / (maxGameTime / 10), 0f, 1f);

            Fill(imgTimerDown, true);
            Fill(imgTimerUp, false);

            ColorChanger();
        }
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
        if (timer > maxGameTime/2f)
        {
            imgTimerUp.color = Color.green;
            imgTimerDown.color = Color.green;
        }
        else if (timer > maxGameTime/10f)
        {
            imgTimerUp.color = Color.yellow;
            imgTimerDown.color = Color.yellow;
        }
        else
        {
            imgTimerUp.color = Color.red;
            imgTimerDown.color = Color.red;
        }
        //imgTimerUp.color = Color.Lerp(Color.red, Color.green, timer / maxGameTime);
        //imgTimerDown.color = Color.Lerp(Color.red, Color.green, timer / maxGameTime);
    }
}
