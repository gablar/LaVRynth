using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {
    private bool isPaused = true;
    public bool isDefault;
    public bool isFirst;
    

    public Transform fadeSprite;
    SpriteRenderer spriteRend;
    Color spriteColor;

    public Transform FPSController;
    private Vector3 initScale;
    public float repeatRate = .02f;
    float timer = 0;
    public float fadeTime = .5f;
    bool fadingOut = true;

    MeshRenderer mesh;
    public Material platform;
    public Material hPlatform;
    BoxCollider bColl;

    public BaseControllerKong baseController;
    public int platformNumber;

    AudioSource aSource;
    Vector3 thisPosition;
    Quaternion thisRotation;

    /*Child 0 = Camera Position
      Child 1 = Menu
      Child 2 = Mesh 
      */

    void Awake() {
        thisPosition = new Vector3(transform.position.x, transform.GetChild(0).position.y, transform.position.z);
        thisRotation = transform.GetChild(0).rotation;
        mesh = transform.GetChild(2).GetComponent<MeshRenderer>();
        bColl = GetComponent<BoxCollider>();
        initScale = transform.GetChild(2).localScale;
        spriteRend = fadeSprite.GetComponent<SpriteRenderer>();
        SetAlpha(0);
        fadeSprite.gameObject.SetActive(false);
        aSource = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
        if (isDefault && isFirst)
        {
            PlayerPrefs.SetFloat("CameraHeight", 0);
            FPSController.position = new Vector3(thisPosition.x,
                                            thisPosition.y + PlayerPrefs.GetFloat("CameraHeight"),
                                            thisPosition.z);
            FPSController.rotation = thisRotation;
            isFirst = false;
            mesh.enabled = false;
            bColl.enabled = false;

        }
        else if (isDefault && !isFirst)
        {
            FPSController.position = new Vector3(thisPosition.x,
                                                        thisPosition.y + PlayerPrefs.GetFloat("CameraHeight"),
                                                        thisPosition.z);
            FPSController.localRotation = thisRotation;
            mesh.enabled = false;
            bColl.enabled = false;
           // Debug.Log("Default platform initialized, Platform #" + platformNumber);
        }


    }


    public void OnPointerEnter()
    {

        if (isPaused) {
            transform.GetChild(2).localScale = initScale * 1.2f;
            mesh.material = hPlatform;
        }
            
    }

    public void OnPointerExit()
    {
        if (isPaused) {
            transform.GetChild(2).localScale = initScale;
            mesh.material = platform;
        }
    }

    public void OnSubmit()
    {
       if (isPaused)
        {   //EnableSprite
            transform.GetChild(2).localScale = initScale;
            mesh.material = platform;
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
            {   //change Camera to this platform

                FPSController.position = new Vector3(thisPosition.x, thisPosition.y + PlayerPrefs.GetFloat("CameraHeight"),thisPosition.z);
                FPSController.localRotation = thisRotation;

                //turn off Menu and turn on mesh and coll in the prior Platform
                Transform priorPlatform = transform.parent.GetChild(baseController.platform - 1);

                //Debug.Log("Turn Off calling platform " + (baseController.platform));
                priorPlatform.GetChild(1).gameObject.SetActive(false);
                priorPlatform.GetChild(2).GetComponent<MeshRenderer>().enabled = true;
                priorPlatform.GetComponent<BoxCollider>().enabled = true;


                
                //turn on this Menu  

                transform.GetChild(1).gameObject.SetActive(true);

                //turn off this platform mesh and coll

                mesh.enabled = false;
                bColl.enabled = false;


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
                CancelInvoke("FadeOut");

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

    void OnEnable() {

    }
}
