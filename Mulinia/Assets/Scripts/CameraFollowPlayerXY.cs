using UnityEngine;
using System.Collections;

public class CameraFollowPlayerXY : MonoBehaviour {

	//Dette script sættes på main camera og får kameraet til på x-aksen at følge spillerfigur

	public GameObject Player;

    public bool lockX;
    public bool lockY;

	private float playerX;
    private float playerY;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (lockX)
            playerX = transform.position.x;
        else if(!lockX)
		    playerX = Player.transform.position.x;
        if (lockY)
            playerY = transform.position.y;
        else if(!lockY)
            playerY = Player.transform.position.y;

		transform.position = new Vector3 (playerX, playerY, transform.position.z);

	}
}
