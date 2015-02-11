using UnityEngine;
using System.Collections;

public class SpikeMinion : MonoBehaviour {
	private bool falling;
	public float speed;

	// Use this for initialization
	void Start () 
	{
		falling = false;
	}

	void OnMouseDown()
	{
		falling = true;
	}

	// Update is called once per frame
	void Update () 
	{
		if (falling) {
			transform.Translate(-Vector2.up*Time.deltaTime*speed);
				}

	}



}
