using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerCameraFollow : MonoBehaviour {

    private GameObject player;
    private Vector3 veloc;

    public Vector3 offset = new Vector3(0f, 5f, -10f);

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + offset, ref veloc, 0.5f);
	}
}
