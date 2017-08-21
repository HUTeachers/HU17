using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour {

	public SpriteRenderer playerSpriteRenderer;
	PlayerMovementSmooth playerMovementSmooth;

    public void StartFlicker(float flickertime)
	{
		StartCoroutine(Flick(flickertime));
	}

	IEnumerator Flick(float flickertime)
	{
        //playerSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
		playerMovementSmooth = GetComponent<PlayerMovementSmooth>();

		float timestamp = Time.timeSinceLevelLoad;

		do
		{
			playerSpriteRenderer.enabled = !playerSpriteRenderer.enabled;
			yield return new WaitForSeconds(0.1f);
		} while (timestamp + flickertime > Time.timeSinceLevelLoad);

		playerSpriteRenderer.enabled = true;
		playerMovementSmooth.enabled = true;

		//Destroy(this); //Removes this component.
	}

}
