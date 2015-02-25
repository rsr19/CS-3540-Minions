using UnityEngine;
using System.Collections;

public class HeroAI : MonoBehaviour {

	public float velocity = 5f;
	public float jumpHeight = 15f;
	public float fasterVelocity = 6f;
	public float move = 6f;
	public Transform sightStart;
	public Transform sightEnd;

	public bool colliding;
	public RaycastHit2D hit;
	public bool goFaster = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/*if(goFaster)
			rigidbody2D.velocity = new Vector2 (fasterVelocity, rigidbody2D.velocity.y);
		else*/ 
		rigidbody2D.velocity = new Vector2 (velocity, rigidbody2D.velocity.y);
		colliding = Physics2D.Linecast (sightStart.position, sightEnd.position);
		hit = Physics2D.Linecast (sightStart.position, sightEnd.position);
		if (colliding)
		{
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, jumpHeight);
		}
	}
	void OnDrawGizmos()
	{
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine (sightStart.position, sightEnd.position);
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Faster")
						velocity = fasterVelocity;
				else if (collision.tag == "Slower")
						velocity = 10f;
				else if (collision.tag == "Hazard")
						Destroy (gameObject);
	}
}
