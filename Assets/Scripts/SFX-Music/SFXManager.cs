using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;
    [SerializeField]private AudioSource[] audioSource = new AudioSource[3];
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
       
        audioSource = GetComponentsInChildren<AudioSource>();
    }

    public void PlaySoundClip(AudioClip clip)
    {
        audioSource[0].clip = clip;
        audioSource[0].volume = 1f;
        audioSource[0].Play();
    }
    public void PlaySoundClipVol(AudioClip clip, float volume)
    {
        audioSource[2].clip = clip;
        audioSource[2].volume = 1f;
        audioSource[2].Play();
    }
    public void PlaySoundClipLowVol(AudioClip clip, float volume)
    {
        audioSource[2].clip = clip;
        audioSource[2].volume = volume;
        audioSource[2].Play();
    }
    public void PlaySoundClipLoud(AudioClip clip)
    {
        audioSource[1].clip = clip;
        audioSource[1].volume = 1f;
        audioSource[1].Play();
    }
    public void PlaySoundClipLoudVol(AudioClip clip, float volume)
    {
        audioSource[1].clip = clip;
        audioSource[1].volume = volume;
        audioSource[1].Play();
    }
}
