using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextAnimation : MonoBehaviour
{
    [SerializeField] private Sprite img1;
    [SerializeField] private Sprite img2;
    [SerializeField] private Sprite img3;
    [SerializeField] private AudioClip hoverClip;
    [SerializeField] private AudioClip pressedClip;
    private SFXManager sfxManager;
    private Image currentImg;

    public void Start()
    {
        currentImg = GetComponent<Image>();
        sfxManager = SFXManager.instance;
    }
   
    public void SetImage(bool tilted)
    {
        if (tilted)
        {
            currentImg.sprite = img2;
        }
        else
            currentImg.sprite = img1;
    }
    public void SetImageTriple(float num) 
    {
        if(num <= 0.25)
        {
            if(img1 != null) 
                currentImg.sprite = img1;
        }
        else if(num >=0.75) 
        {
            if (img3 != null)
                currentImg.sprite=img3;
        }
        else
        {
            if (img2 != null)
                currentImg.sprite = img2;
        }
    }
    public void PlayHoverSound()
    {
        sfxManager.PlaySoundClipVol(hoverClip,0.3f);
    }
    public void PlayClickSound()
    {
        sfxManager.PlaySoundClip(pressedClip);
    }
}
