// This script is a Manager that controls the the flow and control of the game. It keeps
// track of player data (orb count, death count, total game time) and interfaces with
// the UI Manager. All game commands are issued through the static methods of this class

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	//This class holds a static reference to itself to ensure that there will only be
	//one in existence. This is often referred to as a "singleton" design pattern. Other
	//scripts access this one through its public static methods
	public static GameManager current;
	public static int numberOfCoins;
	//public static Vector2 lastChekPointPos = ; //new Vector2(-33, -9);



	public float deathSequenceDuration = 0.3f;  //How long player death takes before restarting
	List<Orb> orbs;                             //The collection of scene orbs
	Door lockedDoor;                            //The scene door
	SceneFader sceneFader;                      //The scene fader
	public static int numberOfDeaths;
	public static int lavelUnlocker = 0;
	float totalGameTime;                        //Length of the total game time
	bool isGameOver;                            //Is the game currently over?
	

    private void Start()
    {
		GetComponent<PlayerDieEffect>();
    }
    void Awake()

	{
		//If a Game Manager exists and this isn't it...
		//if (current != null && current != this)
		//{
		//...destroy this and exit. There can only be one Game Manager
		//Destroy(gameObject);
		//return;
		//}

		//Set this as the current game manager
		current = this;

		//Create out collection to hold the orbs
		orbs = new List<Orb>();
		//Persis this object between scene reloads
		//DontDestroyOnLoad(gameObject);
	}

	void Update()

	{


		//If the game is over, exit
		if (isGameOver)
			return;

		//Update the total game time and tell the UI Manager to update
		totalGameTime += Time.deltaTime;
		UIManager.UpdateTimeUI(totalGameTime);
		UIManager.UpdatCoinUI(numberOfCoins);

	}

	public static bool IsGameOver()
	{
		//If there is no current Game Manager, return false
		if (current == null)
			return false;

		//Return the state of the game
		return current.isGameOver;
	}

	public static void RegisterSceneFader(SceneFader fader)
	{

		//If there is no current Game Manager, exit
		if (current == null)
			return;

		//Record the scene fader reference
		current.sceneFader = fader;

	}

	public static void RegisterDoor(Door door)
	{
		//If there is no current Game Manager, exit
		if (current == null)
			return;

		//Record the door reference
		current.lockedDoor = door;
	}

	public static void RegisterOrb(Orb orb)
	{
		//If there is no current Game Manager, exit
		if (current == null)
			return;

		//If the orb collection doesn't already contain this orb, add it
		if (!current.orbs.Contains(orb))
			current.orbs.Add(orb);

		//Tell the UIManager to update the orb text
		UIManager.UpdateOrbUI(current.orbs.Count);
	}

	

	public static void PlayerGrabbedOrb(Orb orb)
	{
		//If there is no current Game Manager, exit
		if (current == null)
			return;
		//If the orbs collection doesn't have this orb, exit
		if (!current.orbs.Contains(orb))
			return;
		//Remove the collected orb
		current.orbs.Remove(orb);
		//If there are no more orbs, tell the door to open
		numberOfCoins++;
		//If there are no more orbs, tell the door to open
		if (current.orbs.Count == 0 && numberOfCoins <= 0)
		{
			current.lockedDoor.Open();
		}
		//Tell the UIManager to update the orb text
		UIManager.UpdateOrbUI(current.orbs.Count);
		UIManager.UpdatCoinUI(numberOfCoins);
	}
	public static void SetCoinLimit(int newLimit)
	{
		numberOfCoins = newLimit;
	}
	public static void PlayerDied()
	{

		//If there is no current Game Manager, exit
		if (current == null)
			return;

		//Increment the number of player deaths and tell the UIManager
		UIManager.UpdateDeathUI(numberOfDeaths);
		//If we have a scene fader, tell it to fade the scene out	
		UIManager.onTrapsBoard();
		Time.timeScale = 0;
		//GoogleAdMobController.admobManager.ShowInterstitialAd();

	}

	public static void PlayerWon()
	{
		//If there is no current Game Manager, exit
		if (current == null)
			return;

		//The game is now over
		current.isGameOver = true;

		//Tell UI Manager to show the game over text and tell the Audio Manager to play
		//game over audio
		UIManager.DisplayGameOverText();
		AudioManager.PlayWonAudio();
		UIManager.onWinBoard();
	}


	public void RestartScene()
	{
		RestartButton();
		//Clear the current list of orbs
		orbs.Clear();
		//Play the scene restart audio
		AudioManager.PlaySceneRestartAudio();
		//Reload the current scene
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		AudioManager.soundOn();
		Debug.Log("Game Restarted");

	}

	public void RestartButton()
	{

		Time.timeScale = 1;
		if (current.sceneFader != null)
		{

			current.sceneFader.FadeSceneOut();
		}
		//Invoke the RestartScene() method after a delay
		current.Invoke("RestartScene", current.deathSequenceDuration);
		AudioManager.soundOn();
	}
	public void LevelManue()
	{
		//GoogleAdMobController.admobManager.ShowInterstitialAd();
		SceneManager.LoadScene(11);
	}
	public void Homescreen()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(0);
		AudioManager.soundOn();
	}
	public void pauseButten()
	{
        //GoogleAdMobController.admobManager.ShowInterstitialAd();
		
        AudioManager.soundOf();
		Time.timeScale = 0;

	}
	public void ResumeGame()
	{

		AudioManager.soundOn();
		Time.timeScale = 1;
	}
	public static void timeupDied()
	{
		//If there is no current Game Manager, exit
		if (current == null)
			return;


		UIManager.UpdateDeathUI(numberOfDeaths);
		UIManager.ontimeBoard();
		Time.timeScale = 0;
	}
	public void soundOnbutton()
	{
		AudioManager.soundOn();
	}
	public void soundOffbtton()
	{
		AudioManager.soundOf();
	}
	public void OnButtonClickSound()
	{
		AudioManager.OnButtonClickAudio();
	}
	public void respawnPos()
    {

    }
}
