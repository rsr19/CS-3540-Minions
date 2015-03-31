using UnityEngine;
using System.Collections;

public class TowerTest : MonoBehaviour {

	public GameObject bullet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//if the player presses the left mouse button
		if(Input.GetMouseButtonDown (0) && Input.GetKey(KeyCode.Space))
		{
			//convert the mouse location to world location
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
			
			//get the direction from the player to the mouse world location
			Vector2 mouseDir = new Vector2 (mousePos.x - transform.position.x, mousePos.y - transform.position.y).normalized;
			
			//instantiate the bullet
			GameObject obj = (GameObject)Instantiate(bullet, 
			                                         new Vector2(transform.position.x, transform.position.y ),
			                                         Quaternion.identity);
			//set the direction of the bullet
			obj.GetComponent<BulletScript2>().direction = mouseDir;
		}

	
	}

}
