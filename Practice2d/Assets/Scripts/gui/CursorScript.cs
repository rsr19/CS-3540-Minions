using UnityEngine;
using System.Collections;

public class CursorScript : MonoBehaviour {

	public GameObject radialSelection;
	public Animator cursorAnim;

	// Use this for initialization
	void Start () 
	{
		Screen.showCursor = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));

		if(Input.GetMouseButtonDown(0))
		{
			cursorAnim.Play("CursorClickStartAnimation", -1, 0);
			radialSelection.transform.position = transform.position;
			cursorAnim.Play("RadialClickAnimation", 1, 0);
		}

		if(Input.GetMouseButtonUp(0))
		{
			cursorAnim.Play("CursorClickEndAnimation", -1, 0);
		}
	}
}
