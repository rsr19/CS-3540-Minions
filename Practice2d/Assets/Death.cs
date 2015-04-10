using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {

	public GameObject Smoke;

	
	// Use this for initialization
	void Start () {
	
	}


	void OnCollisionEnter2D(Collision2D other) {
				if (other.gameObject.tag == "Minion" || other.gameObject.tag == "Hazard" || other.gameObject.tag == "Hero") {
						GameObject.Instantiate (Smoke, transform.position, transform.rotation);

						Destroy (gameObject);

				}

		}

	
	// Update is called once per frame
	void Update () {
	
	}
}
