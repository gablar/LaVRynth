using UnityEngine;
using System.Collections;
using System;

public class PauseController : MonoBehaviour {
    
    public bool isPaused = true;

    //Base
    public BaseController basController;
   

    //ball
    GameObject ball;
    Rigidbody ballRGB;

    //UI
    public BallGeneratorController ballGen;
    // Use this for initialization
    void Start () {
        basController = GameObject.Find("base").GetComponent<BaseController>();
        ballGen = GameObject.Find("BallGeneratorInteractable").GetComponent<BallGeneratorController>();
        OVRTouchpad.Create();
        OVRTouchpad.TouchHandler += HandleTouchHandler;

        if (isPaused) PauseGame(); else UnPauseGame();
    }

    private void HandleTouchHandler(object sender, EventArgs e)
    {
        OVRTouchpad.TouchArgs touchArgs = (OVRTouchpad.TouchArgs)e;
        OVRTouchpad.TouchEvent touchEvent = touchArgs.TouchType;
        if(touchArgs.TouchType == OVRTouchpad.TouchEvent.SingleTap)
        {
            if (!isPaused)
            {
                //pause
                PauseGame();

            }
            else
            {
                UnPauseGame();
            }
        }

    }

    // Update is called once per frame
    void Update () {
	}

    private void UnPauseGame()
    {
        isPaused = false;

        //unfreezebase
        basController.UnPause();

        //unfreezeball
        ballRGB.constraints = RigidbodyConstraints.None;

        //hide ball spawner
        ballGen.UnPause();
    }

    private void PauseGame()
    {
        isPaused = true;

        //Freeze table
        basController.Pause();
       
        //Freeze Ball
        ball = GameObject.FindGameObjectWithTag("ball");

        if (ball)
        {
            ballRGB = ball.GetComponent<Rigidbody>();
            ballRGB.constraints = RigidbodyConstraints.FreezeAll;
        }

        //Show ball spawner

        ballGen.Pause();
    }
}
