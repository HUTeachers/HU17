using UnityEngine;
using System.Collections;

public class WallJump : MonoBehaviour
{
	public string wallTag;
	public Vector2 jumpPower;

	private Rigidbody2D rbd;

	void Start()
	{
		rbd = GetComponent<Rigidbody2D> ();
	}

	void OnTriggerStay2D(Collider2D collider)
	{
		if(collider.CompareTag(wallTag))
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				rbd.AddForce (jumpPower);
			}
		}
	}
}
