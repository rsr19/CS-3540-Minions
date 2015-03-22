﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

	//have an image for the fading effect
	public Image blackFade;

	private Animator anim;

	public string LevelName{get;set;}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(blackFade.gameObject.activeSelf);
	}

	public void PlayAnim(string _animName)
	{
		anim.Play(_animName);
	}

	//a function that starts the fading effect
	/*public void StartLoadScene(string _sceneName)
	{

		StartCoroutine(LoadScene(_sceneName));
	}*/

	//a coroutine for the fading effect
	private IEnumerator LoadScene()
	{
		//if the blackFade object has been set
		if(blackFade != null)
		{
			Debug.Log(blackFade.gameObject.activeSelf);
			//enable the blackFade and it's image just in case the arn't enabled
			blackFade.gameObject.SetActive(true);
			blackFade.enabled = true;
			
			//a variable for the lerp
			float trans = 0;
			//get the color of the blackFade
			Color fadeColor = blackFade.color;
			//make sure that the alpha of the color is 
			fadeColor.a = 0;

			//while trans is less than 1
			while(trans < 1)
			{
				blackFade.gameObject.SetActive(true);
				blackFade.enabled = true;

				//add the delta time to the incrementing variable
				trans += Time.deltaTime;

				//add the lerped number to the alpha 
				fadeColor.a = Mathf.Lerp(0, 1, trans);

				//add the new color to the blackFade color
				blackFade.color = fadeColor;

				yield return null;
			}
			//once the blackFade is done transitioning load the specified level
			Application.LoadLevel(LevelName);

			yield return null;
		}
	}
}
