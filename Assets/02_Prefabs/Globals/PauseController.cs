using UnityEngine;
using System.Collections;
using System;

public class PauseController : MonoBehaviour {
    public delegate void PausePressed();
    public static event PausePressed OnPausePressed;


    public bool isPaused = true;

    //Base
    public BaseController basController;
   

    //ball
    GameObject ball;
    Rigidbody ballRGB;
    BallController ballController;

    //UI

    public PlatformsController platforms;
    // Use this for initialization

    void Awake() {
        //if (isPaused) PauseGame(); else UnPauseGame();
    }
    void Start () {

        OVRTouchpad.Create();
        OVRTouchpad.TouchHandler += HandleTouchHandler;
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
        if (OnPausePressed != null)
        {
            OnPausePressed();
        }


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
        


        //disable platform interaction
        platforms.gameObject.SetActive(false);
    }

    private void PauseGame()
    {
        if (OnPausePressed != null)
        {
            OnPausePressed();
        }

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


        //Enable platform interaction
        platforms.gameObject.SetActive(true);
    }
}
