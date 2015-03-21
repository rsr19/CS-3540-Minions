using UnityEngine;
using System.Collections;

public class HurtRigidboy : MonoBehaviour {

	private float velocity;

	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (velocity > 0) {

						if (other.gameObject.tag == "Minion") {
			
								Destroy (other.gameObject);
						}
				}
		}
			


	
	// Update is called once per frame
	void Update () {
		velocity = GetComponent<Rigidbody2D>().velocity.x + GetComponent<Rigidbody2D>().velocity.y;
	}
}
