using UnityEngine;
using System.Collections;

public class MoveCameraUpController : MonoBehaviour {
    public Material unSelected;
    public Material selected;
    MeshRenderer mRend;

    public float cameraHeight;
	// Use this for initialization
	void Start () {
        mRend = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPointerEnter()
    {
        mRend.material = selected;
    }

    public void OnPointerExit()
    {
        mRend.material = unSelected;
    }

    public void OnSubmit()
    {


    }
}
