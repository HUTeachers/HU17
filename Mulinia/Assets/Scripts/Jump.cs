using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {
	//Dette script lader spilleren hoppe med figuren.
	//Figuren SKAL have child: et empty object med trigger collider og scriptet "GroundCheck"
	//De ting, figuren skal kunne hoppe på, skal have et tag kaldet "Ground"

	//Her vælger man, om der kan hoppes i luften


	//Den kraft man hopper med
	public float JumpPower = 6f;
   
    public int JumpCount = 1;

    int remainingJumps;

	//det script på ground trigger (child), som undersøger om figuren er grounded
	private GroundCheck groundCheck;



	// Use this for initialization
	void Start () {
		//finder scriptet GroundCheck, så det kan undersøges om figuren er grounded
		groundCheck = gameObject.GetComponentInChildren <GroundCheck>();

        //Debug.Log(groundCheck.ToString());
        remainingJumps = JumpCount;
	}


	// Update is called once per frame
	void Update () {


        if (groundCheck.Grounded)
        {
            remainingJumps = JumpCount;
        }
		//Hvis der trykkes Space OG figuren er enten grounded, klar til doublejump eller multijump er tilsluttet, skal figuren hoppe
        if (Input.GetKeyDown(KeyCode.Space) && remainingJumps > 0)
		{
			//Ændrer figurens hastighed: x beholdes, y sættes til JumpPower, z sættes til 0
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpPower), ForceMode2D.Impulse);


            remainingJumps--;


		}


	
	}
}
