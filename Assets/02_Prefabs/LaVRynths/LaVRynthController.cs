using UnityEngine;
using System.Collections;

public class LaVRynthController : MonoBehaviour {

    public Transform fadeSprite;
    SpriteRenderer spriteRend;
    Color spriteColor;
    public float repeatRate = .02f;
    float timer = 0;
    public float fadeTime = 1.0f;
    int callingLaVR;
    AudioSource aSource;

    // Use this for initialization
    void Awake() {
        spriteRend = fadeSprite.GetComponent<SpriteRenderer>();
        SetAlpha(0);
        fadeSprite.gameObject.SetActive(false);
        aSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartFadeOut(int laVRNum) {
        callingLaVR = laVRNum;
        fadeSprite.gameObject.SetActive(true);
        aSource.Play();
        InvokeRepeating("FadeOut", repeatRate, repeatRate);
    }
    public void FadeOut() {
        timer += repeatRate;
        //change according to the time elapsed
        float percent = timer / fadeTime;
        float aValue = Mathf.Lerp(0, 1, percent);

        SetAlpha(aValue);

        if (aValue >= 1)
        {
            transform.parent.GetChild(callingLaVR - 1).gameObject.SetActive(true);
            transform.parent.GetChild(callingLaVR).gameObject.SetActive(true);
            //cameraRig.transform.localPosition = new Vector3(cameraRig.transform.localPosition.x, PlayerPrefs.GetFloat("CameraHeight"), cameraRig.transform.localPosition.z);

            timer = 0;
            SetAlpha(1);
            CancelInvoke("FadeOut");
            gameObject.SetActive(false);
        }
    }

    public void FadeIn() {
        
        timer += repeatRate;
        float percent = timer / fadeTime;
        float aValue = Mathf.Lerp(1, 0, percent);

        SetAlpha(aValue);

        if (aValue <= 0.05f)
        {
            SetAlpha(0);
            fadeSprite.gameObject.SetActive(false);
            CancelInvoke("FadeIn");
            timer = 0;
        }
    }

    private void SetAlpha(float aValue)
    {
        spriteColor.a = aValue;
        spriteRend.color = spriteColor;
    }

    void OnEnable() {
        
        fadeSprite.gameObject.SetActive(true);
        SetAlpha(1);
        InvokeRepeating("FadeIn", repeatRate, repeatRate);
    }
}