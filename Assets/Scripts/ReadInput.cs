using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadInput : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string correctInput;
    int i = 0;

    public void PlaySound()
    {
        Debug.Log("Type " + i);
        i++;
    }
    public void GetInput(string input)
    {

        if (input == correctInput)
            Debug.Log("Correct Input");
    }
}
