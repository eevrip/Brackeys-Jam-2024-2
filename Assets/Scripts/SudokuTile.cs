using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SudokuTile : MonoBehaviour
{
    [SerializeField] private SudokuManager manager;
    // [SerializeField] private List<Transform> correctPositions;
    [SerializeField] private List<SudokuCell> correctPositions;
    private bool isCorrectPosition;
    public bool IsCorrectPosition => isCorrectPosition;
    private bool isComplete;
    public bool IsComplete => isComplete;
    public int id;
    // [SerializeField] private List<>
    // Start is called before the first frame update
    void Start()
    {
        id = transform.GetSiblingIndex();
    }

    
    public void IsInPosition()
    {
        for (int i = 0; i < correctPositions.Count; i++)
        {


            float distance = (transform.position - correctPositions[i].transform.position).magnitude;
            if (distance <= 0.4f)
            {
                if (!correctPositions[i].GetOccupied() || correctPositions[i].occupiedBy == id)
                {
                    //Debug.Log("Is not occupied " + correctPositions[i]);
                   
                    correctPositions[i].SetOccupied(id);
                    isCorrectPosition = true; 
                    //Debug.Log("Correct pos" + gameObject.name + " " + isCorrectPosition);
                    manager.PuzzleComplete();

                    isComplete = manager.IsComplete;
                    return;
                }



                //transform.position = correctPositions[i].position;
            }
            else
            {

                isCorrectPosition = false;
            }

        }
    }
}
