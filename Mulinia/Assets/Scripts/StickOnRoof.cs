using UnityEngine;
using System.Collections;

public class StickOnRoof : MonoBehaviour {
    private RoofCheck RoofCheck;
    private Rigidbody2D rb2d;

    // Use this for initialization
	void Start () {

        //Finder roofchecket og rigidbodien.
        RoofCheck = GetComponentInChildren<RoofCheck>();
        rb2d = GetComponent<Rigidbody2D>(); 
    }
	
	// Update is called once per frame
	void Update () {
        //Tjekker om du er roofed lige nu
	    if(RoofCheck.Roofed)
        {
            rb2d.gravityScale = 0f;
        }
        
        //tjekker om du  giver slip på loftet
        if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            rb2d.gravityScale = 1f;
            RoofCheck.Roofed = false;
        }
            
        
	}
}
