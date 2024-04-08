using PragmaTechs.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonHandler : MonoBehaviour
{
    public GameEvent OnClickPauseButton;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnPauseButton()
    {

        OnClickPauseButton.Raise();


    }
   
}
