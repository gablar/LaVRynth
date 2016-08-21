using UnityEngine;
using System.Collections;

public class MoveCameraController : MonoBehaviour {

    public Material unSelected;
    public Material selected;
    MeshRenderer mRend;

    public Transform cameraRig;
    public float yMovement = 1;
    public bool up;
    // Use this for initialization
    void Start()
    {
        mRend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame

    public void OnPointerEnter()
    {
        mRend.material = selected;
    }

    public void OnPointerExit()
    {
        mRend.material = unSelected;
    }

    public void OnSubmit()
    {   if (up)
        {
            float newHeight = PlayerPrefs.GetFloat("CameraHeight") + yMovement;
            PlayerPrefs.SetFloat("CameraHeight", newHeight);
            cameraRig.transform.position = new Vector3(cameraRig.transform.position.x,
                                                        newHeight,
                                                        cameraRig.transform.position.z);
        }
        else {
            float newHeight = PlayerPrefs.GetFloat("CameraHeight") - yMovement;
            PlayerPrefs.SetFloat("CameraHeight", newHeight);
            cameraRig.transform.position = new Vector3(cameraRig.transform.position.x,
                                                        newHeight,
                                                        cameraRig.transform.position.z);
        }

    }
}
