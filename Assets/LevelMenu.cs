using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] buttons;
   // public GameObject lockImage;

    // Start is called before the first frame update
    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
         //   lockImage.SetActive(false);
        }
        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
           // lockImage.SetActive(true);

        }
    }


    public void OpenLevel(int levelId)
    {
        string levelName = "Level " + levelId;
        SceneManager.LoadScene(levelName);
    }
    public void onBackButtonClicke(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}