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
	private Climb climb;
	private LadderMovement lame;

	private GroundCheck gc;
	private Whip whip;

	private BoxCollider2D playerCollider;


	// Use this for initialization
	void Start () {

		PlayerState = State.OnGround;

		jump = GetComponent<Jump>();
		pms = GetComponent<PlayerMovementSmooth>();
		climb = GetComponent<Climb>();
		lame = GetComponent<LadderMovement>();

		whip = GetComponentInChildren<Whip>();
		gc = GetComponentInChildren<GroundCheck>();

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
			UpdateState(PlayerState, inputState);
        }
		

	}

	void UpdateState(State playerState, State prevState)
	{
		switch (playerState)
		{

			case State.OnGround:
				UnLadderSet();
                break;
			case State.OnLadder:
				LadderSet();
                //Moves the player down the ladder.
				if (prevState == State.OnGround && Input.GetAxis("Vertical") < 0)
					transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
				break;
			case State.Jumping:
				UnLadderSet();
                break;
			default:
				break;
		}

	}

	void LadderSet()
	{
		pms.Freeze(); // Removes all inertia from the rigidbody
		pms.enabled = false;
		lame.enabled = true;
		Physics2D.SetLayerCollisionMask(LayerMask.NameToLayer("Ground"), 0); //Ground collider nu ikke længere med player

	}

	void UnLadderSet()
	{
		pms.enabled = true;
		lame.enabled = false;
        climb.climbing = false;
		pms.UnFreeze();
		Physics2D.SetLayerCollisionMask(LayerMask.NameToLayer("Ground"), -1); // -1 collide med alting.
	}
}
