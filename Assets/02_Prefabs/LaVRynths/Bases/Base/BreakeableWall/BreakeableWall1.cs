using UnityEngine;
using System.Collections;
using System;

public class BreakeableWall1 : MonoBehaviour {

    public Transform bW2;
    float maxAccDam = 0.5f;
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
            pS.Play();

            if (transform.parent.localRotation.eulerAngles.y > 89.0f)
                accumulatedDamage += Mathf.Abs(ball.rigidbody.velocity.x);
            else
                accumulatedDamage += Mathf.Abs(ball.rigidbody.velocity.z);


            Debug.Log("Wall 1");
            Debug.Log("Velocity of ball at impact =" + ball.rigidbody.velocity);
            Debug.Log("accumulatedDamage = " + accumulatedDamage);


           
            if (accumulatedDamage >= maxAccDam)
            {
                Debug.Log("++++++++++++++++++Wall 1 destroyed++++++++++++++");

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