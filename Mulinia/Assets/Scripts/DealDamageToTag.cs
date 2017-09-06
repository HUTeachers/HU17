using UnityEngine;
using System.Collections;

public class DealDamageToTag : MonoBehaviour
{
	//Hvor meget den skader
	public int amount;

	//Det tag som tager damage
	public string damageTag;


	//Bruges i kollisioer
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == damageTag)
		{
			other.gameObject.GetComponent<Health>().ReceiveDamage(amount);
		}
	}

	//Kan bruges fra knapper
	public void DealDamageToTagButton()
	{
		GameObject.FindGameObjectWithTag (damageTag).GetComponent<Health> ().ReceiveDamage (amount);
	}
}
