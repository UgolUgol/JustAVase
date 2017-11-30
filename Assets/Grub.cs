using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Grub : MonoBehaviour {

    public float grabPower = 10.0f;
    public float throwPower = 50;
    private RaycastHit hit;
    public float rayDistance = 3.0f;
    private bool Grab = false;
    private bool Throw = false;
    public Transform offset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var mainCamera = FindCamera();
        if (Input.GetMouseButtonDown(1))
        {
            Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition).origin, 
                mainCamera.ScreenPointToRay(Input.mousePosition).direction, 
                out hit, rayDistance);
            if (hit.rigidbody)
            {
                Grab = true;
            }
        }
        if(Input.GetMouseButton(0))
        {
            if(Grab)
            {
                Grab = false;
                Throw = true;
            }
        }
        if (Grab && hit.rigidbody)
        {
            hit.rigidbody.velocity =  (offset.position - (hit.transform.position + hit.rigidbody.centerOfMass)) * grabPower;
        }
        if(Throw && hit.rigidbody)
        {
            hit.rigidbody.velocity = transform.forward * throwPower;
            Throw = false;
        }
	}


    private Camera FindCamera()
    {
        if (GetComponent<Camera>())
        {
            return GetComponent<Camera>();
        }

        return Camera.main;
    }
}
