using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class BaseController : MonoBehaviour {

    public Transform OVRCamera;
    public float xMult;
    public float zMult;
    float lastRot;
    Vector3 initPos;
    
       
	// Use this for initialization
	void Start () {
       
        initPos = transform.position;

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 parentAngle = OVRCamera.parent.parent.rotation.eulerAngles;
        Vector3 centerAngle = OVRCamera.eulerAngles;
        float xEuAngle = centerAngle.x -parentAngle.x;
        float zEuAngle = centerAngle.z - parentAngle.z;
        transform.rotation = Quaternion.Euler(xEuAngle * xMult , 0 , zEuAngle * zMult);


       // transform.position = initPos;
        /*

        if (transform.rotation.x != lastRot && transform.rotation.x - lastRot >= 0)
        {
            transform.Translate(transform.up * -yTransform);
        }


        if (transform.rotation.y != lastRot && transform.rotation.x - lastRot <= 0)
        {
            transform.Translate(transform.up * yTransform);

        }
        lastRot = transform.rotation.eulerAngles.x;*/


    }
}
