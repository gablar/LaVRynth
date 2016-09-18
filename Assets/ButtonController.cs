using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {
    bool isPaused = true;
    public Transform centerBall;
    Vector3 initScale;
    Color initColor;
    Color highLightColor = Color.green;
    MeshRenderer mRend;


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

    public void OnSubmit()
    {

    }

    public void OnStartPressed()
    {

    }
}
