using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnAwake : MonoBehaviour
{
    public UnityEvent onAwakeEvent;
    private void Awake()
    {
        onAwakeEvent?.Invoke();
    }
}
