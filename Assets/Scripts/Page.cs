using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Audio;

public class Page : MonoBehaviour
{
    // Start is called before the first frame update
    private int pageNumber;
    private PageManager pageManager;
    [SerializeField] private bool isSolved;
    [SerializeField] private bool canTurnNextPage;
    [SerializeField] private GameObject journal;
    [SerializeField] private GameObject turnNextPage;
    [SerializeField] private GameObject transitioning;

    [SerializeField] private GameObject puzzle;
    [SerializeField] private GameObject interactivePuzzle;
    [SerializeField] private GameObject answer;
    [SerializeField] private GameObject fuzziness;
    [SerializeField] private AudioClip accomplishClip;
    [SerializeField] List<GameObject> externalObjects;
    private SFXManager sfxManager;
    [SerializeField] private bool isLastPage;
    void Start()
    {
        pageNumber = transform.GetSiblingIndex();
        pageManager = PageManager.instance;
        sfxManager = SFXManager.instance;
        

    }

    public void TurnNextPage()
    {
        if (isSolved || canTurnNextPage)
        {
            if (isLastPage) {
                if(AmbientManager.instance)
                    AmbientManager.instance.playThunder(); }
            pageManager.ActivatePage(pageNumber + 1);
            //pageManager.DeactivatePage(pageNumber);
            Deactivate();
        }
    }
    public void TurnPreviousPage()
    {
        pageManager.ActivatePage(pageNumber - 1);
        //pageManager.DeactivatePage(pageNumber);
        Deactivate();
    }

    public void IsSolved()
    {
        if (isSolved)
        {
            puzzle.SetActive(false);
            journal.SetActive(true);
            turnNextPage.SetActive(true);
            SetActivityOfExternalItems(false);
            answer.SetActive(false);
            fuzziness.SetActive(false);

        }
        else
        {
            puzzle.SetActive(true);
            journal.SetActive(false);
            fuzziness.SetActive(true);
            answer.SetActive(false);
            turnNextPage.SetActive(canTurnNextPage);
            SetActivityOfExternalItems(true);
        }

    }

    public void SetSolved(bool isSolved)
    {
        this.isSolved = isSolved;

        if (isSolved && !canTurnNextPage)
        {
            interactivePuzzle.SetActive(false);
            TransitionToJournal();
        }

    }
   

    public void Deactivate()
    {
        SetActivityOfExternalItems(false);
        gameObject.SetActive(false);
    }
    public void Activate()
    {
        if (canTurnNextPage && isSolved)
        {
           
            if (pageManager.CurrentPage() > pageNumber)
            {
                TurnPreviousPage();
            }
            else
                TurnNextPage();
        }
        else
        {

            IsSolved();
            gameObject.SetActive(true);
        }
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

    public void TransitionToJournal()
    {

        SetActivityOfExternalItems(false);
        answer.SetActive(true);
       // sfxManager.PlaySoundClipLowVol(accomplishClip, 0.09f);
        StartCoroutine(LoadJournal(3f));


    }
    IEnumerator LoadJournal(float duration)
    {
        StartCoroutine(FadeInOut(fuzziness, false, 2f));
        yield return new WaitForSeconds(4f);
        //MusicManager.instance.StopSoundClip();
        if(MusicManager.instance)
            MusicManager.instance.LowerSoundClipAt(10f, 0.1f);
       
        fuzziness.SetActive(false);
        StartCoroutine(FadeInOut(transitioning, true, 2f));
        yield return new WaitForSeconds(duration);
        answer.SetActive(false);
        puzzle.SetActive(false);
        journal.SetActive(true);
        turnNextPage.SetActive(true);

        StartCoroutine(FadeInOut(transitioning, false, 2f));

        yield return new WaitForSeconds(2f);
        transitioning.SetActive(false);

    }
    IEnumerator FadeInOut(GameObject obj, bool fadeIn, float duration)
    {

        float timer = 0;
        float fadeFrom;
        float fadeTo;
        if (fadeIn)
        {

            fadeFrom = 0f;
            fadeTo = 1f;
        }
        else
        {
            fadeFrom = 1f;
            fadeTo = 0f;
        }

        SpriteRenderer spr = obj.GetComponent<SpriteRenderer>();
        TMP_Text text = obj.GetComponent<TMP_Text>();
        if (spr != null)
        {
            Color currentColor = spr.color;
            while (timer < duration)
            {
                timer += Time.deltaTime;
                float alpha = Mathf.Lerp(fadeFrom, fadeTo, timer / duration);
                spr.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
                yield return null;
            }


        }
        else if (text != null)
        {
            Color currentColor = text.color;
            while (timer < duration)
            {
                timer += Time.deltaTime;
                float alpha = Mathf.Lerp(fadeFrom, fadeTo, timer / duration);
                text.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
                yield return null;
            }
        }
        else
        {
            yield break;
        }





    }
}
