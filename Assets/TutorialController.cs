using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour {
    public Text text;

    int step = 1;
    private bool isPaused;

    /*Child 0 = text
Child 1 = 3Dbuttton*/
    void Start () {
        text = transform.GetChild(0).GetComponent<Text>();
        Invoke("ButtonSubmitted",3);

	}
  

    void Step2() {
        text.text = "To pause the game left click";
        step++;
       
    }






    public void ButtonSubmitted() {
        switch (step)
        {
            case 1:
                text.text = "Left click to un-pause the board.";
                step++;
                break;
            case 2:
                text.text = "To move the board use WASD";
                Invoke("Step2", 3);
                break;
            case 3:

                text.text = "To change your point of view look, at the yellow platforms on the side for 2 seconds";
                step++;
                break;

            case 4:
                text.text = "To move the camera up and down, select and hold the Up and Down buttons in the control board";
                step++;
                Invoke("ButtonSubmitted",4);
                break;

            case 5:
                text.text = "To spawn a new ball and reset the board, select and hold the ball in the control board";
                step++;
                break;

            case 6:
                text.text = "To select a new LaVRynth look and hold the unlocked LaVRynth for 2 seconds";
                Destroy(gameObject,3);
                break;
            default:
                break;
        }
        

        
    }

    void OnEnable()
    {
        
        PauseController.OnPausePressed += PausePressed;

    }
    void OnDisable()
    {

        PauseController.OnPausePressed -= PausePressed;
    }
    private void PausePressed()
    {
            ButtonSubmitted();

        
        if (isPaused)
        {

            UnPause();
        }
        else
        {

            Pause();
        }
    }
    void Pause()
    {
        isPaused = true;
     
    }

    void UnPause()
    {
        isPaused = false;
    
    }
}
