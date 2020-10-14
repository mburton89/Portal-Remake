﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPortalGun : MonoBehaviour
{
    public AudioSource portalSound;
    public AudioSource errorSound;
    public GameObject orangePortal;
    public GameObject bluePortal;
    public GameObject firingPoint;

    // Update is called once per frame
    void Update()
    {
        // fire the right portal (left or right) based on input
        if (Input.GetMouseButtonDown(0))
        {
            FirePortal(true);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            FirePortal(false);
        }
    }

    void FirePortal(bool isOrange)
    {
        // struct object that will hold our raycast information
        RaycastHit hit;

        // if we collide with an object with our raycast, spawn a portal there
        if (Physics.Raycast(firingPoint.transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            portalSound.Play();

            // choose between the correct portals based on bool input
            if (isOrange)
            {
                // set the portal to the same position as the raycast point, and set
                // its rotation to orient to the wall relative to what its "up" direction is,
                // which is Vector.up in world space 
                orangePortal.transform.SetPositionAndRotation(hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
            }
            else
            {
                bluePortal.transform.SetPositionAndRotation(hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
            }
        }
        else
        {
            errorSound.Play();
        }
    }
}