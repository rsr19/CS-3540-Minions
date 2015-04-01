using UnityEngine;
using System.Collections;

public class FrogMinion : MonoBehaviour {
	Animator anim;
	Rigidbody2D rigidBody;



	public float jumpPower;
	
	// Use this for initialization
	void Start () 
	{
		anim = this.GetComponent<Animator>();
		rigidBody = this.GetComponent<Rigidbody2D>();

		//rigidBody.
	}
	
	// Update is called once per frame
	/*void Update () {
	
	}*/
	
	void OnMouseDown()
	{
		if(!anim.GetCurrentAnimatorStateInfo(0).IsName("FrogJump"))
		{
			anim.Play("FrogJump", 0, .1f);
			float test = (jumpPower / 230f) - ((jumpPower - 230f) * .007f);
			anim.speed = test;
			Debug.Log((jumpPower - 230f) * .1f);
			Debug.Log(test);
			rigidBody.AddForce(new Vector2(0, jumpPower));
		}
		
	}

	void OnCollisionEnter2D(Collision2D hit)
	{
		if(hit.transform.tag == "Ground")
		{
			anim.Play("FrogStill");
		}
	}
}
