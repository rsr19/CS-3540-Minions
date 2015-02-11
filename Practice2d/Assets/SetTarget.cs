using UnityEngine;
using System.Collections;

public class SetTarget : MonoBehaviour {

	private Transform target; 
	
	void Awake()
	{
		//Find the player object and set it
		target = GameObject.FindGameObjectWithTag("Target").transform;
	}
	
	void Update()
	{
		// Check if you click the left mouse button then change position
		if (Input.GetMouseButtonDown(0))
			target.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}
}
