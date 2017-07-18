using UnityEngine;
using System.Collections.Generic;
using System;

// Destruer objektet dette script ligger på når det bliver rørt af en spiller.
// Dette objekt kan være både trigger og normal collider. -  18-07-2017.

public class DestroyWhenHit : MonoBehaviour
{
    //Destruer hvis er objekt med tagget "Player" rammer det.
    public bool DestroyWhenPlayerHit = true;

    //Destruer objektet hvis det er er objekt med et tag fra listen, som rammer det.
    public bool DestroyWhenListHit = false;

    //Liste af strenge som destruerer dette objekt
    public List<string> stringsThatDestroyThis = new List<string>();


	// Bliver udført, når noget rammer objektet.
	void OnTriggerEnter2D (Collider2D collider)
	{
        //Hvis objektet kun skal destrueres ved at kollidere med spilleren.
        if(DestroyWhenPlayerHit)
        {
            // Vi tjekker om det er spilleren der kolliderer med objektet, før vi destruerer
            if (collider.gameObject.tag == "Player")
            {
                //Destruer dette objekt (som scriptet sidder på)
                Destroy (gameObject);
            }    
        }

        //Hvis objektet skal destrueres ved kollision med ethvert objekt, som har et tag fra listen stringsThatDestroyThis
        if(DestroyWhenListHit)
        {
            //Hvis det objekt vi kollidere med har et tag som er i listen
            if(stringsThatDestroyThis.Contains(collider.gameObject.tag))
            {
                //Destruer dette objekt (som scriptet sidder på)
                Destroy(gameObject);
            }
        }
	}

	//Fix så både trigger og normal collider er en mulighed.
	void OnCollisionEnter2D(Collision2D col)
	{
		OnTriggerEnter2D(col.collider);
	}

}
