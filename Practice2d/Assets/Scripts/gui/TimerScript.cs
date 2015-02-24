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

	//how long it lasts
	public float timerStart;
	//a variable to hold the decreasing time
	private float timerCount;

	//a variable for how long the reset timer will last
	private float timeRemaining;


	//The start method
	void Start()
	{
		//have the timer count equal to the timer start
		timerCount = timerStart;

		//set the reset timer
		timeRemaining = 25;
		
	}

	//the update method
	void Update()
	{
		//if the timer count is less than zero reload the level
		if(timerCount < 0)
			//Application.LoadLevel (Application.loadedLevel);
			ShowEnd();

		//decrement the timer count
		timerCount -= Time.deltaTime;

		//update the text to show the current time left
		timerText.text = timerCount.ToString("F0");
	}

	//a method for when the boss is beaten
	public void ShowEnd()
	{
		//show the ending text
		endText.gameObject.SetActive(true);
		//start the countdown timer
		StartCoroutine("EndPause");
	}

	//a coroutine for the remaining time before the level reloads
	private IEnumerator EndPause()
	{
		
		while(true)
		{
			//decrease the reset timer 
			timeRemaining -= Time.deltaTime;

			//when it reaches below zero reset the level
			if(timeRemaining < 0)
				Application.LoadLevel (Application.loadedLevel);

			yield return new WaitForSeconds(Time.deltaTime);
		}
	}
}
