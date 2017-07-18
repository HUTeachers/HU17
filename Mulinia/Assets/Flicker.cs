using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour {

	SpriteRenderer playerSpriteRenderer;
	PlayerMovementSmooth playerMovementSmooth;

	void OnDestroy()
	{
		Debug.Log("You have met with a terrible fate, haven't you?");
	}

	public void StartFlicker(float flickertime)
	{
		StartCoroutine(Flick(flickertime));
	}

	IEnumerator Flick(float flickertime)
	{
		playerSpriteRenderer = GetComponent<SpriteRenderer>();
		playerMovementSmooth = GetComponent<PlayerMovementSmooth>();

		float timestamp = Time.timeSinceLevelLoad;

		do
		{
			playerSpriteRenderer.enabled = !playerSpriteRenderer.enabled;
			yield return new WaitForSeconds(0.1f);
		} while (timestamp + flickertime > Time.timeSinceLevelLoad);

		playerSpriteRenderer.enabled = true;
		playerMovementSmooth.enabled = true;

		Destroy(this); //Removes this component.
	}

}
