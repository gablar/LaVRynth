using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {
    private bool isPaused = true;
    public bool isDefault;
    public bool isFirst;
    public bool isCurrentPlat;

    public Transform fadeSprite;
    SpriteRenderer spriteRend;
    Color spriteColor;

    public OVRCameraRig cameraRig;
    private Vector3 initScale;
    public float repeatRate = .02f;
    float timer = 0;
    public float fadeTime = .5f;
    bool fadingOut = true;

    MeshRenderer mesh;
    public Material platform;
    public Material hPlatform;
    BoxCollider bColl;

    public BaseController baseController;
    public int platformNumber;

    AudioSource aSource;

    void Awake() {
        mesh = GetComponent<MeshRenderer>();
        bColl = GetComponent<BoxCollider>();
        initScale = transform.localScale;
        spriteRend = fadeSprite.GetComponent<SpriteRenderer>();
        SetAlpha(0);
        fadeSprite.gameObject.SetActive(false);
        aSource = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
        if (isDefault && isFirst)
        {
            PlayerPrefs.SetFloat("CameraHeight", cameraRig.transform.position.y);
            //OnSubmit();
            isFirst = false;
            mesh.enabled = false;
            bColl.enabled = false;
            isCurrentPlat = true;
        }
        else if (isDefault && !isFirst)
        {
            cameraRig.transform.position = new Vector3(cameraRig.transform.position.x,
                                                        PlayerPrefs.GetFloat("CameraHeight"),
                                                        cameraRig.transform.position.z);
            mesh.enabled = false;
            bColl.enabled = false;
            isCurrentPlat = true;
        }
        else {
            isCurrentPlat = false;
        }


    }


    public void OnPointerEnter()
    {

        if (isPaused && !isCurrentPlat) {
            transform.localScale = initScale * 1.4f;
            mesh.material = hPlatform;
        }
            
    }

    public void OnPointerExit()
    {
        if (isPaused) {
            transform.localScale = initScale;
            mesh.material = platform;
        }
    }

    public void OnSubmit()
    {
       if (isPaused && !isCurrentPlat)
        {   //EnableSprite
            transform.localScale = initScale;
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
                Vector3 position = transform.GetChild(0).position;
                cameraRig.transform.position = new Vector3(position.x,PlayerPrefs.GetFloat("CameraHeight"),position.z);
                cameraRig.transform.rotation = transform.GetChild(0).rotation;

                //turn off Menu and turn on mesh and coll in the prior Platform
                Transform priorPlatform = transform.parent.GetChild(baseController.platform - 1); 
                priorPlatform.GetChild(1).gameObject.SetActive(false);
                priorPlatform.gameObject.GetComponent<MeshRenderer>().enabled = true;
                priorPlatform.gameObject.GetComponent<BoxCollider>().enabled = true;
                priorPlatform.gameObject.GetComponent<PlatformController>().isCurrentPlat = false;

                
                //turn on this Menu and turn off this platform mesh and coll

                transform.GetChild(1).gameObject.SetActive(true);
                mesh.enabled = false;
                bColl.enabled = false;
                isCurrentPlat = true;
                //turn off this platforms mesh and coll

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

}
