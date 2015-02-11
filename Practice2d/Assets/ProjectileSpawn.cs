using UnityEngine;
using System.Collections;

public class ProjectileSpawn : MonoBehaviour {

	public Transform destination;
	public Projectile Projectile;

	public float speed;
	public float fireRate;

	private float nextShotInSeconds;


	

	// Use this for initialization
	void Start () {
		nextShotInSeconds = fireRate;
	
	}
	
	// Update is called once per frame
	void Update () {





		if ((nextShotInSeconds -= Time.deltaTime) > 0) {
				return;
		}

		if (Input.GetMouseButtonDown (0) && Input.GetKey(KeyCode.Space))
		{



			nextShotInSeconds = fireRate;

			var projectile = (Projectile)Instantiate (Projectile, transform.position, transform.rotation);
			projectile.Initalize (destination, speed);
			//projectile.rigidbody2D.velocity = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		}
				




	
	}

	public void OnDrawGizmos()
	{
		if (destination == null) {return;}

		Gizmos.color = Color.red;
		Gizmos.DrawLine (transform.position, destination.position);
	}

}
