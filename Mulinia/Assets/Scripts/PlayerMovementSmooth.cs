using UnityEngine;
using System.Collections;

public class PlayerMovementSmooth : MonoBehaviour {
	//Dette script lader spilleren styre figurens bevægelser med piletaster eller med adsw

	//MoveSpeed styrer hastigheden af spillerens bevægelse
	[Header("Default: 5")]
	public float moveSpeed = 5;

	//her kan man vælge om det skal være muligt at bevæge sig op/ned og højre/venstre
    public bool X;
    public bool Y;

	//værdi for hvor meget x og y skal ændres ved hver frame
	private float deltaX;
	private float deltaY;

	private Rigidbody2D rb2d;
	

	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {

		//Hvis right/left bevægelse er tilvalgt beregnes deltaX. Input.GetAxis er en Unity-feature, som giver bløde bevægelser.
		if (X)
		{
			deltaX = moveSpeed * Input.GetAxis("Horizontal");

			//Her ændres objektets hastighed på x-akse. Y-værdi fastholdes.
			rb2d.velocity = new Vector2 (deltaX, rb2d.velocity.y);
		}

		//Hvis right/left bevægelse er tilvalgt beregnes deltaY. Input.GetAxis er en Unity-feature, som giver bløde bevægelser.
		if (Y)
		{
			deltaY = moveSpeed * Input.GetAxis("Vertical");

			//Her ændres objektets hastighed på y-akse. X-værdi fastholdes.
			rb2d.velocity = new Vector2 (rb2d.velocity.x, deltaY);
		}

		if(!X && !Y)
		{
			throw new System.Exception("Neither X or Y enabled, enable one or both.");
		}

	}

	public void Freeze()
	{
		rb2d.velocity = Vector2.zero;
		rb2d.gravityScale = 0f;
	}

	public void UnFreeze()
	{
		rb2d.gravityScale = 1f;
	}
	
}