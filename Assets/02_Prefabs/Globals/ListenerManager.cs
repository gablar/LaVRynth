using UnityEngine;
using System.Collections;
using System;

public class ListenerManager : MonoBehaviour {

    public AudioClip LevelMusic;
    public AudioClip inmunityMusic;
    public AudioClip SizeDownMusic;
    AudioSource aSource;
	// Use this for initialization
	void Start () {
        aSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
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

    private void SizeDownEnds()
    {

        aSource.clip = LevelMusic;
        aSource.Play();
    }

    private void SizeDownUsed()
    {
        aSource.clip = SizeDownMusic;
        aSource.Play();
    }

    private void InmunityEnds()
    {
        aSource.clip = LevelMusic;
        aSource.Play();

    }

    private void StarUsed()
    {
        aSource.clip = inmunityMusic;
        aSource.Play();
    }
}
