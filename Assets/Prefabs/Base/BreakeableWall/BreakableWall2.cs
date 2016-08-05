using UnityEngine;
using System.Collections;

public class BreakableWall2 : MonoBehaviour {

    // Use this for initialization
    public float maxAccDam = 5;
    float accumulatedDamage = 0;

    MeshRenderer mRend;
    Collider coll;
    AudioSource aSource;
    public AudioClip tapClip;
    public AudioClip breakedClip;
    public ParticleSystem pS;

    void Start () {
        aSource = GetComponent<AudioSource>();
        mRend = GetComponent<MeshRenderer>();
        coll = GetComponent<Collider>();

    }

    void OnCollisionEnter(Collision ball)
    {
        if (ball.gameObject.tag == "ball")
        {
            accumulatedDamage += ball.impulse.magnitude;

            aSource.clip = breakedClip;
            aSource.Play();
            pS.Play();

            if (accumulatedDamage >= maxAccDam)
            {
                aSource.Play();
                coll.enabled = false;
                mRend.enabled = false;
                Destroy(transform.parent.gameObject,.5f);
            }
        }
    }
}
