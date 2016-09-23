using UnityEngine;
using System.Collections;
using System;

public class PauseController : MonoBehaviour {
    public delegate void PausePressed();
    public static event PausePressed OnPausePressed;


    public bool isPaused = true;

    //Base
    public BaseControllerKong basController;
   

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


    }

        
            

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0)) {
            if (isPaused) { UnPauseGame(); } else { PauseGame(); }
        }

    }

    public void UnPauseGame()
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
        GazeInputModuleCrosshair.DisplayCrosshair = false;
    }

    public void PauseGame()
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
        GazeInputModuleCrosshair.DisplayCrosshair = true;

    }
}
