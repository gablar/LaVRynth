using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour {
    
    public bool isPaused = true;

    //Base
    public BaseController basController;
   

    //ball
    GameObject ball;
    Rigidbody ballRGB;

    //UI
    public GameObject ballGen;
    // Use this for initialization
    void Start () {
        basController = GameObject.Find("base").GetComponent<BaseController>();
        ballGen = GameObject.Find("BallGeneratorInteractable");

        if (isPaused) PauseGame(); else UnPauseGame();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
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

    private void UnPauseGame()
    {
        isPaused = false;

        //unfreezebase
        basController.UnPause();

        //unfreezeball
        ballRGB.constraints = RigidbodyConstraints.None;

        //hide ball spawner
        ballGen.SetActive(false);
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

        ballGen.SetActive(true);
    }
}
