using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page : MonoBehaviour
{
    // Start is called before the first frame update
    private int pageNumber;
    private PageManager pageManager;
    [SerializeField]private bool isSolved;
    [SerializeField]private GameObject journal;
    [SerializeField] private GameObject puzzle;
    [SerializeField] private GameObject answer;
    [SerializeField] private GameObject fuzziness;
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
            //pageManager.DeactivatePage(pageNumber);
            Deactivate();
        }
    }
    public void TurnPreviousPage()
    { 
       pageManager.ActivatePage(pageNumber -1);
        //pageManager.DeactivatePage(pageNumber);
       Deactivate();
    }
   
    public void IsSolved()
    {
        if (isSolved)
        {
            // puzzle.SetActive(false);
            //journal.SetActive(true);
            SetActivityOfExternalItems(false);
            answer.SetActive(true);
            
        }
        else
        {
            SetActivityOfExternalItems(true);
            answer.SetActive(false);
        }
        
    }
    public void SetSolved(bool isSolved)
    {
        this.isSolved = isSolved;
       
            IsSolved();
        
    }
    public void Deactivate()
    {
        SetActivityOfExternalItems(false);
        gameObject.SetActive(false);
    }
    public void Activate()
    {
        IsSolved();
        gameObject.SetActive(true);
    }
    public void SetActivityOfExternalItems(bool isActive)
    {
        if (externalObjects != null)
        {
            foreach (GameObject obj in externalObjects)
            {
                obj.SetActive(isActive);
            }
        }
    }
}
