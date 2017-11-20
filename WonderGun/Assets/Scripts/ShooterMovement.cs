using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterMovement : MonoBehaviour
{

    //reference to rigidbody
    Rigidbody rb;

    //Handles applying force to the body
    Vector3 forceVector;

    public bool flipXZ;
    public float ForceAmp = 0.6f;

    // Use this for initialization
    void Start()
    {
        //Get the reference
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (flipXZ)
        {
            forceVector = new Vector3(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
        }
        else
        {
            forceVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        }

        float forceComp = Mathf.Abs(forceVector.x) + Mathf.Abs(forceVector.z);

        //force
        if (forceComp < 0.1f)
        {
            rb.velocity *= 0.9f;

        }
        else
        {
            if (Mathf.Abs(rb.velocity.x) > 0.2f && !TivityCheck(rb.velocity.x, forceVector.x))
            {
                rb.velocity = new Vector3(rb.velocity.x * 0.8f, rb.velocity.y, rb.velocity.z);
            }

            if (Mathf.Abs(rb.velocity.z) > 0.2f && !TivityCheck(rb.velocity.z, forceVector.z))
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z * 0.8f);
            }

        }
        rb.AddForce(forceVector * ForceAmp, ForceMode.Impulse);



    }
    private bool TivityCheck(float a, float b)
    {
        return a > 0 && b > 0 || a < 0 && b < 0;
    }
}

