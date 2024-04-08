using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PragmaTechs.ScriptableObjects.Core;

public class ManagerLevelLock : MonoBehaviour
{
    public Button BtnLevel;
    public GameObject ImgLock;
    public GameObject GoNumber;
    public IntVariable maxUnlockedLevel;
    public IntVariable currentLevel;

    private const string LEVEL_UNLOCKED = "LEVELS_UNLOCKED";

    private int levelsUnlocked = 1;
    public void Start()
    {
        //PlayerPrefs.SetInt(LEVEL_UNLOCKED, 1);
        levelsUnlocked = PlayerPrefs.GetInt(LEVEL_UNLOCKED, 1);

        maxUnlockedLevel.Value = levelsUnlocked;
        if (int.Parse(gameObject.name) <= maxUnlockedLevel.Value)
        {
            GoNumber.SetActive(true);
            ImgLock.SetActive(false);
            BtnLevel.interactable = true;
        }
        else
        {
            GoNumber.SetActive(true);
            ImgLock.SetActive(true);
            BtnLevel.interactable = false;
        }
    }

    public void LoadLevel()
    {
        currentLevel.Value = int.Parse(GoNumber.name);
        SceneManager.LoadScene("Loding scane");
    }
}