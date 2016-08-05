using UnityEngine;
using System.Collections;

public class BreakeableWall1 : MonoBehaviour {

    public Transform bW2;
    public float maxAccDam = 5;
    float accumulatedDamage = 0;

    MeshRenderer mRend;
    Collider coll;
    AudioSource aSource;
    public AudioClip tapClip;
    public AudioClip breakedClip;
    public ParticleSystem pS;
	// Use this for initialization
	void Start () {
        aSource = GetComponent<AudioSource>();
        mRend = GetComponent<MeshRenderer>();
        coll = GetComponent<Collider>();
	}

    void OnCollisionEnter(Collision ball) {

        if (ball.gameObject.tag == "ball")
        {
            aSource.clip = tapClip;
            aSource.Play();
            accumulatedDamage += ball.relativeVelocity.magnitude;
           
            pS.Play();
            if (accumulatedDamage >= maxAccDam)
            {   
                aSource.clip = breakedClip;
                aSource.Play();
                coll.enabled = false;
                mRend.enabled = false;
                bW2.gameObject.SetActive(true);
                Destroy(gameObject,.5f);
            }
        }
    }
}