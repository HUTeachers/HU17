using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PointCounter : MonoBehaviour {
	//Scriptet holder styr på point
	
	
	//siger at vi skal have en variabel for hele tal, som kaldes "Score"
	public int score;
	
	//antal point der skal til for at vinde spillet
	public int WinValue = 1000;
	
		
	// void Start køres når scenen startes (og kun der)
	void Start () {
		
		//Score sættes fra start til 0
		score = 0;
		
	}
	
	
		
	//void Update: Hver gang der tegnes et nyt billede
	void Update () {
	
		//Hvis antal point er større eller lig med WinValue går spillet videre til scenen "Win"
		if (score >= WinValue)
		{
			SceneManager.LoadScene ("Win");
		}
	}
	
	
	// modtager point værdier fra andre objekter, lægger point til PointValue
	public void ReceivePoints (int points) 
	{
		score = score + points;
	}

}
