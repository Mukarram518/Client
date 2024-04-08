using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    int trapsLayer;
    public bool isGameOver;
    public static GameOver Instance;
    public delegate void gameOver();
    public gameOver onGameOver;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //Get the integer representation of the "Traps" layer
        trapsLayer = LayerMask.NameToLayer("Traps");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer != trapsLayer)

            return;

        isGameOver = true;
        onGameOver?.Invoke();
        Debug.Log("Is collided with traps");



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != trapsLayer)

            return;

        isGameOver = true;
        onGameOver?.Invoke();
        Debug.Log("Is collided with traps");
       

    }
    
}
