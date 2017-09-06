using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LivUI : MonoBehaviour {

    //Spillerens figur
    private GameObject spiller;

	//Scriptet på spilleren der holder styr på liv
	private Health liv;

    //Grafikken der ændre sig når spilleren mister liv
    public Image livGrafik;

    //Farverne som liv grafikken skal have ved fuldt liv og intet liv
    public Color fuldtLiv;
    public Color ingenLiv;

    //Teksten der står inde i liv grafikken der viser spillerens liv i tal
    public Text livText;

    //Hvor meget liv spilleren maksimalt kan have
    private float maksLiv;


	void Start ()
    {
        //Find spilleren ud fra tagget Player
        spiller = GameObject.FindWithTag("Player");
        //Find Health scriptet som er på spilleren
        liv = spiller.GetComponent<Health>();
        //Find grafikken som er på det objekt dette script er på
        livGrafik = GetComponent<Image>();
        //Finder det objekt der skriver tekst for hvor meget liv spilleren har
        livText = GetComponentInChildren<Text>();

        //Sæt farven i liv grafikken til fuldt liv
        livGrafik.color = fuldtLiv;
        //Sætter værdien for hvad det maksimale liv spilleren kan have til spillerens start liv
        maksLiv = liv.HealthValue;

    }
	
	void Update ()
    {
        //Ændre størrelsen på liv grafikken alt efter hvor meget liv man har
        livGrafik.fillAmount = liv.HealthValue / maksLiv;
        //Ændre farven på liv grafikken alt efter hvor meget liv man har
        livGrafik.color = Color.Lerp(ingenLiv, fuldtLiv, livGrafik.fillAmount);
        //Indsætter hvor meget liv spilleren har i et tekstfelt midt i grafikken
        livText.text = liv.HealthValue.ToString();

	}
}
