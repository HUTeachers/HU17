using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	// Det objekt, der skal spawnes
	public GameObject spawnedObject;

	// Tidsrum mellem hvert spawn
	public float spawnInterval =2;

	// Stopur, som holder øje med tiden siden sidste spawn
	private float timer;


	void Start () {
	
	}
	

	void Update () {

		//Hvis timer er blevet større end spawnInterval, spawnes et object i spawnerens position. Og timer nulstilles	
		if (timer > spawnInterval)
		{
			Instantiate (spawnedObject, transform.position, Quaternion.identity);
			timer = 0;
		}

		// tiden siden sidste Update lægges til timer
		timer += Time.deltaTime;
	}
}
