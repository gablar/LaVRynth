using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {
    //init for button

    public Transform centerBall;
    Vector3 initScale;
    Color initColor;
    Color highLightColor = Color.green;
    MeshRenderer mRend;

    //init for elements of Menu
    public Text welcomeText;
    public Text startText;
    public Text creditsText;
    public Text tutorialText;
    public Text celebrationText;


    //init For StartButton
    public LevelObjectController levelToOpen;

    //init for Credits


    // Use this for initialization
    void Start () {

        initScale = centerBall.localScale;
       // Debug.Log("initial Scale"+ initScale);
        mRend = centerBall.gameObject.GetComponent<MeshRenderer>();
        initColor = mRend.material.color;

    }

    // Update is called once per frame
    void Update () {
	
	}

    public void OnPointerEnter()
    {
        //Debug.Log("Pointer entered");
            centerBall.localScale = initScale * 1.5f;
            mRend.material.color = highLightColor;
    }

    public void OnPointerExit()
    {
        //Debug.Log("Pointer Exited");
        centerBall.localScale = initScale;
            mRend.material.color = initColor;
    }

    public void OnSubmitStart()
    {
        levelToOpen.Unlock();
        welcomeText.gameObject.SetActive(false);
        startText.gameObject.SetActive(false);
        creditsText.gameObject.SetActive(false);
        tutorialText.gameObject.SetActive(true);
        Invoke("DisableTutorial", 4.0f);


    }

    public void OnSubmitCredits() {
        welcomeText.gameObject.SetActive(false);
        creditsText.enabled = false;
        creditsText.transform.GetChild(1).gameObject.SetActive(true);


    }

    void DisableTutorial() {
        tutorialText.gameObject.SetActive(false);
        celebrationText.gameObject.SetActive(true);
        transform.parent.parent.gameObject.SetActive(false);
    }
    public void OnStartPressed()
    {

    }
}
