using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum SoundEnum
{
    OnCollision,
    OnTrigger,
    OnActivate
}

public class PlaySoundOn : MonoBehaviour {

    public SoundEnum soundEnum;

    AudioSource aSource;

	// Use this for initialization
	void Start () {
        aSource = GetComponent<AudioSource>();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(soundEnum == SoundEnum.OnCollision)
        {
            aSource.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (soundEnum == SoundEnum.OnTrigger)
        {
            aSource.Play();
        }
    }

    private void Awake()
    {
        if (soundEnum == SoundEnum.OnActivate)
        {
            aSource.Play();
        }
    }
}
