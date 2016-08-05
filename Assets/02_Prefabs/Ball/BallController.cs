﻿using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
    AudioSource audioSource;
    Rigidbody rgb;
    Animator anim;
    bool isMoving;
    bool isPaused = true;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        rgb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        isMoving = false;
        if (isPaused) Pause(); else UnPause();
	}
	
	// Update is called once per frame
	void Update () {
        float mag = rgb.velocity.magnitude;
        

        if (isMoving && mag <6)
        {
            audioSource.pitch = mag/2;
        }
        else
        if (!isMoving && mag > 0)
        {
            audioSource.pitch = mag;
            audioSource.Play();
            isMoving = true;
        }
        else
        if (isMoving  &&  mag<=0) {
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

    }

    void OnDisable()
    {
        StarController.OnStarUsed -= StarUsed;
        StarController.OnInmunityEnds -= InmunityEnds;
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
