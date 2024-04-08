using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnOnDeath : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private bool isFlickedEnable = false;
    //public GameObject deathVFXPrefab;
    public int numberOfDeaths;
    //public static Vector2 respawnPoint;
    public static Vector2 lastChekPointPos;
    PlayerDieEffect playerDieEffect;
    public GameObject player;
    public GameObject deathVFXPrefab;
    public GameObject playerPrefab;

    private PlayerMovement playerMovement;  
    // Start is called before the first frame update
    void Start()
    {
        GameOver.Instance.onGameOver += onGameOverReceived;
        playerDieEffect = player.GetComponent<PlayerDieEffect>();
        GameObject.FindGameObjectsWithTag("Player");
        spriteRenderer = player.GetComponent<SpriteRenderer>();

        playerMovement = player.GetComponent<PlayerMovement>();

        if (playerMovement == null)
        {
            Debug.LogError("PlayerMovement script not found on the player object.");
        }
    }
    public void onGameOverReceived()
    {

        numberOfDeaths++;
        UIManager.UpdateDeathUI(numberOfDeaths);
        if (numberOfDeaths <= 3)
        {
            isFlickedEnable = true;
            playerDieEffect.PlayerDie();
            player.SetActive(false);

            Debug.Log("Life Save");
            StartCoroutine(forWait());
        }
        else
        {
            GameManager.PlayerDied();
        }

    }



    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator forWait()
    {
        player.transform.position = lastChekPointPos;

        yield return new WaitForSeconds(0.1f);

        // Deactivate player
        player.SetActive(false);

        // Reset player's position to the last checkpoint
      

        // Ensure the player's Rigidbody velocity is reset
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;

        // Reset player's posture to initial rotation
        if (playerMovement != null)
        {
            player.transform.rotation = playerMovement.InitialRotation;
        }
        else
        {
            Debug.LogError("PlayerMovement script reference is null.");
        }

        // Reactivate player
        player.SetActive(true);

        // Start flicker routine or any other logic
       // StartCoroutine(colorFlickerRoutine());

        Debug.Log("0.1-second wait function working");


    }

}