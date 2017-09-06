using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour {
	Rigidbody2D rb2d;

	//MoveSpeed styrer hastigheden af spillerens bevægelse
	[Header("Default: 5")]
	public float moveSpeed = 5;

	//værdi for hvor meget x og y skal ændres ved hver frame
	private float deltaY;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		deltaY = moveSpeed * Input.GetAxis("Vertical");

		//Her ændres objektets hastighed på y-akse.
		rb2d.velocity = new Vector2(rb2d.velocity.x, deltaY);
	}
}
