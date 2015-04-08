using UnityEngine;
using UnityEditor;
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

	private int currentLevel;

	public enum MenuSelect {Main, Level, Options};
	public MenuSelect selectedMenu;

	public static MenuScript Instance{get;set;}

	// Use this for initialization
	void Start () {
		Instance = this;
		DontDestroyOnLoad(transform.gameObject);
		anim = GetComponent<Animator>();
		currentLevel = 0;

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

	/*public void GetLevels()
	{
		isUnlocked = new bool[levelButtons.Length];
		for(int i = 0; i < isUnlocked.Length; i++)
			isUnlocked[i] = false;
		
		isUnlocked[0] = true;
		
		selectedMenu = MenuSelect.Main;
		
		SetButtons();
	}*/
	
	// Update is called once per frame
	/*void Update () {
		Debug.Log(blackFade.gameObject.activeSelf);
	}*/


	public void PlayAnim(string _animName)
	{
		anim.Play(_animName);
	}

	//a function that starts the fading effect
	/*public void StartLoadScene(string _sceneName)
	{

		StartCoroutine(LoadScene(_sceneName));
	}*/

	void OnLevelWasLoaded()
	{
		if(Application.loadedLevelName == "MainMenu")
		{
			/*switch(selectedMenu)
			{
			case MenuSelect.Main:

				break;
			case MenuSelect.Level:
				break;
			}*/

			GameObject fadeObject = GameObject.Find("BlackFade");

			if(fadeObject != null)
			{
				//Debug.Log("its not null");
				blackFade = fadeObject.GetComponent<Image>();
			}

			levelButtons = MenuStart.Instance.buttons; 

			//levelGrp.transform.chi
			SetButtons();
		}
	}

	public void StartLoadLevel(int _levelIndex)
	{
		currentLevel = _levelIndex;

		StartCoroutine("LoadScene");
	}

	//a coroutine for the fading effect
	private IEnumerator LoadScene()
	{
		Debug.Log("hey " + levelNames[currentLevel]);
		//if the blackFade object has been set
		if(blackFade != null)
		{
			//Debug.Log(blackFade.gameObject.activeSelf);
			//enable the blackFade and it's image just in case the arn't enabled
			//blackFade.gameObject.SetActive(true);
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
				//blackFade.gameObject.SetActive(true);
				//blackFade.enabled = true;

				//add the delta time to the incrementing variable
				trans += Time.deltaTime;

				//add the lerped number to the alpha 
				fadeColor.a = Mathf.Lerp(0, 1, trans);

				//add the new color to the blackFade color
				blackFade.color = fadeColor;

				yield return null;
			}
			Debug.Log(levelNames[currentLevel]);
			//once the blackFade is done transitioning load the specified level
			Application.LoadLevel(levelNames[currentLevel]);

			yield return null;
		}
	}

	private void SetButtons()
	{
		/*for(int i = 0; i < levelButtons.Length; i++)
		{
			//Debug.Log()
			levelButtons[i].interactable = isUnlocked[i];
		}*/
	}

/*	private struct Level
	{
		public string LevelName{get;set;}
		public bool IsUnlocked{get;set;}
		public Button LevelButton{get;set;}
	}*/

	public void SetNextLevelUnlock()
	{
		isUnlocked[currentLevel++] = true;
	}

	public void SetNextLevelLock()
	{
		isUnlocked[currentLevel++] = false;
	}

	public bool CheckButtonUnlock(int _index)
	{
		return isUnlocked[_index];
	}
}

/*public struct Level
{
	public string LevelName{get;set;}
	public bool IsUnlocked{get;set;}
	public Button LevelButton{get;set;}
}*/
