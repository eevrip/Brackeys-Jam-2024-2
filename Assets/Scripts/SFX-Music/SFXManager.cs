using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;
    private AudioSource audioSource;
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
        audioSource.volume = 1f;
        audioSource.Play();
    }
    public void PlaySoundClipVol(AudioClip clip, float volume)
    {
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.Play();
    }
}
