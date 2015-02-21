using UnityEngine;
using System.Collections;

public class CursorScript : MonoBehaviour {

	public GameObject radialSelection;
	public Animator cursorAnim;
	public GameObject highlight;

	private SpriteRenderer highLightRend;

	private RaycastHit2D hit;
	private Ray ray;

	// Use this for initialization
	void Start () 
	{
		Screen.showCursor = false;
		highLightRend = highlight.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));

		if(Input.GetMouseButtonDown(0))
		{
			cursorAnim.Play("CursorClickStartAnimation", -1, 0);
			radialSelection.transform.position = transform.position;
			cursorAnim.Play("RadialClickAnimation", 1, 0);

			hit = Physics2D.Raycast(transform.position, transform.forward);

			if(hit.transform != null)
			{
				Debug.Log(hit.transform.name);
				if(hit.transform.tag == "Minion")
				{
					SpriteRenderer renderer = hit.transform.GetComponent<SpriteRenderer>();

					if(renderer != null && highLightRend != null)
					{
						highLightRend.sprite = renderer.sprite;
						highLightRend.sortingOrder = renderer.sortingOrder - 1;
						highlight.GetComponent<HighLightScript>().target = hit.transform;
						highlight.transform.localScale = new Vector3(hit.transform.localScale.x + 0.2f, hit.transform.localScale.y + 0.2f, 1f);

					}
				}
				else
				{
					highlight.GetComponent<HighLightScript>().target = null;
				}
			}
			else
			{
				highlight.GetComponent<HighLightScript>().target = null;
			}
		}

		if(Input.GetMouseButtonUp(0))
		{
			cursorAnim.Play("CursorClickEndAnimation", -1, 0);
		}

	}

}
