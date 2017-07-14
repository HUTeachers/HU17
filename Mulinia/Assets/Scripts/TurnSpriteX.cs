using UnityEngine;
using System.Collections;

public class TurnSpriteX : MonoBehaviour
{
    float lastX;

    // Use this for initialization
    void Start()
    {
        lastX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 scale = transform.localScale;

        if(lastX < transform.position.x)
        {
            if(scale.x < 0)
            {
                scale.x *= -1;
            }
        }
        else if (lastX > transform.position.x)
        {
            if (scale.x > 0)
            {
                scale.x *= -1; 
            }
        }

        transform.localScale = scale;

        lastX = transform.position.x;
    }
}
