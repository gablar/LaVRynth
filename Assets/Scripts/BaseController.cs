﻿using UnityEngine;
using System.Collections;
using UnityEngine.VR;
using System;

public class BaseController : MonoBehaviour {
    public bool isPaused;
    public Transform OVRCamera;
    public float xMult;
    public float zMult;
    float lastRot;
    Vector3 initRot;

    Vector3 origCenterAngle;


    // Use this for initialization
    void Start () {
       

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (isPaused) { } else
        {
            CameraToTableRot();

        }


    }


    private void CameraToTableRot()
    { 
        Vector3 centerAngle = OVRCamera.eulerAngles;
        float xEuAngle = centerAngle.x - origCenterAngle.x;
        float zEuAngle = centerAngle.z - origCenterAngle.z;
        Vector3 euAngle = new Vector3(xEuAngle*xMult,0,zEuAngle);
        //Vector3 thisRot = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(initRot + euAngle);

        //transform.rotation = Quaternion.Euler(xEuAngle * xMult, 0, zEuAngle * zMult);
    }

    public void Pause() {
        isPaused = true;
    }

    public void UnPause()
    {
        isPaused = false;
        origCenterAngle = OVRCamera.eulerAngles;
        initRot = transform.rotation.eulerAngles;

    }
}
