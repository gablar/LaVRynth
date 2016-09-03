using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {
    bool isPaused = true;
    public Transform centerBall;
    Vector3 initScale;
    Color initColor;
    Color highLightColor = Color.green;
    MeshRenderer mRend;

    public delegate void ButtonSubmitted();
    public static event ButtonSubmitted OnButtonSubmitted;

    // Use this for initialization
    void Start () {
        initScale = centerBall.localScale;
        mRend = centerBall.gameObject.GetComponent<MeshRenderer>();
        initColor = mRend.material.color;

    }

    // Update is called once per frame
    void Update () {
	
	}

    public void OnPointerEnter()
    {
        if (isPaused)
        {
       
            centerBall.localScale = initScale * 1.5f;
            mRend.material.color = highLightColor;


        }
    }

    public void OnPointerExit()
    {
        if (isPaused)
        {
 
            centerBall.localScale = initScale;
            mRend.material.color = initColor;
        }


    }

    public void OnSubmit()
    {
        if (isPaused) {
            if (OnButtonSubmitted != null)
            {
                OnButtonSubmitted();
            }

        }


    }
}
