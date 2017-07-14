using UnityEngine;
using System.Collections;

public class TwoPointMove : MonoBehaviour
{
	//Kordinaterne som objektet går fra
	public Vector2 startPosition;

	//Kordinatet som objektet går til
	public Vector2 endPosition;

	//Hastigheden objektet bevæger sig
	public float speed;

	//Denne linje laver beskrivelsen i unity-editoren.
	[Header("Distance til position inden objektet vender om")]
	//Denne variabel bestemmer hvor langt fra målet objektet maks må være, inden objektet skal vende om
	public float minDistance;

	//Hvor lang tid objektet venter ved et punkt, før den går videre
	public float waitTime;

	//Fortæller om objektet skal teleportere tilbage til startPosition, hvis den er false, går den hver vej.
	public bool teleportBack = false;

	//Om objektet bevæger sig til 'endPosition' variablen. Hvis falsk, bevæger den sig til 'startPosition'
	private bool movingToEnd = true;

	//Denne variabel bruges til at udregne hvor objektetes næste position.
	private Vector2 tempPosition;

	//Denne variabel bruges til at måle hvor langt der er til hvor objektet skal hen.
	private float distanceToTarget;

	//Bestemmer om objektet er i gang med at vente.
	private bool waiting = false;

	void Update ()
	{
		//Kald metoden som faktisk får objektet til at bevæge sig. 
		MoveBetweenPoints ();

		//kald metoden som skifter retning på objektet, hvis den er tæt nok på hvor den skal være.
		CheckAndChangeDirection();
	}

	private void MoveBetweenPoints()
	{
		//Hvis objektet venter, skal vi IKKE køre resten af metoden, så vi går ud af den med 'return'
		if (waiting)
			return;

		//Hvis vi skal gå til endPosition
		if(movingToEnd)
		{
			/*Vælger den næste position som er lidt tættere på hvor objektet skal hen. Med hastigheden speed.
			  Vi ganger Time.deltaTime på speed for at gøre bevægelsen flydende og uafhængig af hvor god computeren er.
			  Her går objektet til endPosition. */
			tempPosition = Vector2.MoveTowards (transform.position, endPosition, speed * Time.deltaTime);
		}
		// Hvis vi går til startPosition
		else 
		{
			/*Vælger den næste position som er lidt tættere på hvor objektet skal hen. Med hastigheden speed.
			  Vi ganger Time.deltaTime på speed for at gøre bevægelsen flydende og uafhængig af hvor god computeren er.
			  Her går objektet til startPosition. */
			tempPosition = Vector2.MoveTowards (transform.position, startPosition, speed * Time.deltaTime);
		}

		transform.position = tempPosition;
	}

	private void CheckAndChangeDirection()
	{
		//Hvis vi skal gå til endPosition
		if(movingToEnd)
		{
			//Mål distancen til endPosition
			distanceToTarget = Vector2.Distance (transform.position, endPosition);
		}
		// Hvis vi går til startPosition
		else
		{
			//Mål distancen til endPosition
			distanceToTarget = Vector2.Distance (transform.position, startPosition);
		}

		//Hvis objektet er tæt nok, til at objektet kan vende om
		if(distanceToTarget <= minDistance)
		{
			//Hvis objektet er i gang med at gå. Altså hvis objektet IKKE venter
			if(!waiting)
			{
				//Ændre retning på objektet, efter waitTime er gået.
				StartCoroutine(Wait());

				//Objektet skal nu vente
				waiting = true;
			}
		}

	}

	/*En IEnumatator bruges til at køre kode efter noget tid.
	  De skal kaldes med StartCoroutine( NAVN() );
	  istedet for        NAVN();
	  som metoder normalt gør */
	IEnumerator Wait()
	{
		//Denne linje siger at den skal vente så lang tid som waitTime variablen er, inden det efterfølgende kode bliver kørt.
		yield return new WaitForSeconds (waitTime);

		//Objektet skal teleporte tilbage og gå frem igen
		if(teleportBack)
		{
			//Teleport tilbage til startPosition, og gå til endPosition.
			transform.position = startPosition;
		}
		//Hvis objektet går begge veje
		else
		{
			//Ændre retning på objektet. Hvis den er true bliver den false, er den false bliver den true.
			movingToEnd = !movingToEnd;	
		}


		//Objektet venter ikke mere nu, når den har ventet og har skiftet retning.
		waiting = false;

	}
}