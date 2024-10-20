using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    #region Singleton
    public static MenuManager instance;
  
    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    #endregion 
    public static bool isGamePaused = false;
    public Animator transitionLevel;
    
    public Animator transitionPauseMenu;
    // Start is called before the first frame update
    public void PlayGame()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // StartCoroutine(LoadingLevel(SceneManager.GetActiveScene().buildIndex+1));
        StartCoroutine(LoadingLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void ContinueGame()
    { //Time.timeScale = 1f;
        if (transitionPauseMenu)
            transitionPauseMenu.SetTrigger("continue");
        Debug.Log("continue");
       
        isGamePaused = false;
    }
    public void PauseGame()
    {
        if (transitionPauseMenu)
        {
            transitionPauseMenu.SetTrigger("pause");
            Debug.Log("pause");
            StartCoroutine(LoadPauseMenu());
        }
       
    }
    
    public void MainMenu()
    {
        // ContinueGame();
        // SceneManager.LoadScene(0);
        isGamePaused = false;
        StartCoroutine(LoadingLevel(0));
    }
    public void Credits()
    {
        
        
        StartCoroutine(LoadingLevel(2));
    }
    IEnumerator LoadPauseMenu()
    {
        yield return new WaitForSeconds(1f); 
        //Time.timeScale = 0f;
        isGamePaused = true;
    }
    IEnumerator LoadingLevel(int levelIndx)
    {
       
       
        if(transitionLevel)
            transitionLevel.SetTrigger("LoadNext");
       if(levelIndx == 1)
        {
            if(AmbientManager.instance)
                AmbientManager.instance.SetVolumeRain(0.34f);
        }
        yield return new WaitForSeconds(3f);
        
        SceneManager.LoadScene(levelIndx);
    }
    


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isGamePaused)
            {

                PauseGame();
            }
            else
            {

                ContinueGame();
            }
        }
    }

}
