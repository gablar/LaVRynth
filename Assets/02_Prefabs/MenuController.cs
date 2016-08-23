using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {
    private bool isPaused = true;
    //All children must be set Active true on Pause;
    MeshRenderer mRend;
   
    // Use this for initialization
    void Start () {
        mRend = GetComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void Update () {
	
	}
    public void OnPointerEnter()
    {

        if (isPaused) {  }
    }

    public void OnPointerExit()
    {
        if (isPaused) { }
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
       /* if (isPaused)
        {

            UnPause();
        }
        else
        {

            Pause();
        }*/
    }

    void Pause()
    {
        isPaused = true;
        mRend.enabled = true;

        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(true);
    }

    void UnPause()
    {
        isPaused = false;
        mRend.enabled = false;

        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);

    }
}
