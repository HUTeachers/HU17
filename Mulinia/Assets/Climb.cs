﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour {

	public bool climbing = false;

	private float searchLength = 1.5f;

	// Update is called once per frame
	void Update () {

		//Downwards ladder searching
		if(Input.GetAxis("Vertical") < 0 && !climbing)
		{
			RaycastHit2D LadderSearcher = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.5f), Vector2.down, searchLength, LayerMask.GetMask("LadderLayer"));
			if(LadderSearcher.collider != null)
			{
				climbing = true;
				//Transform replace 1 of 2
				transform.position = new Vector3(LadderSearcher.collider.transform.position.x, transform.position.y, transform.position.z);

			}

		}
		else if (climbing)
		{
			if (Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") == 0 || Input.GetKeyDown(KeyCode.Space))
			{
				climbing = false;
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
