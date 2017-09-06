using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	[Header("Remember to add scenes using ctrl + shift + b")]
	public string sceneName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
    }

	public void LoadScene()
	{
		SceneManager.LoadScene (sceneName);
	}
}
