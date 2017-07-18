using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour {

	public bool climbing = false;

	private float searchLength = .2f;

	// Update is called once per frame
	void Update () {

		//Downwards ladder searching
		if(Input.GetAxis("Vertical") < 0 && !climbing)
		{
			RaycastHit2D LadderSearcher = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.8f), Vector2.down, searchLength, LayerMask.GetMask("LadderLayer"));
			if(LadderSearcher.collider != null)
			{
				climbing = true;
				//Transform replace 1 of 2
				transform.position = new Vector3(LadderSearcher.collider.transform.position.x, transform.position.y, transform.position.z);
			}

		}
        //Upwards ladder searching
        else if(Input.GetAxis("Vertical") > 0 && !climbing)
        {
            RaycastHit2D LadderSearcher = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + 0.5f), Vector2.up, searchLength, LayerMask.GetMask("LadderLayer"));
            if (LadderSearcher.collider != null)
            {
                climbing = true;
                //Transform replace 1 of 2
                transform.position = new Vector3(LadderSearcher.collider.transform.position.x, transform.position.y, transform.position.z);
            }
        }
		else if (climbing)
		{
			//You can disconnect from a ladder if you are currently not moving vertically, and instead horizontally.
			if (Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") == 0 || Input.GetKeyDown(KeyCode.Space) && Input.GetAxis("Vertical") == 0)
			{
				climbing = false;
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
