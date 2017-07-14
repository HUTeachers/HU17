using UnityEngine;
using System.Collections;

public class PlayerMovementRotate : MonoBehaviour {
	//Dette script lader spilleren styre figurens bevægelser med piletaster eller med adsw

	//MoveSpeed styrer hastigheden af spillerens bevægelse
	public float moveSpeed = 5;
    public float rotationAmount = 5;

    float movement;



	// Update is called once per frame
	void FixedUpdate () {

        movement = moveSpeed * Input.GetAxis("Vertical");
			
        transform.Rotate(new Vector3(0, 0, -rotationAmount*Input.GetAxis("Horizontal")));
        Rigidbody2D rgdbdy = gameObject.GetComponent<Rigidbody2D>();
        rgdbdy.velocity = transform.right * movement;

	}
	
}