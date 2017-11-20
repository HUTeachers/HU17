using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterRotation : MonoBehaviour { 


    public bool Controller;
    public bool Mouse;

    private float maxX = 60;

    private float x;
    private float y;

    Vector3 currentRotation;

    void Start()
    {
        currentRotation = transform.localEulerAngles;
        x = currentRotation.x;
        y = currentRotation.y;
    }

    // Update is called once per frame
    void Update () {

        if(Controller)
        {
            x += Input.GetAxis("ControllerY");
            x = Mathf.Clamp(x, -maxX, maxX);
            y += Input.GetAxis("ControllerX");
            transform.localEulerAngles = new Vector3(x, y, 0f);

        }
        if(Mouse)
        {
            x += Input.GetAxis("Mouse Y");
            x = Mathf.Clamp(x, -maxX, maxX);
            y -= Input.GetAxis("Mouse X");
            transform.localEulerAngles = new Vector3(x, y, 0f);
        }
        
	}

}
