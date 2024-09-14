using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientManager : MonoBehaviour
{
    public static AmbientManager instance;
    [SerializeField]private AudioSource[] audioSrc; 
    void Awake()
    {

        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
        
      
    }


    public void playThunder()
    {
         audioSrc[1].loop = true;
        audioSrc[1].Play();
        StartCoroutine(StartFadeSound(audioSrc[0], 3f, 0.6f));
    }
    public void SetVolumeRain(float volume)
    {
        audioSrc[1].Stop();
        StartCoroutine(StartFadeSound(audioSrc[0], 3f, volume));
        
    }
    public IEnumerator StartFadeSound(AudioSource audioSource, float duration, float targetVolume)
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
