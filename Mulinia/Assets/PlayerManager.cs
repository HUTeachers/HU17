using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
	OnGround,
	OnLadder,
	Jumping
}


public class PlayerManager : MonoBehaviour {

	public State PlayerState;

	private Jump jump;
	private PlayerMovementSmooth pms;
	private GroundCheck gc;
	private Climb climb;
	private LadderMovement lame;


	private BoxCollider2D playerCollider;


	// Use this for initialization
	void Start () {

		PlayerState = State.OnGround;

		jump = GetComponent<Jump>();
		pms = GetComponent<PlayerMovementSmooth>();
		gc = GetComponentInChildren<GroundCheck>();
		climb = GetComponent<Climb>();
		lame = GetComponent<LadderMovement>();

		playerCollider = GetComponent<BoxCollider2D>();

	}
	
	// Update is called once per frame
	void Update () {

		State inputState = PlayerState;

		if (climb.climbing)
		{
			PlayerState = State.OnLadder;
			
		}
		else if(!gc.Grounded)
		{
			PlayerState = State.Jumping;
		}
		else
		{
			PlayerState = State.OnGround;
		}

		if(inputState != PlayerState)
		{
			UpdateState(PlayerState);
        }
		

	}

	void UpdateState(State input)
	{
		switch (input)
		{
			case State.OnGround:
				pms.enabled = true;
				lame.enabled = false;
				playerCollider.isTrigger = false;
				pms.UnFreeze();
				break;
			case State.OnLadder:
				pms.Freeze(); // Removes all inertia from the rigidbody
				pms.enabled = false;
				lame.enabled = true;
				playerCollider.isTrigger = true; // Walk through floors, yep.
                break;
			case State.Jumping:
				pms.enabled = true;
				lame.enabled = false;
				playerCollider.isTrigger = false;
				pms.UnFreeze();
				break;
			default:
				break;
		}

	}
}
