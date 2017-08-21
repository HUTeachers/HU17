using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour, IWhippable {

	public GameObject Door;

	[Header("Show where the switch is connected.")]
	public bool DebugLine = false;

	public void Whipped()
	{
		Door.SetActive(false);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(DebugLine)
		{
			Debug.DrawLine(transform.position, Door.transform.position);
		}
	}
}
