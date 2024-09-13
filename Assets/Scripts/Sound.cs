using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    private SFXManager sfxManager;
    // Start is called before the first frame update
    public void Start()
    {
        
        sfxManager = SFXManager.instance;
    }

    public void PlaySound(float volume)
    {
        sfxManager.PlaySoundClipLoudVol(clip, volume);
    }
}
