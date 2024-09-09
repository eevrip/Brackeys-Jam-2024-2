using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page : MonoBehaviour
{
    // Start is called before the first frame update
    private int pageNumber;
    private PageManager pageManager;
    void Start()
    {
        pageNumber = transform.GetSiblingIndex();
        pageManager = PageManager.instance;
    }

    public void TurnNextPage()
    {
        
      pageManager.ActivatePage(pageNumber+1);
      pageManager.DeactivatePage(pageNumber);
    }
    public void TurnPreviousPage()
    {
       pageManager.ActivatePage(pageNumber -1);
      pageManager.DeactivatePage(pageNumber);
    }
}
