using UnityEngine;
using System.Collections;

public class HammerMinion : MonoBehaviour {
	Animator anim;

	// Use this for initialization
	void Start () 
	{
		anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	/*void Update () {
	
	}*/

	void OnMouseDown()
	{
		if(!anim.GetCurrentAnimatorStateInfo(0).IsName("HammerLeft"))
			anim.Play("HammerLeft");
		
	}

}
