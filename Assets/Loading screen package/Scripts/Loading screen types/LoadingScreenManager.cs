using PragmaTechs.ScriptableObjects.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreenManager : MonoBehaviour
{
    private Animator _animatorComponent;
    public IntVariable curerentLevel;
     void Start()
    {
        _animatorComponent = transform.GetComponent<Animator>();  

        // Remove it if you don't want to hide it in the Start function and call it elsewhere
        HideLoadingScreen();
        Time.timeScale = 1;
    }

    public void RevealLoadingScreen()
    {
        _animatorComponent.SetTrigger("Reveal");
    }

    public void HideLoadingScreen()
    {
        // Call this function, if you want start hiding the loading screen
        _animatorComponent.SetTrigger("Hide");
    }

    public void OnFinishedReveal()
    {
        // TODO: remove it and load your own scene !!
         transform.parent.GetComponent<DemoSceneManager>().OnLoadingScreenRevealed();
    }

    public void OnFinishedHide()
    {
        // TODO: remove it and call your functions 
        //transform.parent.GetComponent<DemoSceneManager>().OnLoadingScreenHided();
        SceneManager.LoadScene(curerentLevel.Value);
    }
    
    

}
