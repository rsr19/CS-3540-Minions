using UnityEngine;
using System.Collections;

public class Hurt : MonoBehaviour {

	//place the Prefab Explosion in this slot.	
	public GameObject explosion;
	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Minion")
		{
				
			GameObject.Instantiate(explosion, other.transform.position, transform.rotation);	
			Destroy (other.gameObject);
			respawn();
		}


	}
	void respawn()
	{
		GameObject[] spawnpoints = GameObject.FindGameObjectsWithTag ("SpawnPoint");
		
		Transform spawnpoint = spawnpoints [Random.Range (0, spawnpoints.Length)].transform;
		
		Instantiate (Resources.Load("Prefabs/Hero"), spawnpoint.position, Quaternion.identity);
	}
	// Update is called once per frame
	void Update () {

	
	}
}
