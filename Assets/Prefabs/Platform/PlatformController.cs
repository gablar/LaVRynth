using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {
    private bool isPaused = true;
    private Vector3 initScale;
    public OVRCameraRig cameraRig;
    ScreenFader fader;

    // Use this for initialization
    void Start () {

        initScale = transform.localScale;

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
        {   //fader.fadeIn = 
            cameraRig.transform.position = transform.GetChild(0).position;
            cameraRig.transform.rotation = transform.GetChild(0).rotation;

        }
            
    }

    public void Pause() {
        isPaused = true;
    }

    public void UnPause() {
        isPaused = false;
    }
}
