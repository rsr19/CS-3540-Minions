using UnityEngine;
using System.Collections;

public class CursorScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		Screen.showCursor = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
	}
}
