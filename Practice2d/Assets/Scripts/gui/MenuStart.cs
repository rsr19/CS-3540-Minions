﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuStart : MonoBehaviour {
	public Button[] buttons;

	private GameObject menu;
	private MenuScript menuScript;

	public static MenuStart Instance{get;set;}
	// Use this for initialization
	void Awake () 
	{
		Instance = this;

		if(MenuScript.Instance == null)
		{
			menu = (GameObject)Instantiate(Resources.Load("Prefabs/Gui/MenuLogic"), Vector3.zero, Quaternion.identity);
			menuScript = menu.GetComponent<MenuScript>();
		}
		else
		{
			menuScript = MenuScript.Instance;
		}


	}


	public void StartLoadLevel(int _levelIndex)
	{
		menuScript.StartLoadLevel(_levelIndex);
	}
}
