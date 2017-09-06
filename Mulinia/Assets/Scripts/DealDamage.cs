using UnityEngine;
using System.Collections;

public class DealDamage : MonoBehaviour {
	// Giver damage, når den rammes af en spiller
	// Der skal være en collider (ikke trigger) på dette gameObject for, at det virker.
 
		
	//Størrelsen af den skade, objektet giver
	public int Damage = 10;
	
	
	//når noget colliderer med det her objekt bliver det betegnet "ting"
	private void OnCollisionEnter2D (Collision2D ting)
	{
		//Hvis "other" har et tag, der hedder "Player" sendes Damage til funktionen ReceiveDamage i scriptet Health på Player
		if (ting.gameObject.tag == "Player")
		{
			ting.gameObject.GetComponent<Health>().ReceiveDamage(Damage);
		}
	}
}
