using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SudokuManager : MonoBehaviour
{
    [SerializeField] private SudokuTile[] tiles;
    [SerializeField] private Page page;
    private bool isComplete;
    public bool IsComplete => isComplete;
    // Start is called before the first frame update
    void Start()
    {
        tiles = new SudokuTile[9];
        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i] = transform.GetChild(i).gameObject.GetComponent<SudokuTile>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PuzzleComplete()
    {
        foreach (SudokuTile tile in tiles)
        {
            if (!tile.IsCorrectPosition)
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
