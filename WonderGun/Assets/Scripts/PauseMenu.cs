using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public KeyCode pauseKey = KeyCode.Escape;
	public GameObject pauseOverlay;

	
	private bool paused = false;

	void Start ()
	{
		pauseOverlay.SetActive(false);
		
	}
	
	void Update ()
	{
		PauseHandler();
		
	}

	private void PauseHandler()
	{
		if (Input.GetKeyDown(pauseKey))
		{
			if (paused)
			{
                paused = false;
				Time.timeScale = 1.0f;

				pauseOverlay.SetActive(paused);
				print("Unpaused");
			}
			else
			{
				Time.timeScale = 0.0f;
                paused = true;
				pauseOverlay.SetActive(paused);
				
				print("Paused");
			}

		}
		
	}
}
