using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudScript : MonoBehaviour 
{
	public Image[] lives;

	// Use this for initialization
	void Start () {
		SetLives(1);
	}
	
	// Update is called once per frame
	/*void Update () {
	
	}*/

	public void SetLives(int _amt)
	{

		foreach(Image _img in lives)
			_img.enabled = false;

		if(_amt < lives.Length + 1 && _amt >= 0)
		{
			for(int i = 0; i < _amt; i++)
			{
				Debug.Log(i);
				lives[i].enabled = true;
			}
		}
	}
}
