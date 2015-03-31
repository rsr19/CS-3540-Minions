using UnityEngine;
using System.Collections;

public class destructible : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Minion" || other.tag == "Hero")
						Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {


	
	}
}
