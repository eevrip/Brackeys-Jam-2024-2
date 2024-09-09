using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static PageManager instance;
    [SerializeField] private GameObject closeButton;
    //[SerializeField] private GameObject[] pages;
    [SerializeField] private Page[] pages;
    private static int currentPage = 0;
    private int totPages;
    public bool isBookOpen;
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
       // pages = GetComponentsInChildren<Page>();
        pages = new Page[totPages];
        for(int i = 0; i < pages.Length; i++)
        {
            pages[i] = transform.GetChild(i).gameObject.GetComponent<Page>();
        }
        
    }

    public void ActivatePage(int page)
    {
        if (page >= 0 && page < totPages)
        {
            currentPage = page;
            // pages[currentPage].SetActive(true);
            pages[currentPage].Activate();
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
    void Update()
    {
        
    }
}
