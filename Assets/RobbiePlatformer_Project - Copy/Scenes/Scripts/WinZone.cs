// This script is responsible for detecting collision with the player and letting the 
// Game Manager know

using PragmaTechs.ScriptableObjects.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinZone : MonoBehaviour
{
	int playerLayer;    
	void Start()
	{
		playerLayer = LayerMask.NameToLayer("Player");
		
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer != playerLayer)
			return;

		//Write "Player Won" to the console and tell the Game Manager that the player
	//	GoogleAdMobController.admobManager.ShowInterstitialAd();
		Debug.Log("Player Won!");
		unlockNewLevel();

        GameManager.PlayerWon();
		
	}
    void unlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();

        }
    }
}
