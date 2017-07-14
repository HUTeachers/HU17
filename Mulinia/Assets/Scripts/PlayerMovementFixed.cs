using UnityEngine;
using System.Collections;

public class PlayerMovementFixed : MonoBehaviour {

    public int stepSize = 1;

    public bool X;
    public bool Y;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Quaternion tempRotation = transform.rotation;

        //checks for movement along the X axis if this is allowed
        if(X)
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                tempRotation.eulerAngles = new Vector3(0,0,0);
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                tempRotation.eulerAngles = new Vector3(0,0,180);
            }

        }
        //Checks for movement along the y axis if this is allowed
        if(Y)
        {

            if (Input.GetAxisRaw("Vertical") > 0)
            {
                tempRotation.eulerAngles = new Vector3(0,0,90);
            }
            else if (Input.GetAxisRaw("Vertical") < 0)
            {
                tempRotation.eulerAngles = new Vector3(0,0,270);
            }
        }

        if (X || Y)
        {
            //Checks if a wall is in the way. Use layercollision if the player can move over specific objects, but must collide with others
            //Layer collision can be set in Edit -> Project settings -> Physics 2D, or through code which is more complicated.
            //To have this method working, you need to have "Queries start in colliders" disabled. Go to Edit -> Project settings -> Physics 2D
            if (!Physics2D.Raycast(transform.position, Vector2.right, 1.0f))
            {
                if ( X && Input.GetButtonDown("Horizontal") || Y && Input.GetButtonDown("Vertical"))
                {
                    transform.Translate(tempRotation * Vector3.right * stepSize );
				}
            }
        }
		else
		{
			throw new System.Exception("Neither X or Y enabled, correct this");
		}

    }
}
