using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public interface IWhippable
{
    void Whipped();
}


public class Whip : MonoBehaviour {

	public float WhipCoolDown = 0.3f;

	bool facingLeft = false;
	bool attacking = false;

	SpriteRenderer sr;

	List<GameObject> whiplist;
	public float whiplength = 2f;


	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
		whiplist = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {

		UpdateFacing(ref facingLeft);

		if (Input.GetButtonDown("Fire1") && !attacking) //left ctrl or mouse 0
		{
			
			StartCoroutine(Attack());
		}
	}

	//Trick: this will only change if horizontal is not excactly zero, if horizontal is zero, the facing will stay the same.
	void UpdateFacing(ref bool input)
	{
		if(Input.GetAxis("Horizontal") < 0)
		{
			input = false;
		}
		else if (Input.GetAxis("Horizontal") > 0)
		{
			input = true;
		}
	}

	IEnumerator Attack()
	{
		SetWhipping(true);

		//Moves the whip one tile to the side, depending on what side you were last moving.
		Vector3 temp = new Vector3(transform.localPosition.x - whiplength, transform.localPosition.y, transform.localPosition.z);
		if (facingLeft)
		{
			temp.x += whiplength * 2f;
		}

		//Move the whip
		transform.localPosition = temp;


		WhipRayCast(temp);
		CollisionHandler();

		yield return new WaitForSeconds(WhipCoolDown);
		//Move whip back, enable attack again.
		SetWhipping(false);
		transform.localPosition = Vector3.zero;
	}

	private void WhipRayCast(Vector3 temp)
	{

		//Get everything we whip.

		RaycastHit2D[] collidersHigh = Physics2D.RaycastAll(new Vector2(transform.parent.position.x, transform.position.y + 0.2f), new Vector2(temp.x, temp.y), whiplength + 0.5f);
		RaycastHit2D[] collidersLow = Physics2D.RaycastAll(new Vector2(transform.parent.position.x, transform.position.y - 0.2f), new Vector2(temp.x, temp.y), whiplength + 0.5f);

		whiplist.AddRange(collidersHigh.Select(x => x.collider.gameObject));
		whiplist.AddRange(collidersLow.Select(x => x.collider.gameObject).Where(x => !whiplist.Contains(x)).ToList());

	}

	private void CollisionHandler()
	{
		foreach (GameObject item in whiplist)
		{
			IWhippable[] temp = item.GetComponents<IWhippable>();
            if(temp.Length != 0)
			{
                foreach (var whipInterface in temp)
                {
                    whipInterface.Whipped();
                }
			}
		}

		whiplist = new List<GameObject>(); //Purge.
	}

	private void SetWhipping(bool state)
	{
		attacking = state;
		sr.enabled = state;
	}

}


