using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    private PageManager pageManager;
    private Collider2D col;
    [SerializeField] private AudioClip pickUp;
    [SerializeField] private AudioClip putDown;
    [SerializeField] private AudioClip open;
    [SerializeField] private AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        pageManager = PageManager.instance;
        col = GetComponent<Collider2D>();
        sound = GetComponent<AudioSource>();
    }

    
    public void OpenBook()
    {
        sound.clip = open;
        sound.Play();
        pageManager.OpenBook();
        col.enabled = false;
    }
    public void CloseBook()
    {
        sound.clip = putDown;
        sound.Play();
        pageManager.CloseBook();
        col.enabled = true;
    }

    public void PutDown() {
        sound.clip = putDown;
        sound.Play();
    }
    public void PickUp()
    {
        sound.clip = pickUp;
        sound.Play();
    }
}
