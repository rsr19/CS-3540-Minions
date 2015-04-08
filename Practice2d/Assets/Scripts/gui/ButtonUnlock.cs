using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonUnlock : MonoBehaviour 
{
	public int levelNum;

	// Use this for initialization
	void Start () {
		Button button = GetComponent<Button>();

		MenuScript menu = MenuScript.Instance;

		//button.interactable = menu.CheckButtonUnlock(levelNum);
	}
	
	// Update is called once per frame
	/*void Update () {
	
	}*/
}
