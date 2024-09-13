using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    
    public static PageManager instance;
    [SerializeField] private GameObject closeButton;
    
    [SerializeField] private Page[] pages;
    
    private static int currentPage = 0;
    
    private int totPages;
    public bool isBookOpen;
    private SFXManager sfxManager;
    [SerializeField] private List<AudioClip> flippingPages;
    //create audio 
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
    }
    void Start()
    {
        sfxManager = SFXManager.instance;
        totPages = transform.childCount;
      
        pages = new Page[totPages];
        for(int i = 0; i < pages.Length; i++)
        {
            pages[i] = transform.GetChild(i).gameObject.GetComponent<Page>();
        }
        
    }

    public void ActivatePage(int page)
    {
        PlaySound();
        if (page >= 0 && page < totPages)
        {
            
            // pages[currentPage].SetActive(true);
            pages[page].Activate();
            currentPage = page;
        }
    }
    public void DeactivatePage(int page)
    {
        if (page >= 0 && page < totPages)
        {
            // pages[page].SetActive(false);
            pages[currentPage].Deactivate();
        }
    }

    public void OpenBook()
    {
        closeButton.SetActive(true);
        ActivatePage(currentPage);
        isBookOpen = true;
    }
    public void CloseBook()
    {
        DeactivatePage(currentPage);
        closeButton.SetActive(false);
        isBookOpen=false;
    }
    // Update is called once per frame
    public void PlaySound()
    {
        int i = Random.Range(0, flippingPages.Count);
      AudioClip clip = flippingPages[i];
        sfxManager.PlaySoundClipLoud(clip);

    }
    public int CurrentPage() { return currentPage; }
}
