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
    public Transform fadeSprite;
    SpriteRenderer spriteRend;
    Color spriteColor;
    public OVRCameraRig cameraRig;
    public float repeatRate = .02f;
    float timer = 0;
    public float fadeTime = .5f;
    bool fadingOut = true;

    public BaseController baseController;
    public int platformNumber;

    void Awake(){
        anim = GetComponent<Animator>();
        spriteRend = fadeSprite.GetComponent<SpriteRenderer>();
        SetAlpha(0);
        fadeSprite.gameObject.SetActive(false);
    }

    // Use this for initialization
    void Start () {
        initScale = transform.localScale;
        aSource = GetComponent<AudioSource>();
        if (!isLocked) Unlock();
        

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

            fadeSprite.gameObject.SetActive(true);
            aSource.Play();
            //Set a to first value
            InvokeRepeating("FadeOut", repeatRate, repeatRate);


        }


    }

    public void Unlock() {
        isLocked = false;
        transform.GetChild(1).gameObject.SetActive(false);
       
    }

    void FadeOut()
    {
       
        if (fadingOut)
        {
            timer += repeatRate;
            //change according to the time elapsed
            float percent = timer / fadeTime;
            float aValue = Mathf.Lerp(0, 1, percent);

            SetAlpha(aValue);

            if (aValue >= 1)
            {
                

                transform.parent.GetChild(currentLaVR - 1).gameObject.SetActive(true);
                Animator otherAnim = transform.parent.GetChild(currentLaVR - 1).GetComponent<Animator>();
                otherAnim.SetBool("isSpining", true);

                transform.parent.GetChild(currentLaVR).gameObject.SetActive(false);
                currentLaVR = laVRNum;

                laVR.gameObject.SetActive(true);
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.SetActive(false);

                //baseController.platform = platformNumber;
                fadingOut = false;
                timer = 0;
            }
        }
        else
        {
            
            timer += repeatRate;
            float percent = timer / fadeTime;

            float aValue = Mathf.Lerp(1, 0, percent);
            SetAlpha(aValue);


            if (aValue <= 0.1f)
            {
               

                fadingOut = true;
                fadeSprite.gameObject.SetActive(false);
                CancelInvoke();
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                //gameObject.transform.GetChild(1).gameObject.SetActive(true);
                gameObject.SetActive(false);



            }


        }
    }

    private void SetAlpha(float aValue)
    {
        spriteColor.a = aValue;
        spriteRend.color = spriteColor;
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
