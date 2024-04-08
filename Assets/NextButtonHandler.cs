//using Mono.Cecil.Cil;
using PragmaTechs.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButtonHandler : MonoBehaviour
{
   
    public GameEvent OnClickNextButton;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnNextButton()
    {
        OnClickNextButton.Raise();
    }
   
}
