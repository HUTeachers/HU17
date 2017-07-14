using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {
	//Dette script tjekker om objektet rører noget med et tag kaldet "Ground"
	//Scriptet sættes på empty object med trigger collider under player figur (så det tjekker om player står på noget Ground)

	//fortæller om figur er grounded
	public bool Grounded;


	// Use this for initialization
	void Start () 
	{

		//figur sættes fra start til ikke at være grounded
		Grounded = false;
	}


	//Når Ground-objekt forlader triggerzone gøres figur ikke-grounded
    void OnTriggerExit2D (Collider2D col)
	{
		if (col.gameObject.tag == "Ground")
		{
			Grounded = false;
		}
	}

	//Når Ground-objekt befinder sig i triggerzone gøres figur grounded
    void OnTriggerStay2D (Collider2D col)
	{
		if (col.gameObject.tag == "Ground")
		{
			Grounded = true;
		}
	}

    void OnTriggerEnter2D (Collider2D col)
    {
        

    }

	
}
