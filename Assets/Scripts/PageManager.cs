using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static PageManager instance;
    [SerializeField] private GameObject closeButton;
    [SerializeField] private GameObject[] pages;
    private static int currentPage = 0;
    private int totPages;
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
        totPages = transform.childCount;
        pages = new GameObject[totPages];
        for(int i = 0; i < pages.Length; i++)
        {
            pages[i] = transform.GetChild(i).gameObject;
        }
        
    }

    public void ActivatePage(int page)
    {
        if (page >= 0 && page < totPages)
        {
            currentPage = page;
            pages[currentPage].SetActive(true);
        }
    }
    public void DeactivatePage(int page)
    {
        if (page >= 0 && page < totPages)
        {
            pages[page].SetActive(false);
        }
    }

    public void OpenBook()
    {
        closeButton.SetActive(true);
        ActivatePage(currentPage);
    }
    public void CloseBook()
    {
        DeactivatePage(currentPage);
        closeButton.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
