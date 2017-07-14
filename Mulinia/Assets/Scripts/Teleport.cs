using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D (Collider2D Spiller){
		// Spiller ændrer position i x og y retningen
		if (Spiller.gameObject.tag == "Spiller") {
			Spiller.transform.Translate (-1f, 1, 0, Space.World);
		}
	}
	// Update is called once per frame
	void Update () {
	


	}
}
