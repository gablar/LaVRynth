using UnityEngine;
using System.Collections;
using System;

public class LevelObjectController : MonoBehaviour {
    private bool isPaused = true;
    private Vector3 initScale0;
    private Vector3 initScale1;
    private Vector3 initPosLock;
    Transform meshTransform;
    Transform lockTransform;
    Transform highLighterTransform;
    //AudioSource aSource;
    Animator anim;

    //LaVRynth assigned to this levelObject
    public Transform laVR;
    static int callingLaVR =0;//0 means the Calling laVRynth is the start menu

    //Lock unlock level

    public bool isLocked = true;

    //fade
    void Awake(){
        anim = GetComponent<Animator>();
        spriteRend = fadeSprite.GetComponent<SpriteRenderer>();


    }

    // Use this for initialization
    void Start () {
        meshTransform = transform.GetChild(0);
        lockTransform = transform.GetChild(1);
        highLighterTransform = transform.GetChild(2);//off by default

        initScale0 = meshTransform.localScale;
        initScale1 = lockTransform.localScale;

        initPosLock = lockTransform.position;
        //aSource = GetComponent<AudioSource>();
        if (!isLocked) Unlock();
        

    }


    public void OnPointerEnter()
    {
        if (isPaused)
        {
            anim.SetBool("isSpining", false);
            meshTransform.localScale = initScale0 * 3.0f;
            lockTransform.position = new Vector3(initPosLock.x, initPosLock.y + 1.0f, initPosLock.z);
            lockTransform.localScale = initScale1 * 3.0f;


        }
    }

    public void OnPointerExit()
    {
        if (isPaused)
        {
            anim.SetBool("isSpining", true);
            meshTransform.localScale = initScale0;
            lockTransform.localScale = initScale1;
            lockTransform.position = initPosLock;
        }

        
    }

    public void OnSubmit()
    {
        if (isPaused && !isLocked)
        {
            fadeSprite.gameObject.SetActive(true);
            SetAlpha(0);
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
            //if the calling is done by the start menu
        {   if (callingLaVR == 0) {
                callingLaVR = 1;
            }
            else { 
                //activate the calling Level Object
                transform.parent.GetChild(callingLaVR - 1).gameObject.SetActive(true);
                //deactivate the calling LaVRynth
                transform.parent.GetChild(callingLaVR).gameObject.SetActive(false);
                //set this level object as the next calling laberinth
                callingLaVR = transform.GetSiblingIndex()+1;
            }
            laVR.gameObject.SetActive(true);
            timer = 0;
            SetAlpha(1);
            CancelInvoke("FadeOut");
            meshTransform.localScale = initScale0;
            lockTransform.localScale = initScale1;//reset to regular scale
            lockTransform.position = initPosLock;
            highLighterTransform.gameObject.SetActive(false);
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
        lockTransform.gameObject.SetActive(false);
        highLighterTransform.gameObject.SetActive(true);
       
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
