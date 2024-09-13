using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ReadInput : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string correctInput;
    private Page page;
   private SFXManager sfxManager;
    [SerializeField] private List<AudioClip> scribbles = new List<AudioClip>();
  

    private void Start()
    {
        page = GetComponent<Page>();
        sfxManager = SFXManager.instance;
    }
    public void PlaySound()
    {
       
        int i = Random.Range(0, scribbles.Count);
        AudioClip clip = scribbles[i];
        sfxManager.PlaySoundClip(clip);
    }
    public void GetInput(string input)
    {

        if (input.ToLower() == correctInput)
        {
            Debug.Log("Correct");
            page.SetSolved(true);
        }
    }
   
}
