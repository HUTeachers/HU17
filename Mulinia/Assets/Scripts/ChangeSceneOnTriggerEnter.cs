using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeSceneOnTriggerEnter : MonoBehaviour
{
	public string requiredTag;
	public string sceneName;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag(requiredTag))
		{
			SceneManager.LoadScene (sceneName);
		}
	}
}
