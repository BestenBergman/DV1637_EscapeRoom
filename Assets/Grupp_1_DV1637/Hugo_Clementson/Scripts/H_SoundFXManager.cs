using UnityEngine;

public class H_SoundFXManager : MonoBehaviour
{
    // Skript taget från YouTube: https://www.youtube.com/watch?v=DU7cgVsU2rM

    public static H_SoundFXManager instance;

    [SerializeField] private AudioSource soundFXObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        AudioSource audioSorce = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
        audioSorce.clip = audioClip;
        audioSorce.volume = volume;
        audioSorce.Play();
        float clipLenght = audioSorce.clip.length;
        Destroy(audioSorce.gameObject, clipLenght);
    }

    public void PlayRandomSoundFXClip(AudioClip[] audioClip, Transform spawnTransform, float volume)
    {
        int rand = Random.Range(0, audioClip.Length);
        AudioSource audioSorce = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
        audioSorce.clip = audioClip[rand];
        audioSorce.volume = volume;
        audioSorce.Play();
        float clipLenght = audioSorce.clip.length;
        Destroy(audioSorce.gameObject, clipLenght);
    }
}
