using UnityEngine;
using System.Collections;

public class ShieldScript : MonoBehaviour {

	public GameObject Hero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = Hero.transform.position;


	
	}
}
