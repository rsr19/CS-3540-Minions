using UnityEngine;
using System.Collections;

public class Hurt : MonoBehaviour {

	//place the Prefab Explosion in this slot.	
	public GameObject explosion;
	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Minion" | other.tag == "Hazard")
		{
				
			GameObject.Instantiate(explosion, other.transform.position, transform.rotation);	
			Destroy (other.gameObject);
		}


	}
	
	// Update is called once per frame
	void Update () {

	
	}
}
