using UnityEngine;
using System.Collections;

public class CameraFollowPlayerX : MonoBehaviour {

	//Dette script sættes på main camera og får kameraet til på x-aksen at følge spillerfigur

	public GameObject Player;
	private float playerX;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		playerX = Player.transform.position.x;
		transform.position = new Vector3 (playerX, transform.position.y, transform.position.z);

	}
}
