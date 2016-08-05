using UnityEngine;
using System.Collections;
using System;

public class ListenerManager : MonoBehaviour {

    public AudioClip LevelMusic;
    public AudioClip inmunityMusic;
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


    }




    void OnDisable()
    {
        StarController.OnStarUsed -= StarUsed;
        StarController.OnInmunityEnds -= InmunityEnds;



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
