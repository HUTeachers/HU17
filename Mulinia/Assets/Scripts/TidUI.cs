using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TidUI : MonoBehaviour {

    public Text tidGrafik;

    public bool taelOp;

    public float sekunder;

	// Use this for initialization
	void Start ()
    {
        tidGrafik = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(taelOp == false)
        {
            tidGrafik.text = sekunder.ToString("F0");
            sekunder -= Time.deltaTime;

            if(sekunder <= 0)
            {
                SceneManager.LoadScene("Lose");
            }
        }

        if(taelOp == true)
        {
            tidGrafik.text = Time.timeSinceLevelLoad.ToString("F0");

            if(Time.timeSinceLevelLoad >= sekunder)
            {
                SceneManager.LoadScene("Lose");
            }
        }
	}
}
