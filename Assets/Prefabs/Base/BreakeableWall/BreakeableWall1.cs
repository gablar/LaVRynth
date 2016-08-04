using UnityEngine;
using System.Collections;

public class BreakeableWall1 : MonoBehaviour {

    public Transform bW2;
    public float maxAccDam = 5;
    float accumulatedDamage = 0;

    MeshRenderer mRend;
    Collider coll;
    AudioSource aSource;
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
            accumulatedDamage += ball.relativeVelocity.magnitude;
            Debug.Log(accumulatedDamage);
            pS.Play();
            if (accumulatedDamage >= maxAccDam)
            {
                aSource.Play();
                coll.enabled = false;
                mRend.enabled = false;
                bW2.gameObject.SetActive(true);
                Destroy(gameObject,.5f);
            }
        }
    }
}