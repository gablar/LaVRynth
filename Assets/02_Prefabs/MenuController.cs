using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {
    private bool isPaused = true;
    MeshRenderer mRend;
    BoxCollider bColl;
    // Use this for initialization
    void Start () {
        mRend = GetComponent<MeshRenderer>();
        bColl = GetComponent<BoxCollider>();
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
        mRend.enabled = true;
        bColl.enabled = true;
    }

    void UnPause()
    {
        isPaused = false;
        mRend.enabled = false;
        bColl.enabled = false;
        
    }
}
