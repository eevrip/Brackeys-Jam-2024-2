using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page : MonoBehaviour
{
    // Start is called before the first frame update
    private int pageNumber;
    private PageManager pageManager;
    private bool isSolved = true;
    private GameObject journal;
    private GameObject puzzle;
    [SerializeField] List<GameObject> externalObjects; 
    void Start()
    {
        pageNumber = transform.GetSiblingIndex();
        pageManager = PageManager.instance;
    }

    public void TurnNextPage()
    {
        if (isSolved)
        {
            pageManager.ActivatePage(pageNumber + 1);
            pageManager.DeactivatePage(pageNumber);
        }
    }
    public void TurnPreviousPage()
    {
       pageManager.ActivatePage(pageNumber -1);
      pageManager.DeactivatePage(pageNumber);
    }
    private void Update()
    {
        if(!isSolved) { 
            IsSolved();
        }
    }
    public void IsSolved()
    {
        if (isSolved)
        {
            puzzle.SetActive(false);
            journal.SetActive(true);
            
        }
        
    }
    public void Deactivate()
    {
        if (externalObjects != null)
        {
            foreach (GameObject obj in externalObjects)
            {
                obj.SetActive(false);
            }
        }
        gameObject.SetActive(false);
    }
    public void Activate()
    {
        if (externalObjects != null)
        {
            foreach (GameObject obj in externalObjects)
            {
                obj.SetActive(true);
            }
        }
        gameObject.SetActive(true);
    }
}
