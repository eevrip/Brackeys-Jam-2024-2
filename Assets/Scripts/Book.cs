using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    private PageManager pageManager;
    private Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        pageManager = PageManager.instance;
        col = GetComponent<Collider2D>();
    }

    
    public void OpenBook()
    {
        pageManager.OpenBook();
        col.enabled = false;
    }
    public void CloseBook()
    {
        pageManager.CloseBook();
        col.enabled = true;
    }

    
}
