using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
    AudioSource audioSource;
    Rigidbody rgb;
    bool isMoving;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        rgb = GetComponent<Rigidbody>();
        isMoving = false;
	}
	
	// Update is called once per frame
	void Update () {
        float mag = rgb.velocity.magnitude;

        if (isMoving)
        {
            audioSource.pitch = mag;
        }
        else
        if (!isMoving && mag > 0)
        {
            audioSource.Play();
            audioSource.pitch = mag;
            isMoving = true;
        }
        else
        if (isMoving  &&  mag==0) {
            audioSource.Stop();
            isMoving = false;
        }
        
        
	}
}
