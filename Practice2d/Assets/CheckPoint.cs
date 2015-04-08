using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

	GameObject spawn;

	// Use this for initialization
	void Start () {
		spawn = GameObject.Find("SpawnPoint");
	}

	public void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Hero")
						spawn.transform.position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
