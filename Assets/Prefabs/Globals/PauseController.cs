﻿using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour {
    public bool isPaused =true;
    public BaseController basController;
    private Rigidbody tableRGB;
    GameObject ball;
    private Vector3 ballVelocity;
    Rigidbody ballRGB;
    // Use this for initialization
    void Start () {
        isPaused = true;
        basController.Pause();
        ball = GameObject.FindGameObjectWithTag("ball");
        ballRGB = ball.GetComponent<Rigidbody>();
        ballVelocity = ballRGB.velocity;
        ballRGB.velocity = Vector3.zero;
        ballRGB.isKinematic = false; ;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isPaused)
            {
                //pause
                isPaused = true;
                basController.Pause();
                ball = GameObject.FindGameObjectWithTag("ball");
                ballRGB = ball.GetComponent<Rigidbody>();
                //ballVelocity = ballRGB.velocity;
                // ballRGB.velocity = Vector3.zero;
                //ballRGB.isKinematic = false;
                ballRGB.constraints = RigidbodyConstraints.FreezeAll;

            }
            else
            {
                isPaused = false;
                basController.UnPause();
                //ballRGB.isKinematic = false;
                ballRGB.constraints = RigidbodyConstraints.None;

                //ballRGB.velocity = ballVelocity;
            }
        }
	}
}
