using UnityEngine;
using System.Collections;
public class HeroAI : MonoBehaviour {
	private GameObject obj;
	public GameObject ShieldPickUp;
	public bool Shield;
	public TimerScript script;
	public float velocity = 5f;
	public float speedCoefficient = 1;
	public float jumpHeight = 15f;
	public static float round = 1;

	public Transform sightStart;
	public Transform sightEnd;

	public bool isJumping;
	public bool colliding;
	public RaycastHit2D hit;
	public bool goFaster = false;

	private GameObject canvas;
	public TimerScript timer;

	public GameObject explosion;
	// Use this for initialization
	void Start () {
		canvas = GameObject.Find("Canvas");
		timer = canvas.GetComponent<TimerScript> ();
		Shield = false;
	}
	
	// Update is called once per frame
	void Update () {

		GetComponent<Rigidbody2D>().velocity = new Vector2 (velocity * speedCoefficient, GetComponent<Rigidbody2D>().velocity.y);
		colliding = Physics2D.Linecast (sightStart.position, sightEnd.position);
		hit = Physics2D.Linecast (sightStart.position, sightEnd.position);
		if (colliding)
		{
			// If hero is touching the ground, allow hit to jump
			if (isJumping == false)
			{
				if (round == 1)
				{
					if (hit.collider.tag == "Jumper1" || hit.collider.tag == "Ground" || hit.collider.tag == "Minion")
					{
						GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
						isJumping = true;
					}
				}

				else if (round == 2)
				{


					if (hit.collider.tag == "Jumper2" || hit.collider.tag == "Ground" || hit.collider.tag == "Minion")
					{
						Debug.Log ("Jump");
						GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
						isJumping = true;
					}
				}

				else if (round == 3)
				{
					if (hit.collider.tag == "Jumper3" || hit.collider.tag == "Ground" || hit.collider.tag == "Minion")
					{
						GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
						isJumping = true;
					}
				}

			//GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
			//isJumping = true;

			}
		}
	}
	void OnDrawGizmos()
	{
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine (sightStart.position, sightEnd.position);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		// Sets isJumping to 'false' when it touches the ground.
		if (collision.transform.tag == "Ground")
			isJumping = false;

		// Kills Hero if hero hits any objects tagged as hazard
		else if (collision.transform.tag == "Hazard") 
		{
			//timer.DecreaseLives ();
			//Destroy (gameObject);
			//StartCoroutine(respawn ());

			StartCoroutine(respawn());	
			GameObject.Instantiate(explosion, transform.position, transform.rotation);
			timer.DecreaseLives ();

		}


	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Faster")
						speedCoefficient = 2f;
			//velocity = fasterVelocity;
		else if (collision.tag == "Slower")
						velocity = 10f;
				
				 else if (collision.tag == "Jumper")
				{
					GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
				}
		else if(collision.tag == "Goal")
			timer.ShowGameOver();
		else if (collision.tag == "Minion")
			{
				if(Shield)
				{
					Shield = false;
					Destroy(collision.gameObject);
					Destroy (obj);
				}
				else
				{

					StartCoroutine(respawn());	
					GameObject.Instantiate(explosion, transform.position, transform.rotation);
					timer.DecreaseLives ();
				}
			}
		if (collision.tag == "Shield") 
		{
			Shield = true;
			Destroy(collision.gameObject);
		//	Instantiate(ShieldPickUp, transform.position, Quaternion.identity );

			 obj = (GameObject)Instantiate(ShieldPickUp, 
			                                         new Vector2(transform.position.x, transform.position.y ),
			                                         Quaternion.identity);

			//set the direction of the bullet
			obj.GetComponent<ShieldScript>().Hero = gameObject;

		}

	}
	IEnumerator respawn()
	{
		Debug.Log ("Working");
		yield return new WaitForSeconds(0.5f);
		Debug.Log ("Finished");
		respawner();
		Destroy(gameObject);
	}

	public void respawner()
	{
		if (round < 4) {
						round++;
				}
				else{
		     round = 1;}

		Debug.Log("respawner");
		GameObject[] spawnpoints = GameObject.FindGameObjectsWithTag ("SpawnPoint");
		
		Transform spawnpoint = spawnpoints [Random.Range (0, spawnpoints.Length)].transform;
		
		Instantiate (Resources.Load("Prefabs/Hero"), spawnpoint.position, Quaternion.identity);
	}



}
