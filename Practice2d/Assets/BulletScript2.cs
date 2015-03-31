using UnityEngine;
using System.Collections;

public class BulletScript2 : MonoBehaviour {

	public float veloLimit;
	public Vector2 direction;
	public float speed;
	// Use this for initialization
	void Start () {
	
	}

	
		//this goes in the FixedUpdate method in my bullet script
		void FixedUpdate () 
		{
			//move the bullet a direction while it is not going faster than the velocity limit
			if (GetComponent<Rigidbody2D>().velocity.x < veloLimit && GetComponent<Rigidbody2D>().velocity.x > -veloLimit && 
			    GetComponent<Rigidbody2D>().velocity.y < veloLimit && GetComponent<Rigidbody2D>().velocity.y > -veloLimit) 
			{
				
				GetComponent<Rigidbody2D>().AddForce (new Vector2 (direction.x * speed, direction.y * speed));

			}
		}
		
		//veloLimit is the maximum velocity that the bullet can have
		//direction is the direction that the bullet will travel
		//speed is kind of useless but it a factor on how hard to push the bullet
	}

