using UnityEngine;
using System.Collections;

public class Hurt : MonoBehaviour {

	//place the Prefab Explosion in this slot.	
	public GameObject explosion;

	private GameObject canvas;
	public TimerScript timer;
	// Use this for initialization
	void Start () {
		canvas = GameObject.Find("Canvas");
		timer = canvas.GetComponent<TimerScript> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Hero")
		{
			GameObject.Instantiate(explosion, other.transform.position, transform.rotation);
			timer.DecreaseLives ();
			Destroy (other.gameObject);
			StartCoroutine(respawn());
		}


	}
	IEnumerator respawn()
	{
		yield return new WaitForSeconds (2);
		GameObject[] spawnpoints = GameObject.FindGameObjectsWithTag ("SpawnPoint");
		
		Transform spawnpoint = spawnpoints [Random.Range (0, spawnpoints.Length)].transform;
		
		Instantiate (Resources.Load("Prefabs/Hero"), spawnpoint.position, Quaternion.identity);
	}
	// Update is called once per frame
	void Update () {

	
	}
}
