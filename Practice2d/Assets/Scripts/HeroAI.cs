using UnityEngine;
using System.Collections;
public class HeroAI : MonoBehaviour {
	public TimerScript script;
	public float velocity = 5f;
	public float speedCoefficient = 1;
	public float jumpHeight = 15f;

	public Transform sightStart;
	public Transform sightEnd;

	public bool isJumping;
	public bool colliding;
	public RaycastHit2D hit;
	public bool goFaster = false;

	private GameObject canvas;
	public TimerScript timer;

	// Use this for initialization
	void Start () {
		canvas = GameObject.Find("Canvas");
		timer = canvas.GetComponent<TimerScript> ();

	}
	
	// Update is called once per frame
	void Update () {

		GetComponent<Rigidbody2D>().velocity = new Vector2 (velocity * speedCoefficient, GetComponent<Rigidbody2D>().velocity.y);
		colliding = Physics2D.Linecast (sightStart.position, sightEnd.position);
		hit = Physics2D.Linecast (sightStart.position, sightEnd.position);
		if (colliding)
		{
			if (isJumping == false)
			GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
			isJumping = true;
		}
	}
	void OnDrawGizmos()
	{
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine (sightStart.position, sightEnd.position);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.tag == "Ground")
			isJumping = false;
	}
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Faster")
						speedCoefficient = 2f;
			//velocity = fasterVelocity;
		else if (collision.tag == "Slower")
						velocity = 10f;
				else if (collision.tag == "Hazard") {
						timer.DecreaseLives ();
						Destroy (gameObject);
						respawn ();
				} else if (collision.tag == "Jumper")
				{
					GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
				}
		else if(collision.tag == "Goal")
			timer.ShowGameOver();
	}
	void respawn()
	{
		GameObject[] spawnpoints = GameObject.FindGameObjectsWithTag ("SpawnPoint");
	
		Transform spawnpoint = spawnpoints [Random.Range (0, spawnpoints.Length)].transform;
	
		Instantiate (Resources.Load("Prefabs/Hero"), spawnpoint.position, Quaternion.identity);
	}


}
