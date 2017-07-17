﻿using UnityEngine;
using System.Collections;

public class KnockBack : MonoBehaviour {

    //Indikere om man vil skubbes tilbage i henholdsvis x og y aksen
    public bool y;
    public bool x;


    //Indikere om man vil blinke når man tager skade
    public bool DamageFlicker;

    //Indikere hvor meget kraft man skubbes med i X og Y aksen
    public float PowerY = 12f;
    public float PowerX = 12f;

    //Hvor længe man ikke kan styre sin spiller når man tager skade
    public float DisableTime = 1f;

    // referencer til playermovement og spriterenderen.
    private PlayerMovementSmooth playerMovementSmooth;
    private SpriteRenderer playerSpriteRenderer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //når noget colliderer med det her objekt bliver det betegnet "ting"
    private void OnCollisionEnter2D(Collision2D ting)
    {
        //Hvis "other" har et tag, der hedder "Player". bliver spilleren skubbet op!
        if (ting.gameObject.tag == "Player")
        {
            
            StartCoroutine(KnockUp(DisableTime, ting));

            //ting.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(x ? PowerX : 0f, y ? PowerY : 0f), ForceMode2D.Impulse);
        }
    }

    IEnumerator KnockUp(float waittime, Collision2D col)
    {
        Vector2 velocity = new Vector2();
        if (x)
        {
            velocity.x = PowerX;
        }

        if (y)
        {
            velocity.y = PowerY;
        }

        col.gameObject.GetComponent<Rigidbody2D>().AddForce(velocity, ForceMode2D.Impulse);

        //Lille trick så man ikke overføre en reference hver gang man kolidere med den samme spike
        if(playerMovementSmooth == null)
            playerMovementSmooth = col.gameObject.GetComponent<PlayerMovementSmooth>();
        if (playerSpriteRenderer == null)
            playerSpriteRenderer = col.gameObject.GetComponent<SpriteRenderer>();

        playerMovementSmooth.enabled = false;
        
        //hvis man har indikeret at man vil blinke når man tager skade, så blinker man. 
        if(DamageFlicker)
            StartCoroutine(Flicker());

        yield return new WaitForSeconds(waittime);
        playerMovementSmooth.enabled = true;

    }

    IEnumerator Flicker()
    {
        do
        {
            playerSpriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.1f);
            playerSpriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.1f);
        } while (!playerMovementSmooth.enabled);

    }



}