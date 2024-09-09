using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    private PageManager pageManager;
    // Start is called before the first frame update
    void Start()
    {
        pageManager = PageManager.instance;
    }

    
    public void OpenBook()
    {
        pageManager.OpenBook();
    }
}
