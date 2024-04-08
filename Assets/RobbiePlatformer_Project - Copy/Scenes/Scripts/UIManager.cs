// This script is a Manager that controls the UI HUD (deaths, time, and orbs) for the 
// project. All HUD UI commands are issued through the static methods of this class

using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	//This class holds a static reference to itself to ensure that there will only be
	//one in existence. This is often referred to as a "singleton" design pattern. Other
	//scripts access this one through its public static methods
	static UIManager current;
	[Header("[Ontimeup result]")]
	public TextMeshProUGUI timeuptorbText;
	public TextMeshProUGUI timeuptcoinText;
	public TextMeshProUGUI timeupdeathText;
	[Header("[OnTraps result]")]
	public TextMeshProUGUI OnTrapsorbText;
	public TextMeshProUGUI OnTrapscoinText;
	public TextMeshProUGUI OnTrapsdeathText;
	[Header("[After win result]")]
	public TextMeshProUGUI winorbText;
	public TextMeshProUGUI wincoinText;
	public TextMeshProUGUI windeathText;

	public TextMeshProUGUI orbText;			//Text element showing number of orbs
	public TextMeshProUGUI timeText;		//Text element showing amount of time
	public TextMeshProUGUI deathText;		//Text element showing number or deaths
	public TextMeshProUGUI gameOverText;    //Text element showing the Game Over message
	public TextMeshProUGUI coinText;
	public GameObject pauseDasboard;
	public GameObject onTraps;
	public GameObject ontimeUp;
	public GameObject onWinning;
	 public float  leveltime = 30f;
	public int coins;


    private void Start()
    {
		GameManager.SetCoinLimit(coins);
	}

    void Awake()
	{
		//If an UIManager exists and it is not this...
		if (current != null && current != this)
		{
			//...destroy this and exit. There can be only one UIManager
			Destroy(gameObject);
			return;
		}

		//This is the current UIManager and it should persist between scene loads
		current = this;
		//DontDestroyOnLoad(gameObject);
	}

	public static void UpdateOrbUI(int orbCount)
	{
		//If there is no current UIManager, exit
		if (current == null)
			return;

		//Update the text orb element
		current.orbText.text = orbCount.ToString();
		current.timeuptorbText.text = orbCount.ToString();
		current.OnTrapsorbText.text = orbCount.ToString();
		current.OnTrapsorbText.text = orbCount.ToString();

	}

	public static void UpdateTimeUI(float time)
	{
		//If there is no current UIManager, exit
		if (current == null)
			return;

		//Take the time and convert it into the number of minutes and seconds
		int minutes = (int)(time / 60);
		float seconds = time % 60f;

		//Create the string in the appropriate format for the time
		current.timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
		if (time >= current.leveltime)
		{
			GameManager.timeupDied();
		}

	}

	public static void UpdateDeathUI(int deathCount)
	{
		//If there is no current UIManager, exit
		if (current == null)
			return;

		//update the player death count element
		current.deathText.text = deathCount.ToString();
		current.timeupdeathText.text = deathCount.ToString();
		current.OnTrapsdeathText.text = deathCount.ToString();
		current.windeathText.text = deathCount.ToString();
	}

	public static void DisplayGameOverText()
	{
		//If there is no current UIManager, exit
		if (current == null)
			return;

		//Show the game over text
		current.gameOverText.enabled = true;
	}
	public static void UpdatCoinUI(int coinCount)
	{
		//If there is no current UIManager, exit
		if (current == null)
			return;

		//Update the text orb element
		current.coinText.text = coinCount.ToString();
		current.timeuptcoinText.text = coinCount.ToString();
		current.wincoinText.text = coinCount.ToString();
		current.OnTrapscoinText.text = coinCount.ToString();

	}
	public static void showhomeReBut()
    {
		current.pauseDasboard.gameObject.SetActive(true);
		Time.timeScale = 0;
	}
	public static void onTrapsBoard()
	{
		current.onTraps.gameObject.SetActive(true);
	}
	public static void onWinBoard()
	{
		current.onWinning.gameObject.SetActive(true);
	}
	public static void ontimeBoard()
	{
		current.ontimeUp.gameObject.SetActive(true);
	}
}
