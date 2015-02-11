using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	private Transform destination;
	private float speed;

	public void Initalize(Transform _destination, float _speed)
	{
		destination = _destination;
		speed = _speed;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, destination.position, Time.deltaTime * speed);

		var distanceSquared = (destination.transform.position - transform.position).sqrMagnitude;

		if (distanceSquared > .01f * .01f) 
		{
			return;
		}
		Destroy (gameObject);
	
	}
}
