using UnityEngine;
using System.Collections;

public class Select : MonoBehaviour {

	public bool	isActive;

	// Use this for initialization
	void Start () {
	
	}

	void OnMouseDown()
	{
		isActive = true;
		
		
	}
	
	void OnMouseUp()
	{
		isActive = true;
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown(0))
		{
			isActive = false;
		}
	
	}
}
