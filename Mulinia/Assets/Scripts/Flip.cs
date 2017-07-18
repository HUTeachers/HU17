using UnityEngine;
using System.Collections;

public class Flip : MonoBehaviour {

	public float upAmount;
	public float flipAmount;

    private Rigidbody2D rb2d;

	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
	{


		if(Input.GetKeyDown(KeyCode.Space))
		{
			rb2d.AddForce (Vector2.up);

			StartCoroutine (Flipper ());
		}
	}

	private IEnumerator Flipper()
	{
		yield return new WaitForSeconds (0.1f);
		rb2d.AddTorque (flipAmount);
	}
}
