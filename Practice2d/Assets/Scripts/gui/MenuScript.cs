using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {
	public delegate void TestDel();
	public TestDel del;

	//have an image for the fading effect
	public Image blackFade;

	private Animator anim;
	
	private Button[] levelButtons;
	private bool[] isUnlocked;
	public string[] levelNames;

	//private int currentLevel;
	public int CurrentLevel{get;set;}

	public enum MenuSelect {Main, Level, Options};
	public MenuSelect selectedMenu;

	public static MenuScript Instance{get;set;}

	// Use this for initialization
	void Start () {
		Instance = this;
		DontDestroyOnLoad(transform.gameObject);
		anim = GetComponent<Animator>();
		CurrentLevel = 0;

		levelButtons = MenuStart.Instance.buttons;

		isUnlocked = new bool[levelButtons.Length];
		for(int i = 0; i < isUnlocked.Length; i++)
			isUnlocked[i] = false;
		
		isUnlocked[0] = true;
		
		selectedMenu = MenuSelect.Main;
		
		SetButtons();

		GameObject fadeObject = GameObject.Find("BlackFade");
		
		if(fadeObject != null)
		{
			//Debug.Log("its not null");
			blackFade = fadeObject.GetComponent<Image>();
		}
	}

	//a method to play animations
	public void PlayAnim(string _animName)
	{
		anim.Play(_animName);
	}
	
	void OnLevelWasLoaded()
	{
		if(Application.loadedLevelName == "MainMenu")
		{

			//get the fade object
			GameObject fadeObject = GameObject.Find("BlackFade");

			if(fadeObject != null)
			{
				//Debug.Log("its not null");
				blackFade = fadeObject.GetComponent<Image>();
			}

			levelButtons = MenuStart.Instance.buttons; 

			//enable the levels that the player can play
			SetButtons();
		}
	}

	public void StartLoadLevel(int _levelIndex)
	{

		CurrentLevel = _levelIndex;

		StartCoroutine("LoadScene");
	}

	//a coroutine for the fading effect
	private IEnumerator LoadScene()
	{
		Debug.Log("it works");
		//if the blackFade object has been set
		if(blackFade != null)
		{

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

				//add the delta time to the incrementing variable
				trans += Time.deltaTime;

				//add the lerped number to the alpha 
				fadeColor.a = Mathf.Lerp(0, 1, trans);

				//add the new color to the blackFade color
				blackFade.color = fadeColor;

				yield return null;
			}

			//once the blackFade is done transitioning load the specified level
			Application.LoadLevel(levelNames[CurrentLevel]);

			yield return null;
		}
	}

	//a method to enable level buttons
	private void SetButtons()
	{
		for(int i = 0; i < levelButtons.Length; i++)
		{
			levelButtons[i].interactable = isUnlocked[i];
		}
	}

	//a method to unlock the next level
	public void SetNextLevelUnlock()
	{

		if(CurrentLevel + 1 < isUnlocked.Length)
			isUnlocked[CurrentLevel + 1] = true;
	}

	//a method to lock the next level
	public void SetNextLevelLock()
	{
		if(CurrentLevel + 1 < isUnlocked.Length)
			isUnlocked[CurrentLevel + 1] = false;
	}

	//check a button to see if its unlocked
	public bool CheckButtonUnlock(int _index)
	{
		if(CurrentLevel < isUnlocked.Length)
			return isUnlocked[_index];

		return false;
	}

	//increment the current level
	/*public void IncrementLevel()
	{
		currentLevel++;
	}*/

	public void GoToNextLevel()
	{
		if(CurrentLevel + 1 < levelNames.Length)
		{
			Application.LoadLevel(levelNames[++CurrentLevel]);
		}
		else
		{
			Application.LoadLevel("MainMenu");
		}
	}
}

