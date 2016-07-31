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
    BallController ballController;

    //UI
    public BallGeneratorController ballGen;
    // Use this for initialization
    void Start () {
        //basController = GameObject.Find("base").GetComponent<BaseController>();
        //ballGen = GameObject.Find("BallGeneratorInteractable").GetComponent<BallGeneratorController>();
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
        ball = GameObject.FindGameObjectWithTag("ball");
        if (ball)
        {
            ballController = ball.GetComponent<BallController>();
            ballController.UnPause();
        }
        

        //hide ball spawner
        ballGen.UnPause();
    }

    private void PauseGame()
    {
        isPaused = true;

        //Freeze base
        basController.Pause();

        //Freeze Ball
        ball = GameObject.FindGameObjectWithTag("ball");
        if (ball)
        {
            ballController = ball.GetComponent<BallController>();
            ballController.Pause();
        }

        //Show ball spawner

        ballGen.Pause();
    }
}
