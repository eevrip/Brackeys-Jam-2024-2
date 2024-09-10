using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GriPuzzleManager : MonoBehaviour
{
    [SerializeField] private GridPuzzle[] grids;
    [SerializeField] private Page page;
    // Start is called before the first frame update
    void Start()
    {
        grids = new GridPuzzle[3];
        for (int i = 0; i < grids.Length; i++)
        {
            grids[i] = transform.GetChild(i).gameObject.GetComponent<GridPuzzle>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PuzzleComplete()
    {
        foreach (GridPuzzle puzzle in grids)
        {
            if (!puzzle.IsSolved)
            {
                Debug.Log("not correct");
                return;
            }
        }
        page.SetSolved(true);
        Debug.Log("correct");
    }
}
