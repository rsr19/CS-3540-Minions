using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// A script for the timer functions
/// </summary>
public class TimerScript : MonoBehaviour {
	//the end text to be shown
	public Text endText;
	//the timer gui
	public Text timerText;
	public Button retryButton;
	public Button nextButton;

	public GameObject menuGrp;

	//how long it lasts
	public float timerStart;
	//a variable to hold the decreasing time
	private float timerCount;

	//a variable for how long the reset timer will last
	private float timeRemaining;

	//the amount of lives there are
	public int lives = 3;

	//the hud script
	private HudScript hud;
	GameObject menuObj;
	MenuScript menuScript;

	//The start method
	void Start()
	{
		//have the timer count equal to the timer start
		timerCount = timerStart;

		//set the reset timer
		timeRemaining = 1;

		//get the hud script in order to change the number of icons on the hud
		hud = this.transform.GetComponent<HudScript>();

		//if the hud script was found set the current amount of lives
		if(hud != null)
			hud.SetLives(lives);

		menuObj = GameObject.Find("MenuLogic(Clone)");

		if(menuObj != null)
			menuScript = menuObj.GetComponent<MenuScript>();
	}

	//the update method
	void Update()
	{
		//if the timer count is less than zero reload the level
		if(timerCount < 0)
			//Application.LoadLevel (Application.loadedLevel);
			ShowGameOver();

		//decrement the timer count
		timerCount -= Time.deltaTime;

		//update the text to show the current time left
		timerText.text = timerCount.ToString("F2");
	}

	//a method for when the boss is beaten
	public void ShowEnd()
	{
		//GameObject menuObj = GameObject.Find("MenuLogic(Clone)");

		if(menuScript != null)
		{
			menuScript.SetNextLevelUnlock();
		}

		//show the ending text
		endText.gameObject.SetActive(true);

		//show the next level button
		nextButton.gameObject.SetActive(true);
		retryButton.gameObject.SetActive(false);

		menuGrp.SetActive(true);

		//pause everything
		Time.timeScale = 0;
	}

	public void DecreaseLives()
	{
		//decrement the lives 
		lives--;

		//update the hud
		if(hud != null)
			hud.SetLives(lives);

		//if there are no more lives then end the game
		if(lives <= 0)
		{
			ShowEnd();
		}
			
	}

	//a method to increase the lives
	public void IncreaseLives()
	{
		lives++;

		if (hud != null)
			hud.SetLives (lives);
	}

	//A method to show the game over menu
	public void ShowGameOver()
	{
		endText.text = "Game Over";

		//show the retry button
		nextButton.gameObject.SetActive(false);
		retryButton.gameObject.SetActive(true);

		menuGrp.SetActive(true);

		Time.timeScale = 0;
	}

	//replay the current level
	public void RetryClick()
	{
		Time.timeScale = 1;
		Application.LoadLevel (Application.loadedLevel);
	}

	//go back to the menu
	public void QuitClick()
	{
		Time.timeScale = 1;
		Application.LoadLevel ("MainMenu");
	}

	//go to the next level
	public void NextLevelClick()
	{
		if(menuScript != null )
		{

			menuScript.GoToNextLevel();
		}
	}
}
