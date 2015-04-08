using UnityEngine;
using System.Collections;

public class Falloff : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Minion" || other.tag == "Hero")
		{
			
				
			Destroy (other.gameObject);
		}
		
		
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
