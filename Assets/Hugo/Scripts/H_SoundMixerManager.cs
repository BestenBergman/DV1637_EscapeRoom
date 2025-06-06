using UnityEngine;
using UnityEngine.Audio;

public class H_SoundMixerManager : MonoBehaviour
{
    // Skript taget fr�n YouTube: https://www.youtube.com/watch?v=DU7cgVsU2rM

    [SerializeField] private AudioMixer audioMixer;

    public void SetMasterVolume (float level)
    {
        audioMixer.SetFloat("masterVolume", Mathf.Log10(level) * 20f);
    }

    public void SetSoundFXVolume (float level)
    {
        audioMixer.SetFloat("soundFXVolume", Mathf.Log10(level) * 20f);
    }

    public void SetMusicVolume (float level)
    {
        audioMixer.SetFloat("musicVolume", Mathf.Log10(level) * 20f);
    }
}
