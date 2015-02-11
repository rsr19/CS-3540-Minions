using UnityEngine;
using System.Collections;


public class TowerMinion : MonoBehaviour {

	// Use this for initialization
	void Start () {

	
	}

	public bool Check()
	{
	
			return GetComponent<Select> ().isActive; 
		
	}
	// Update is called once per frame
	void Update () {

	}
}
