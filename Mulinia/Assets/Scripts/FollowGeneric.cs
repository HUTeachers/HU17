using UnityEngine;
using System.Collections;

public class FollowGeneric : MonoBehaviour {

    //Hastigheden som objektet følger med
    public float speed;

    //'Transform' komponenten på målet. Denne indeholder målets position.
    public Transform targetTransform;

    //Denne variabel bruges til at udregne hvor objektetes næste position.
    private Vector2 tempPosition;

    // Use this for initialization
    void Start ()
    {

    }

    // Update is called once per framse
    void Update ()
    {
        Follow ();
    }

    private void Follow()
    {
        /*Vælger den næste position som er lidt tættere på spilleren. Med hastigheden speed.
          Vi ganger Time.deltaTime på speed for at gøre bevægelsen flydende og uafhængig af hvor god computeren er. */
        tempPosition = Vector2.MoveTowards (transform.position, targetTransform.position, speed * Time.deltaTime);
        transform.position = tempPosition;
    }
}
