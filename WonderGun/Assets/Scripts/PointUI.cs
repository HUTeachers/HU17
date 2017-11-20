using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointUI : MonoBehaviour {

    public Text pointGrafik;

    public GameObject spiller;

    public PointCounter point;

	// Use this for initialization
	void Start ()
    {
        pointGrafik = GetComponent<Text>();
        spiller = GameObject.FindWithTag("Player");
        point = spiller.GetComponent<PointCounter>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        pointGrafik.text = point.GetScore().ToString();
	}
}
