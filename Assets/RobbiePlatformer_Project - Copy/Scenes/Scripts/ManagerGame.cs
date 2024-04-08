using UnityEngine;
using UnityEngine.SceneManagement;
using PragmaTechs.ScriptableObjects.Core;

public class ManagerGame : MonoBehaviour
{
    public int Level = 0;
    public string Map = "";
    public IntVariable maxUnLockedLevel;

   // public BoolVariable canShootBall;


    //public Animator anim;

    public void Awake()
    {
        
    }

    public void Start()
    {
       // canShootBall.Value = false;
        Map = SceneManager.GetActiveScene().name;
        Level = SceneManager.GetActiveScene().buildIndex;
    }


    public void Update()
    {
       // anim.SetFloat("Green", 2);
        MaxLevel();
        KeyBoard();
    }

    private void MaxLevel()
    {
        if (maxUnLockedLevel.Value < Level && Map != "Map")
        {
            maxUnLockedLevel.Value = Level;
        }
    }

    public void KeyBoard()
    {
        if (Input.GetKey(KeyCode.Home))
        {
            Home();
        }
        if (Input.GetKey(KeyCode.Backspace))
        {
            Restart();
        }
        if (Input.GetKey(KeyCode.End))
        {
            Quit();
        }
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }

    public void LevelsMap()
    {
        SceneManager.LoadScene("Map");
    }

    public void Play()
    {
        SceneManager.LoadScene(maxUnLockedLevel.Value);
    }

    public void Level01()
    {
        SceneManager.LoadScene(3);
    }

    public void Next()
    {
        SceneManager.LoadScene(Level + 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(Level);
    }

    public void Rate()
    {
        // PlayStore Account Openning Code
    }

    public void Share()
    {
        // PlayStore Account Share Code
    }

    public void Quit()
    {
        Application.Quit();
    }
}