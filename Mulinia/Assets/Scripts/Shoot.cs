using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{

	public GameObject BulletPrefab;

	public float BulletSpeed = 5f;

	public bool SkydModMusen = true;
	public bool SkydFremad = false;

	private Vector2 bulletDirection;


	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (Input.GetMouseButtonDown (0) && SkydModMusen) {
			Vector2 mussePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			ShootBullet (mussePosition);
		} else if (Input.GetMouseButtonDown (0) && SkydFremad) {
			Vector2 Fremadposition = transform.forward;
			ShootBullet (Fremadposition);
		}
	}

	void ShootBullet (Vector2 imodPosition)
	{
		Vector2 minPosition = transform.position;

		bulletDirection = imodPosition - minPosition;
		bulletDirection.Normalize ();

		GameObject clone = Instantiate (BulletPrefab, minPosition + bulletDirection, Quaternion.identity) as GameObject;
		clone.GetComponent<Rigidbody2D> ().velocity = bulletDirection * BulletSpeed;

	}
}
