using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {
    //init for button
    bool isPaused = true;
    public Transform centerBall;
    Vector3 initScale;
    Color initColor;
    Color highLightColor = Color.green;
    MeshRenderer mRend;

    //init for elements of Menu
    public Text WelcomeText;
    public Text StartText;
    public Text CreditsText;
    public Text TutorialText;


    //init For StartButton
    public LevelObjectController levelToOpen;


    // Use this for initialization
    void Start () {

        initScale = centerBall.localScale;
        Debug.Log("initial Scale"+ initScale);
        mRend = centerBall.gameObject.GetComponent<MeshRenderer>();
        initColor = mRend.material.color;

    }

    // Update is called once per frame
    void Update () {
	
	}

    public void OnPointerEnter()
    {
        Debug.Log("Pointer entered");
            centerBall.localScale = initScale * 1.5f;
            mRend.material.color = highLightColor;
    }

    public void OnPointerExit()
    {
        Debug.Log("Pointer Exited");
        centerBall.localScale = initScale;
            mRend.material.color = initColor;
    }

    public void OnSubmitStart()
    {
        levelToOpen.Unlock();
        WelcomeText.gameObject.SetActive(false);
        StartText.gameObject.SetActive(false);
        CreditsText.gameObject.SetActive(false);
        TutorialText.gameObject.SetActive(true);


    }

    public void OnStartPressed()
    {

    }
}
