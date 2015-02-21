using UnityEngine;
using System.Collections;

public class HighLightScript : MonoBehaviour {

	public Transform target{get; set;}

	private SpriteRenderer rend;

	void Start()
	{
		rend = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(target != null)
		{
			transform.position = target.position;
		}
		else if(rend != null)
		{
			rend.sprite = null;
		}
	}
}
