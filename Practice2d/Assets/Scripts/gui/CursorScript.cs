using UnityEngine;
using System.Collections;

public class CursorScript : MonoBehaviour {

	//the radial graphic
	public GameObject radialSelection;
	//the animator for the cursor
	public Animator cursorAnim;
	//the highlight object
	public GameObject highlight;
	//the sprite renderer for the highlight object
	private SpriteRenderer highLightRend;

	//raycast used to detect mouse clicks on sprite objects
	private RaycastHit2D hit;

	// Use this for initialization
	void Start () 
	{
		//turn off the computer cursor
		Cursor.visible = false;
		//get the sprite renderer from the highlight object
		highLightRend = highlight.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//set the position of the hand cursor to the computer's cursor
		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));

		//If there is a left down click
		if(Input.GetMouseButtonDown(0))
		{
			//play the start clicking animation
			cursorAnim.Play("CursorClickStartAnimation", -1, 0);
			//move the radial graphic to the position of the cursor
			radialSelection.transform.position = transform.position;
			//have the cursor play the radial animation
			cursorAnim.Play("RadialClickAnimation", 1, 0);

			//get a raycast from the cursor going forward
			hit = Physics2D.Raycast(transform.position, transform.forward);

			//if something was hit
			if(hit.transform != null)
			{
				//if what was hit was a minion
				if(hit.transform.tag == "Minion")
				{
					//get the sprite renderer from the minion
					SpriteRenderer renderer = hit.transform.GetComponent<SpriteRenderer>();

					//if the renderer was found
					if(renderer != null && highLightRend != null)
					{
						//set the minion sprite to the hightlight sprite
						highLightRend.sprite = renderer.sprite;
						//set the sorting order of the hightlight to one less of the minion
						highLightRend.sortingOrder = renderer.sortingOrder - 1;
						//set the target of the highlight object from the minion
						highlight.GetComponent<HighLightScript>().target = hit.transform;
						//scale the hightlight to be slightly bigger than the minion
						//highlight.transform.localScale = new Vector3(hit.transform.localScale.x + 0.2f, hit.transform.localScale.y + 0.2f, 1f);
						highlight.transform.localScale = new Vector3(hit.transform.localScale.x * highlight.transform.localScale.x, hit.transform.localScale.y * highlight.transform.localScale.y, 1f);
					}
				}
				//if what was clicked on wasn't a minion then set the hightlight target to null
				else
				{
					highlight.GetComponent<HighLightScript>().target = null;
				}
			}
			//if the raycast didn't hit something then set the highlight target to null
			else
			{
				highlight.GetComponent<HighLightScript>().target = null;
			}
		}

		//when the right mouse if lifted up
		if(Input.GetMouseButtonUp(0))
		{
			//play the cursor lift up animation
			cursorAnim.Play("CursorClickEndAnimation", -1, 0);
		}

	}

}
