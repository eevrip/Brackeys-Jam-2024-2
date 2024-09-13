using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenManager : MonoBehaviour
{
    [SerializeField] private KitchenItem[] items;
    [SerializeField] private Page page;
    private bool isComplete;
    public bool IsComplete => isComplete;
    // Start is called before the first frame update
    void Start()
    {
        items = new KitchenItem[10];
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = transform.GetChild(i).gameObject.GetComponent<KitchenItem>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PuzzleComplete()
    {
        foreach (KitchenItem item in items)
        {
            if (!item.IsCorrectPosition)
            {
                // Debug.Log("not correct " + tile);
                return;
            }
        }
        isComplete = true;

        page.SetSolved(true);
        // Debug.Log("correct");
    }
}
