using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

	public Image blackFade;

	// Use this for initialization
	/*void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}*/

	public void StartLoadScene(string _sceneName)
	{
		StartCoroutine(LoadScene(_sceneName));
	}

	private IEnumerator LoadScene(string _sceneName)
	{
		if(blackFade != null)
		{
			blackFade.transform.gameObject.SetActive(true);
			
			blackFade.enabled = true;
			
			float trans = 0;
			Color fadeColor = blackFade.color;
			fadeColor.a = 0;
			
			while(trans < 1)
			{
				Debug.Log(trans);
				
				trans += Time.deltaTime;
				
				fadeColor.a = Mathf.Lerp(0, 1, trans);
				
				blackFade.color = fadeColor;

				yield return null;
			}
			
			Application.LoadLevel(_sceneName);

			yield return null;
		}
	}
}
