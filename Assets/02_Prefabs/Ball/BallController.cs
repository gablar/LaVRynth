using UnityEngine;
using System.Collections;
using System;

public class BallController : MonoBehaviour {
    AudioSource audioSource;
    Rigidbody rgb;
    Animator anim;
    bool isMoving;
    public float cutOffSpeed =3; 
    bool isPaused = true;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        rgb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        origScale = transform.localScale;

        isMoving = false;
        if (isPaused) Pause(); else UnPause();
	}
	
	// Update is called once per frame
	void Update () {
        float mag = rgb.velocity.magnitude;
        

        if (!isMoving && mag > cutOffSpeed)
        {
            audioSource.Play();
            isMoving = true;
        }
        else
        if (isMoving && mag < cutOffSpeed)
        {
            audioSource.Stop();
            isMoving = false;
        }
        
        
	}


    public void Pause() {
        isPaused = true;
        rgb.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void UnPause() {
        isPaused = false;
        rgb.constraints = RigidbodyConstraints.None;
    }



    void OnEnable()
    {
        StarController.OnStarUsed += StarUsed;
        StarController.OnInmunityEnds += InmunityEnds;

        SizeDownController.OnSizeDownUsed += SizeDownUsed;
        SizeDownController.OnSizeDownEnds += SizeDownEnds;

    }



    void OnDisable()
    {
        StarController.OnStarUsed -= StarUsed;
        StarController.OnInmunityEnds -= InmunityEnds;

        SizeDownController.OnSizeDownUsed -= SizeDownUsed;
        SizeDownController.OnSizeDownEnds -= SizeDownEnds;
    }


    Vector3 origScale;
    private void SizeDownEnds()
    {

        transform.localScale = origScale;
    }

    private void SizeDownUsed()
    {
        transform.localScale = origScale * 0.5f;
    }

    private void InmunityEnds()
    {
        anim.SetBool("Star", false);

    }

    private void StarUsed()
    {   //anim.
        anim.SetBool("Star", true);
    }
}
