using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {

	public float moveSpeed;
	public float jumpHeight;
	public bool	isActive;

	// Use this for initialization
	void Start () {
		isActive = false;
	}

	void OnMouseDown()
	{
		isActive = true;
	

	}

	void OnMouseUp()
	{
		isActive = true;
	}



	// Update is called once per frame
	void Update () {




		if (isActive == true)
		{
				if (Input.GetKeyDown (KeyCode.Space)) {
						rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, jumpHeight);
				}


				if (Input.GetKey (KeyCode.D)) {
						rigidbody2D.velocity = new Vector2 (moveSpeed, rigidbody2D.velocity.y);
				}

				if (Input.GetKey (KeyCode.A)) {
						rigidbody2D.velocity = new Vector2 (-moveSpeed, rigidbody2D.velocity.y);
				}

			if(Input.GetMouseButtonDown(0))
			{
				isActive = false;
			}
				
		}
	
	}



}
