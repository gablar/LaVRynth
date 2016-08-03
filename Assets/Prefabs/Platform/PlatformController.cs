using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {
    private bool isPaused = true;

    public Transform fadeSprite;
    SpriteRenderer spriteRend;
    Color spriteColor;

    public OVRCameraRig cameraRig;
    private Vector3 initScale;
    public float repeatRate = .02f;
    float timer = 0;
    public float fadeTime = .5f;
    bool fadingOut = true;

    public BaseController baseController;
    public int platformNumber;

    AudioSource aSource;



    // Use this for initialization
    void Start () {

        initScale = transform.localScale;
        spriteRend = fadeSprite.GetComponent<SpriteRenderer>();
        SetAlpha(0);
        fadeSprite.gameObject.SetActive(false);
        aSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update () {
	
	}
    public void OnPointerEnter()
    {

        if (isPaused) transform.localScale = initScale * 1.2f;
    }

    public void OnPointerExit()
    {
        if (isPaused) transform.localScale = initScale;
    }

    public void OnSubmit()
    {
       if (isPaused)
        {   //EnableSprite

            fadeSprite.gameObject.SetActive(true);
            aSource.Play();
            //Set a to first value
            InvokeRepeating("FadeOut", repeatRate, repeatRate);

        }
            
    }



    void FadeOut()
    {   if (fadingOut)
        {
            timer += repeatRate;
            //change according to the time elapsed
            float percent = timer / fadeTime;
            float aValue = Mathf.Lerp(0 , 1, percent);

            SetAlpha(aValue);

            if (aValue >= 1)
            {
                cameraRig.transform.position = transform.GetChild(0).position;
                cameraRig.transform.rotation = transform.GetChild(0).rotation;
                baseController.platform = platformNumber;
                fadingOut = false;
                timer = 0;
            }
        }
        else {

            timer += repeatRate;
            float percent = timer / fadeTime;

            float aValue = Mathf.Lerp(1 , 0 , percent);

            SetAlpha(aValue);
            

            if (aValue <= 0) {
                fadingOut = true;
                fadeSprite.gameObject.SetActive(false);
                CancelInvoke();


            }


        }
    }

    private void SetAlpha(float aValue)
    {
        spriteColor.a = aValue;
        spriteRend.color = spriteColor;
    }


    public void Pause()
    {
        isPaused = true;
    }
    public void UnPause()
    {
        isPaused = false;
    }

}
