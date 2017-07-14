using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Text tid;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		print ((int)Time.realtimeSinceStartup);
		tid.text = "Tid: " + Time.realtimeSinceStartup.ToString("F0");
	}

}
