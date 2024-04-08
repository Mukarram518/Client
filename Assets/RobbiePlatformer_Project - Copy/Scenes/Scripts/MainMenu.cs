using PragmaTechs.ScriptableObjects.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class MainMenu : MonoBehaviour
{
    public static int nextLavel = GameManager.lavelUnlocker;
    public IntVariable _maximumUnlockedLevel;
    public int maxLevelUnlockedData = 1 + nextLavel ;



    private void OnEnable()
    {
      // maxLevelUnlockedData = PlayerPrefs.GetInt(PlayerPrefsData.MAX_LEVEL_UNLOCKED, 1);
        _maximumUnlockedLevel.Value = maxLevelUnlockedData;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(_maximumUnlockedLevel.Value);
        
    }
    public void LoadMainMenu()
    {
    
        SceneManager.LoadScene(0);
    }
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Quiting");
         
    }
    public void LevelManue()
    {
        SceneManager.LoadScene("LevelSelection");
    }
    public void LoadingscaneFirst()
    {

        SceneManager.LoadScene(12);
    }
}



