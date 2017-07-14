using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SlutPoint : MonoBehaviour {

    public Text pointText;

	// Use this for initialization
	void Start ()
    {
        pointText = GameObject.FindWithTag("Points").GetComponent<Text>();

        GetComponent<Text>().text = "Du fik: " + pointText.text + " point";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
