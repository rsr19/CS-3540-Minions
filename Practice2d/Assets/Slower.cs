using UnityEngine;
using System.Collections;

public class Slower : MonoBehaviour {

	public float slowerSpeed;
	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Hero") 
		{
			collision.GetComponent<HeroAI>().velocity = slowerSpeed;

		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
