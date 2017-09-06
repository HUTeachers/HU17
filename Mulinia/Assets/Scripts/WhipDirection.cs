using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipDirection : MonoBehaviour
{
    //Reference til spillerens graphics transform.
    private Transform graphicsTransform;

    //Whippens sprite
    private SpriteRenderer whipRenderer;

    [Header("Check denne boks af hvis spriten vender modsat")]
    public bool useDifferentDirection;

    private float baseScale;

    void Start()
    {
        baseScale = transform.localScale.x;
        whipRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 scale = transform.localScale;


        if(!useDifferentDirection)
        {
            if(transform.localPosition.x > 0)
            {
                scale.x = baseScale;
            }
            else
            {
                scale.x = baseScale * -1;
            }
        }
        else
        {
            if(transform.position.x > 0)
            {
                scale.x = baseScale * -1;
            }
            else
            {
                scale.x = baseScale;
            }
        }


        transform.localScale = scale;
    }
}
