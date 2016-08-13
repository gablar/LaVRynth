using UnityEngine;
using System.Collections;
using System;

public class LevelObjectController : MonoBehaviour {
    private bool isPaused = true;
    private Vector3 initScale;
    AudioSource aSource;
    Animator anim;

    public Transform laVR;
    public int laVRNum;
    static int currentLaVR = 1;

    void Awake(){
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
        initScale = transform.localScale;
        aSource = GetComponent<AudioSource>();
        

    }

    // Update is called once per frame
    void Update () {
	
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
       
            anim.SetBool("isSpining", true);
            transform.localScale = initScale;

        
    }

    public void OnSubmit()
    {

        transform.localScale = initScale;
        transform.parent.GetChild(currentLaVR).gameObject.SetActive(false);
        transform.parent.GetChild(currentLaVR-1).gameObject.SetActive(true);
        Animator otherAnim = transform.parent.GetChild(currentLaVR - 1).GetComponent<Animator>();
        otherAnim.SetBool("isSpining", true);

        currentLaVR = laVRNum;

        laVR.gameObject.SetActive(true);
        gameObject.SetActive(false);


    }

    void OnEnable()
    {
        PauseController.OnPausePressed += PausePressed;

        //anim.SetBool("isSpining", true);

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
