using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class T_Timer : MonoBehaviour
{
    public Slider timerSlider;
    private Image imgFill;

    public TextMeshProUGUI timerTxt;
    public float gameTime = 600; //max tid för uppgiften (10 min max)
    public float timer = 0f;


    private void Start()
    {
        imgFill = timerSlider.fillRect.GetComponent<Image>();

        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;

    }

    private void Update()
    {
        timer += Time.deltaTime;

        float time = gameTime - timer;

        int sec = Mathf.FloorToInt(time); // seconds
        int milli = Mathf.FloorToInt((time - sec) * 100f); // milliseconds


        string txtTime = string.Format("{0:000}.{1:00}", sec, milli);
        if (time <= 0)
        {
            txtTime = "000.00";
            time = 0;
        }

        timerTxt.text = txtTime;
        timerSlider.value = time;

        ColorChanger(time);
    }

    void ColorChanger(float time)
    {
        Color hourglassColor = Color.Lerp(Color.red, Color.green, (time / gameTime));
        imgFill.color = hourglassColor;
    }

}
