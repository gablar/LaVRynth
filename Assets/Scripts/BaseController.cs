using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class BaseController : MonoBehaviour {

    public Transform OVRCamera;
       
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Quaternion camRot = OVRCamera.rotation;
        transform.rotation = camRot;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x-OVRCamera.parent.parent.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);

        

    }
}
