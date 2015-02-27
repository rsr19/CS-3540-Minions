using UnityEngine;
using System.Collections;

public class HighLightScript : MonoBehaviour {

	//the target that will be highlighted
	public Transform target{get; set;}

	//the sprite renderer of the target
	private SpriteRenderer rend;

	void Start()
	{
		//get the sprite renderer from the target
		rend = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		//if the target is not null then set the highlights to the target's current position
		if(target != null)
		{
			transform.position = target.position;
		}
		//if the target doesn't have a renderer then turn off the highlight
		else if(rend != null)
		{
			rend.sprite = null;
		}
	}
}
