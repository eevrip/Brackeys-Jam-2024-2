using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SudokuCell : MonoBehaviour
{

   // private bool isOccupied;
    public int occupiedBy;
    [SerializeField] private string type;
    void Start()
    {
        occupiedBy = -1;

    }

    public void SetOccupied(int id)
    {
        occupiedBy = id;
       // isOccupied = true;
    }
    public bool GetOccupied() { 
        //return isOccupied; 
        return occupiedBy >= 0;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision)
        {
            SudokuTile obj = collision.gameObject.GetComponent<SudokuTile>();
            if (obj)
                if (obj.id == occupiedBy)
                {
                    occupiedBy = -1;
                    //isOccupied = false;
                }
        }
    }
}
