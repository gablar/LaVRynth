using UnityEngine;
using System.Collections;

public class ChangePlatTut : MonoBehaviour {
    public BaseController bCont;
    public RectTransform rTrans;
    TutorialController tutorialCont;
    bool firstChange = false;
	// Use this for initialization
	void Start () {
        tutorialCont = rTrans.GetComponent<TutorialController>();
	}

    public void OnSubmit()
    {
        Invoke("ChangePosition", 2.1F);
    }

    void ChangePosition() {
        int plat = bCont.platform;
        if (!firstChange) { tutorialCont.ButtonSubmitted(); }
        switch (plat) {
            case 1:
                rTrans.localPosition = new Vector3(0,3.3f,-6.8f);
                rTrans.rotation = Quaternion.Euler(0,180.0f,0); 
                break;

            case 2:
                rTrans.localPosition = new Vector3(-6.8f, 3.3f, 0);
                rTrans.rotation = Quaternion.Euler(0, -90.0f, 0);
                break;

            case 3:
                rTrans.localPosition = new Vector3(0, 3.3f, 6.8f);
                rTrans.rotation = Quaternion.Euler(0, 0, 0);
                break;

            case 4:
                rTrans.localPosition = new Vector3(6.8f, 3.3f, 0);
                rTrans.rotation = Quaternion.Euler(0, 90.0f, 0);
                break;

            default:

                break;
        }
    }
}
