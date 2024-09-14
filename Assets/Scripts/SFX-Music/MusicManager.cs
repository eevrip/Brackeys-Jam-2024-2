using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    private AudioSource audioSource;
    public AudioSource AudioSrc => audioSource;
    void Awake()
    {

        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySoundClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
    public void StopSoundClip()
    {

        StartCoroutine(StartFadeSound(10f, 0f));
    }
    public void LowerSoundClipAt(float duration, float difference)
    {
        float targetVolume = audioSource.volume - difference;
        StartCoroutine(StartFadeSound(duration, targetVolume));
    }
    public IEnumerator StartFadeSound(float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }

}
