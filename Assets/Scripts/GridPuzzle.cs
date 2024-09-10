using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPuzzle : MonoBehaviour
{
    [SerializeField]private List<Sprite> scribbles = new List<Sprite>();
    //Create a list (like above) for erasing and writing sounds 
    [SerializeField] private bool[] solution = new bool[9];
    [SerializeField] private GameObject[] cells;
    [SerializeField] private GriPuzzleManager manager;
    private bool isSolved;
    public bool IsSolved => isSolved;
    void Start()
    {
        cells = new GameObject[9];
        for (int i = 0; i < cells.Length; i++)
        {
            cells[i] = transform.GetChild(i).GetChild(0).gameObject;
        }
    }

    
    public void UpdateCell(GameObject obj)
    { if (!isSolved)
        {
            PlaySound(obj.activeSelf); //when the obj is already active, you will erase it
            obj.SetActive(!obj.activeSelf);

            SpriteRenderer sprRnd = obj.GetComponent<SpriteRenderer>();
            int scribble = Random.Range(0, scribbles.Count);
            sprRnd.sprite = scribbles[scribble];

            IsCorrect();
        }
        else
        {
          // manager.PuzzleComplete();
        }
    }

    public bool IsCorrect()
    {
        for(int i=0; i< cells.Length; i++)
        {
            if(cells[i].activeSelf != solution[i])
            {
                   isSolved = false;
              //  Debug.Log(cells[i].activeSelf + " not same " + i + " " + solution[i]);
                return false;
               
            }
        }

        isSolved = true;
        manager.PuzzleComplete();
        return true;

    }
    public void PlaySound(bool isErasing)
    {
        if (isErasing)
        {
            Debug.Log("Erasing sound");
            //play erasing sound
            //randomise between the available ones
        }
        else
        {
            Debug.Log("Drawing sound");
            //play scribble sound
            //randomise between the available ones
        }
    }
}
