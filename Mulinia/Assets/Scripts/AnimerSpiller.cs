using UnityEngine;
using System.Collections;

public class AnimerSpiller : MonoBehaviour {

    public SpriteRenderer spillersSprite;

    public Sprite[] figurBilleder;
    public Sprite[] hoppeBilleder;

    public float currentSprite = 1;
    public float speed;
    public float jumpSpeed;

    private bool inJump;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKey(KeyCode.RightArrow) && !inJump)
        {
            spillersSprite.flipX = false;
            currentSprite += Time.deltaTime * speed;
            if (currentSprite >= figurBilleder.Length)
            {
                currentSprite = 0;
            }
            spillersSprite.sprite = figurBilleder[(int)currentSprite];

        }

        if (Input.GetKey(KeyCode.LeftArrow) && !inJump)
        {
            spillersSprite.flipX = true;
            currentSprite += Time.deltaTime * speed;
            if (currentSprite >= figurBilleder.Length)
            {
                currentSprite = 0;
            }
            spillersSprite.sprite = figurBilleder[(int)currentSprite];

        }

        if(!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && !inJump)
        {
            currentSprite = 1;
            spillersSprite.sprite = figurBilleder[(int)currentSprite];
        }

        if(Input.GetKey(KeyCode.Space) && !inJump)
        {
            StartCoroutine(jumpCycle(jumpSpeed));
        }
    }

    public IEnumerator jumpCycle(float jumpSpeed)
    {
        inJump = true;
        foreach (Sprite s in hoppeBilleder)
        {
            spillersSprite.sprite = s;
            yield return new WaitForSeconds(Time.deltaTime / jumpSpeed);
        }

        inJump = false;
    }
}
