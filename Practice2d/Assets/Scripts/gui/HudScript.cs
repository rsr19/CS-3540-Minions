using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudScript : MonoBehaviour 
{
	//have an array of images for the lives icons
	public Image[] lives;

	//have an image for the fading effect
	public Image blackFade;

	public Text countDownTxt;

	//the speed of the fading
	private float fadeSpeed = 1.5f;

	private float lastTimeSinceStartup;
	private float myTime;

	// Use this for initialization
	void Start () {
		//start the fading out
		StartCoroutine("LoadScene");

		Canvas canvas = GetComponent<Canvas>();
		canvas.worldCamera = Camera.main;

		lastTimeSinceStartup = 0;
		countDownTxt.enabled = false;
		Time.timeScale = 0;


	}
	
	// Update is called once per frame
	void Update () {
		myTime = Time.realtimeSinceStartup - lastTimeSinceStartup;

		lastTimeSinceStartup = Time.realtimeSinceStartup;
	}

	//a function to change the amount of icons for the lives
	public void SetLives(int _amt)
	{
		//turn all of the icons off
		foreach(Image _img in lives)
			_img.enabled = false;

		//loop through the array of icons and turn them on for the amount of lives there are
		if(_amt < lives.Length + 1 && _amt >= 0)
		{
			for(int i = 0; i < _amt; i++)
			{
				lives[i].enabled = true;
			}
		}
	}

	//a coroutine for fading out a black image
	private IEnumerator LoadScene()
	{
		//if the blackFade object has been set
		if(blackFade != null)
		{
			//enable the blackFade and it's image just in case the arn't enabled
			blackFade.transform.gameObject.SetActive(true);
			blackFade.enabled = true;

			//a variable for the lerp
			float trans = 0;
			//get the color of the blackFade
			Color fadeColor = blackFade.color;
			//make sure that the alpha of the color is 1
			fadeColor.a = 1;

			//while trans is less than 1
			while(trans < 1)
			{
				//add the delta time to the incrementing variable
				trans += fadeSpeed * myTime;

				//add the lerped number to the alpha 
				fadeColor.a = Mathf.Lerp(1, 0, trans);

				//add the new color to the blackFade color
				blackFade.color = fadeColor;
				
				yield return null;
			}

		}

		countDownTxt.enabled = true;
		countDownTxt.text = "4";

		float countDown = 4;

		//start countdown
		while(countDown > 0)
		{
			countDown -= myTime;

			if(countDown < 1)
				countDownTxt.text = "Start!";
			else
			{

				countDownTxt.text = ((int)countDown).ToString();
			}

			yield return null;
		}

		countDownTxt.enabled = false;
		Time.timeScale = 1;

		yield return null;
	}
	
}
