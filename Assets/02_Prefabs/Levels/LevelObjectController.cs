using UnityEngine;
using System.Collections;
using System;

public class LevelObjectController : MonoBehaviour {
    private bool isPaused = true;
    private Vector3 initScale;
    //AudioSource aSource;
    Animator anim;

    //LaVRynth assigned to this levelObject
    public Transform laVR;
    static int callingLaVR =1;

    //Lock unlock level

    public bool isLocked = true;

    //fade
    void Awake(){
        anim = GetComponent<Animator>();
        spriteRend = fadeSprite.GetComponent<SpriteRenderer>();


    }

    // Use this for initialization
    void Start () {
        initScale = transform.localScale;
        //aSource = GetComponent<AudioSource>();
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
            InvokeRepeating("FadeOut", repeatRate, repeatRate);
        }


    }

    float repeatRate = .02f;
    float timer = 0;
    float fadeTime = 1.0f;
    public Transform fadeSprite;
    SpriteRenderer spriteRend;
    Color spriteColor;

    void FadeOut() {
        timer += repeatRate;
        //change according to the time elapsed
        float percent = timer / fadeTime;
        float aValue = Mathf.Lerp(0, 1, percent);

        SetAlpha(aValue);

        if (aValue >= 1)
        {
            transform.parent.GetChild(callingLaVR - 1).gameObject.SetActive(true);
            transform.parent.GetChild(callingLaVR).gameObject.SetActive(false);
            callingLaVR = transform.GetSiblingIndex()+1;
            laVR.gameObject.SetActive(true);
            timer = 0;
            SetAlpha(1);
            CancelInvoke("FadeOut");
            transform.localScale = initScale;//reset to regular scale

            gameObject.SetActive(false);
        }
    }

    private void SetAlpha(float aValue)
    {
        spriteColor.a = aValue;
        spriteRend.color = spriteColor;
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
