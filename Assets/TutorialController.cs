using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour {
    public Text text;
    Transform myButton;

    int step = 1;
    private bool isPaused;

    /*Child 0 = text
Child 1 = 3Dbuttton*/
    void Start () {
        text = transform.GetChild(0).GetComponent<Text>();
        Invoke("ButtonSubmitted",3);

	}
  
    void Step0() {
        myButton.gameObject.SetActive(true);
        step++;
    }

    void Step2() {
        text.text = "To pause the game tap the touchpad";
        step++;
       
    }


        


    public void ButtonSubmitted() {
        switch (step)
        {
            case 1:
                text.text = "Tap the touchpad to free the board.";
                step++;
                break;
            case 2:
                text.text = "To move the board tilt your head from side to side or front to back.";
                Invoke("Step2", 4);
                break;
            case 3:

                text.text = "To change your point of view look at the yellow platforms on the side for 2 seconds";
                step++;
                break;

            case 4:
                text.text = "To move the camera up and down, select and hold the Up and Down buttons";
                step++;
                Invoke("ButtonSubmitted",4);
                break;

            case 5:
                text.text = "To spawn a new ball and reset the board, select and hold the middle button";
                step++;
                break;

            case 6:
                text.text = "To select a new LaVRynth look and hold the unlocked LaVRynth for 2 seconds";
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
        if (step==2)
        {
            ButtonSubmitted();
            
        }

        if (step == 3) {
            ButtonSubmitted();
        }
        
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
