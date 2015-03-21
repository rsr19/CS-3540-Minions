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
						GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
				}


				if (Input.GetKey (KeyCode.D)) {
						GetComponent<Rigidbody2D>().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
				}

				if (Input.GetKey (KeyCode.A)) {
						GetComponent<Rigidbody2D>().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
				}

			if(Input.GetMouseButtonDown(0))
			{
				isActive = false;
			}
				
		}
	
	}



}
