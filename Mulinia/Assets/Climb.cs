using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour {

	public bool climbing = false;

	private float searchLength = 2f;

	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Vertical") < 0 && !climbing)
		{
			RaycastHit2D LadderSearcher = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down, searchLength, LayerMask.GetMask("LadderLayer"));
			if(LadderSearcher.collider != null)
			{
				climbing = true;
				transform.position = new Vector3(LadderSearcher.collider.transform.position.x, transform.position.y - 0.5f, transform.position.z);

			}

		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		OnTriggerStay2D(col);
	}
	void OnTriggerStay2D(Collider2D col)
	{
		if(col.tag == "Ladder")
		{
			if (Input.GetAxis("Vertical") > 0)
			{
				if (!climbing)
				{
					climbing = true;
					Vector3 movevec = new Vector3(col.transform.position.x, transform.position.y, transform.position.z);
					transform.position = movevec;
				}
			}
		}
		
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.tag == "Ladder")
		{
			climbing = false;
		}
	}
}
