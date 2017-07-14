using UnityEngine;
using System.Collections;

// Giver point, når den rammes af en spiller.
// Der skal være en trigger collider på dette gameObject, for at det virker.

public class GivePoints : MonoBehaviour {
	
	//Mængden af point, objektet giver.
	public int Points = 5;
	
		
	//når noget colliderer med det her objekt bliver det betegnet "ting"
	private void OnTriggerEnter2D (Collider2D ting)
	{
		
		//Hvis "other" har et tag, der hedder "Player" sendes Points til funktionen ReceivePoints i scriptet PointCounter på Player.
		if (ting.gameObject.tag == "Player")
		{
			ting.gameObject.GetComponent<PointCounter>().ReceivePoints(Points);
		}
	}
}