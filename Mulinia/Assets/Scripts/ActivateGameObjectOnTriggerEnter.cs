using UnityEngine;
using System.Collections;

public class ActivateGameObjectOnTriggerEnter : MonoBehaviour, IWhippable
{
	
	//Det tag som objektet skal have for at kunne aktivere triggeren
	[Header("Som regel 'Player'")]
	public string requiredTag;

	//Det gameobject som bliver aktiveret
	public GameObject activatableObject;

    //Skal objektet aktiveres (activate = true) eller deaktiveres?
	[Header("Skal objektet aktiveres når eventet sker? Ellers deaktiveres det.")]
	public bool activate = true;

	//Gå tilbage på exit?
	[Header("Hvis der er et flueben, går gameobjektet tilbage til sådan det var før triggeren")]
	public bool revert;

    //Kan man bruge pisken i stedet?
    [Header("Kan man aktivere denne med pisken?")]
    public bool whippable;

    [Header("Skal man KUN kunne bruge pisken=")]
    public bool whipOnly = false;

    public void Whipped()
    {
        if(whippable)
        {
            activatableObject.SetActive(activate);

            if(revert)
            {
                //Revert efter 0.5 sekunder.
                StartCoroutine(WhipRevert(0.5f));
            }
        }
    }


	void OnTriggerEnter2D(Collider2D other)
	{
        if(other.CompareTag(requiredTag) && !whipOnly)
		{
			activatableObject.SetActive (activate);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.CompareTag(requiredTag) && revert)
		{
			activatableObject.SetActive (!activate);

		}
	}

    //Efter delay tid skal revert ske.
    IEnumerator WhipRevert(float delay)
    {
        yield return new WaitForSeconds(delay);
        activatableObject.SetActive(!activate);
    }
}
