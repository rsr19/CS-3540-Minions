using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudScript : MonoBehaviour 
{
	public Image[] lives;

	public Image blackFade;

	// Use this for initialization
	void Start () {
		SetLives(1);

		StartCoroutine("LoadScene");

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

	private IEnumerator LoadScene()
	{

		if(blackFade != null)
		{
			blackFade.transform.gameObject.SetActive(true);
			
			blackFade.enabled = true;
			
			float trans = 0;
			Color fadeColor = blackFade.color;
			fadeColor.a = 1;
			
			while(trans < 1)
			{
				Debug.Log(trans);

				trans += 1.5f * Time.deltaTime;
				
				fadeColor.a = Mathf.Lerp(1, 0, trans);
				
				blackFade.color = fadeColor;
				
				yield return null;
			}
			
			yield return null;
		}

	}
}
