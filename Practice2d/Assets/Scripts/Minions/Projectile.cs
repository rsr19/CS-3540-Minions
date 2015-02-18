using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	private Transform destination;
	private float speed;
	private Vector3 location;

	public void Initalize(Transform _destination, float _speed)
	{
		destination = _destination;
		speed = _speed;
		location = _destination.position;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = Vector3.MoveTowards (transform.position, location , Time.deltaTime * speed);


	
		if (transform.position == location) 
		{
			Destroy(gameObject);
		}

	
	
	}
}
