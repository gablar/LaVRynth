using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AutomatedText : MonoBehaviour {
    Text text;
    bool isPaused = true;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        Invoke("ChangeText",5);
	}

    // Update is called once per frame
    void ChangeText()
    {
        text.text = "Time elapsed = " + Time.time;
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
