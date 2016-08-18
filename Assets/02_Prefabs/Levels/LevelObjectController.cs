using UnityEngine;
using System.Collections;
using System;

public class LevelObjectController : MonoBehaviour {
    private bool isPaused = true;
    private Vector3 initScale;
    AudioSource aSource;
    Animator anim;

    //LaVRynth assigned tto this levelObject
    public Transform laVR;
    public int laVRNum;
    static int currentLaVR = 1;

    //Lock unlock level

    public bool isLocked = true;

    //fade
    void Awake(){
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
        initScale = transform.localScale;
        aSource = GetComponent<AudioSource>();
        if (!isLocked) Unlock();
        

    }


    public void OnPointerEnter()
    {
        if (isPaused)
        {
            anim.SetBool("isSpining", false);
            transform.localScale = initScale * 3.0f;

        }
    }

    public void OnPointerExit()
    {
        if (isPaused)
        {
            anim.SetBool("isSpining", true);
            transform.localScale = initScale;
        }

        
    }

    public void OnSubmit()
    {
        if (isPaused && !isLocked)
        { 
            transform.localScale = initScale;//reset to regular scale
            // get calling Lavrynth
            LaVRynthController lv1 = transform.parent.GetChild(currentLaVR).GetComponent<LaVRynthController>();
            lv1.StartFadeOut(laVRNum);
            currentLaVR = laVRNum;
            gameObject.SetActive(false);


        }


    }

    public void Unlock() {
        isLocked = false;
        transform.GetChild(1).gameObject.SetActive(false);
       
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
        if (isPaused) {
         
            UnPause();
        } else {

            Pause(); }
    }

    void Pause() {
        isPaused = true;
        anim.SetBool("isSpining", true);
    }

    void UnPause() {
        isPaused = false;
        anim.SetBool("isSpining", false);
    }
}
