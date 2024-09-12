using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenItem : MonoBehaviour
{
    [SerializeField] private KitchenManager manager;

    [SerializeField] private int correctPosition;
    [SerializeField] private List<Transform> possiblePositions;
    [SerializeField] private Transform referenceUp;
    [SerializeField] private Transform referenceDown;
    private bool isCorrectPosition;
    public bool IsCorrectPosition => isCorrectPosition;
    private bool isComplete;
    public bool IsComplete => isComplete;
    public int id;
    // [SerializeField] private List<>
    // Start is called before the first frame update
    private float dy;
    void Start()
    {
        id = transform.GetSiblingIndex();
        if (referenceDown && referenceUp)
        {
            if (correctPosition > 2)
                dy = possiblePositions[correctPosition].position.y - referenceDown.position.y;
            else
                dy = possiblePositions[correctPosition].position.y - referenceUp.position.y;
        }
        else
        {
            dy = possiblePositions[correctPosition].position.y;
        }

    }


    public void IsInPosition()
    {


        for (int i = 0; i < possiblePositions.Count; i++)
        {
            float distance = (transform.position - possiblePositions[i].position).magnitude;
            if (distance <= 0.4f)
            {
                Vector3 newPos = new Vector3(0f, 0f, 0f);
                if (referenceUp && referenceDown)
                {
                    if (i > 2)
                        newPos = new Vector3(possiblePositions[i].position.x, referenceDown.position.y + dy, 0f);
                    else
                        newPos = new Vector3(possiblePositions[i].position.x, referenceUp.position.y + dy, 0f);
                   
                }
                else
                {
                    newPos = new Vector3(possiblePositions[i].position.x, dy, 0f);
                }
                
                
                transform.position = newPos;//possiblePositions[i].position;
                if (i == correctPosition)
                {
                    isCorrectPosition = true;
                    //Debug.Log("Correct pos" + gameObject.name + " " + isCorrectPosition);
                    manager.PuzzleComplete();

                    isComplete = manager.IsComplete;
                }
                else
                {

                    isCorrectPosition = false;
                }
                return;





            }
            else
            {

                isCorrectPosition = false;
            }

        }
       

    }
}
