using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public Rect scrollBoundaryinPercent;
	private Rect scrollBoundary;

	public bool lockX;
	public bool lockY;

	public float moveSpeed;
	private Vector3 currentPos;

	// Use this for initialization
	void Start () 
	{

		scrollBoundary.x = (scrollBoundaryinPercent.x / 100) * Screen.width;
		scrollBoundary.y = (scrollBoundaryinPercent.x / 100) * Screen.height;
		scrollBoundary.width = (scrollBoundaryinPercent.width / 100) * Screen.width;
		scrollBoundary.height = (scrollBoundaryinPercent.height / 100) * Screen.height;
	}
	
	// Update is called once per frame
	void Update () 
	{
		currentPos = transform.position;

		if(Input.mousePosition.x > 0 && Input.mousePosition.x < Screen.width && Input.mousePosition.y > 0 && Input.mousePosition.y < Screen.height)
		{
			if(!lockX)
			{
				if(Input.mousePosition.x < scrollBoundary.x)
				{
					//Debug.Log("move left");
					currentPos.x -= moveSpeed;
				}
				else if(Input.mousePosition.x > scrollBoundary.width)
				{
					//Debug.Log("move right");
					currentPos.x += moveSpeed;
				}
			}

			if(!lockY)
			{
				if(Input.mousePosition.y < scrollBoundary.y)
				{
					//Debug.Log("move down");
					currentPos.y -= moveSpeed;
				}
				else if(Input.mousePosition.y > scrollBoundary.height)
				{
					//Debug.Log("move up");
					currentPos.y += moveSpeed;
				}
			}
		}

		transform.position = currentPos;
	}
	
}
