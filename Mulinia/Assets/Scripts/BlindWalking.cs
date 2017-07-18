using UnityEngine;
using System.Collections;

public class BlindWalking : MonoBehaviour {

	// Scriptet får et objekt til at gå til siden ind til den rammer noget. Så vender den om og går i den modsatte retning. 
	// Objektet skal have en rigidbody.
	// Scriptet er afhængig af at andre objekter har tags (Wall, Ground, Player).

	// Objektets walk hastighed
	public float walkSpeed = 5;

	// Objektets nuværende hastighed (ved frit fald skal den være nul)
	private float currentSpeed;

	// Hvis true starter den med at gå mod venstre - ellers starter den mod højre
	public bool ModVenstre = false;

	// variabel, som styrer om objekt bevæger sig mod højre eller venstre
	private int retning = 1;


	void Start ()
	{
		currentSpeed = walkSpeed;

		if (ModVenstre)
		{
			retning = -1;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2 (currentSpeed*retning, GetComponent<Rigidbody2D>().velocity.y);
	}

	void OnCollisionStay2D (Collision2D ting)
	{
		if (ting.gameObject.tag == "Ground")
		{
			currentSpeed = walkSpeed;
		}
	}

	void OnCollisionEnter2D (Collision2D ting)
	{
		if (ting.gameObject.tag != "Ground")
		{
			retning *= -1;
		}
	}

	void OnCollisionExit2D (Collision2D ting)
	{
		if (ting.gameObject.tag == "Ground")
		{
			currentSpeed = 0;
		}
	}
}
