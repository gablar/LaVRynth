using UnityEngine;
using System.Collections;

public class ChangeLavTut : MonoBehaviour {
    public RectTransform rTrans;
    public TutorialController tutCont;
    bool itHappened = false;

    // Use this for initialization

    void OnTriggerEnter(Collider ball)
    {

        if (ball.gameObject.tag == "ball" && !itHappened)
        {
            rTrans.gameObject.SetActive(true);
            tutCont.ButtonSubmitted();
            itHappened = true;
        }

    }

}
