using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opg1 : MonoBehaviour {

    string opgaveStreng = "Hejsa!";

    /// <summary>
    /// Opgave!
    /// Få unity til at skrive at Din besked er: Pizza
    /// </summary>
	void Start () {
        opgaveStreng = "Pizza!";
        print("Din besked er: Pizza");
        print("Din besked er: " + opgaveStreng); // <--
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
