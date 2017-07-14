using UnityEngine;
using System.Collections;

public class PlayerMovementSmooth : MonoBehaviour {
	//Dette script lader spilleren styre figurens bevægelser med piletaster eller med adsw

	//MoveSpeed styrer hastigheden af spillerens bevægelse
	public float moveSpeed= 5;

	//her kan man vælge om det skal være muligt at bevæge sig op/ned og højre/venstre
    public bool X;
    public bool Y;

	//værdi for hvor meget x og y skal ændres ved hver frame
	private float deltaX;
	private float deltaY;
	


	// Update is called once per frame
	void Update () {

		//Hvis right/left bevægelse er tilvalgt beregnes deltaX. Input.GetAxis er en Unity-feature, som giver bløde bevægelser.
		if (X)
		{
			deltaX = moveSpeed * Input.GetAxis("Horizontal");

			//Her ændres objektets hastighed på x-akse. Y-værdi fastholdes.
			GetComponent<Rigidbody2D>().velocity = new Vector2 (deltaX, GetComponent<Rigidbody2D>().velocity.y);
		}

		//Hvis right/left bevægelse er tilvalgt beregnes deltaY. Input.GetAxis er en Unity-feature, som giver bløde bevægelser.
		if (Y)
		{
			deltaY = moveSpeed * Input.GetAxis("Vertical");

			//Her ændres objektets hastighed på y-akse. X-værdi fastholdes.
			GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, deltaY);
		}

	}
	
}