using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenWhipped : MonoBehaviour, IWhippable {
	public void Whipped()
	{
		Destroy(gameObject);
	}
}
