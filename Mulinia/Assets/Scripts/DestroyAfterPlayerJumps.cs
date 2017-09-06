using UnityEngine;
using System.Collections;

public class DestroyAfterPlayerJumps : MonoBehaviour {

    private float disappearTime = 0f;

    public int Touches = 1;
    public float DisappearDelay = 5f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    if(disappearTime != 0f)
        {
            if(Time.timeSinceLevelLoad > disappearTime+DisappearDelay)
            {
                gameObject.SetActive(false);
            }
        }


	}

    void OnCollisionExit2D(Collision2D Col)
    {
        //Tjekker efter tagget player og fjerner et touch
        if (Col.gameObject.tag == "Player" && Touches > 0)
        {
            Debug.Log("Ill Disappear soon!");
            disappearTime = Time.timeSinceLevelLoad;
            Touches--;
        }
        else if(Touches <= 0 )
        {
            gameObject.SetActive(false);
        }
    }

}
