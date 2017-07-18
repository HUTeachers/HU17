using UnityEngine;
using System.Collections;

public class RoofCheck : MonoBehaviour {

    //fortæller om figur er Roofed
    public bool Roofed;

    // Use this for initialization
    void Start () {
        //Ikke i loftet til at starte med.
        Roofed = false;
	}
	

    void OnTriggerExit2D(Collider2D Col)
    {
        //Tjekker efter tagget roof
        if(Col.gameObject.tag == "Roof")
        {
            Roofed = false;
        }
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        //Tjekker efter tagget roof
        if (col.gameObject.tag == "Roof")
        {
            Roofed = true;
        }
    }
}
