using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{
	/* Dette script KRÆVER at spilleren har tagget "Player".
		Hvis der er flere spillere bliver den første spiller valgt. */

	//Hastigheden som objektet følger med
	public float speed;

	//'Transform' komponenten på spilleren. Denne indeholder spillerens position.
	private Transform playerTransform;

	//Denne variabel bruges til at udregne hvor objektetes næste position.
	private Vector2 tempPosition;

	// Use this for initialization
	void Start ()
	{
		//Find et gameobjekt med tagget "Player", tag det objekts transform og læg det i playerTransform.
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per framse
	void Update ()
	{
		Follow ();
	}

	private void Follow()
	{
		/*Vælger den næste position som er lidt tættere på spilleren. Med hastigheden speed.
			  Vi ganger Time.deltaTime på speed for at gøre bevægelsen flydende og uafhængig af hvor god computeren er. */
		tempPosition = Vector2.MoveTowards (transform.position, playerTransform.position, speed * Time.deltaTime);
		transform.position = tempPosition;
	}
}