using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>
public class T_HourglassTimer : MonoBehaviour
{
    public TextMeshProUGUI timerTxt;
    
    // Hourglass images
    public Image imgTimerUp;              
    public Image imgTimerDown;

    // Max game time (600 seconds = 10 minutes)
    public float maxGameTime = 600f;
    public float timer;                
    
    // Speed for transitions in img sliders
    private float lerpSpeed = 3f; 

    // Controls if start or stop timmer.
    public bool startTimer = false;

    //Hugo
    [Tooltip("Global Volume")]
    public Volume globalVolume;
    private Vignette vid;

    [Tooltip("Ljudet som ska spelas när halva tiden har gått")]
    [SerializeField] private AudioClip halfTimeSound;

    [Tooltip("Ljudet som ska spelas när det är en minut kvar")]
    [SerializeField] private AudioClip lastMinSound;
    private bool playedHalfTimeSound = false;
    private bool playedLastMinSound = false;


    private void Start()
    {
        timer = maxGameTime;

        // Initialize fill states.
        imgTimerUp.fillAmount = timer / maxGameTime;
        imgTimerDown.fillAmount = 1f - (timer / maxGameTime);
    }

    private void Update()
    {
        if (startTimer)
        {
            if (timer > 0f)
            {
                // Timer counts down.
                timer -= Time.deltaTime;

                if (timer < 0f)
                {
                    timer = -0.1f;
                }
            }

            // Calculate seconds and milliseconds.
            int min = Mathf.FloorToInt(timer / 60);
            int sec = Mathf.FloorToInt(timer % 60);



            // Format the countdown timer text.
            string txtTime = string.Format("{0:00}:{1:00}", min, sec);
            timerTxt.text = txtTime;

            // Hämtar och applicerar en fade effect när det bara är en tiondels av tiden kvar
            globalVolume.profile.TryGet(out vid);
            vid.intensity.value = Mathf.Clamp(1f - timer / (maxGameTime / 10), 0f, 1f);



            Fill(imgTimerDown, true);
            Fill(imgTimerUp, false);

            UpdateTimerColor();
        }
    }

    /// <summary>
    /// Updates the fill amount of a Image based on the current timer value.
    /// </summary>
    /// <param name="img"></param>
    /// <param name="isFilling"></param>
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

    /// <summary>
    /// Changes color and plays sounds based on the time.
    /// </summary>
    void UpdateTimerColor()
    {
        if (timer > maxGameTime/2f)
        {
            imgTimerUp.color = Color.green;
            imgTimerDown.color = Color.green;
        }
        else if (timer > maxGameTime/10f)
        {
            if (halfTimeSound != null && !playedHalfTimeSound)
            {
                playedHalfTimeSound = true;
                H_SoundFXManager.instance.PlaySoundFXClip(halfTimeSound, transform, 2f);
            }
            imgTimerUp.color = Color.yellow;
            imgTimerDown.color = Color.yellow;
        }
        else
        {
            if (lastMinSound != null && !playedLastMinSound)
            {
                playedLastMinSound = true;
                H_SoundFXManager.instance.PlaySoundFXClip(lastMinSound, transform, 3f);
            }
            imgTimerUp.color = Color.red;
            imgTimerDown.color = Color.red;
        }
    }
}
