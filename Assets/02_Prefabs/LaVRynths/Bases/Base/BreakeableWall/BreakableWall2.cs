using UnityEngine;
using System.Collections;

public class BreakableWall2 : MonoBehaviour {

    // Use this for initialization
    float maxAccDam = 1.0f;
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

            aSource.clip = breakedClip;
            aSource.Play();
            pS.Play();

            if (transform.parent.localRotation.eulerAngles.y > 89.0f)
                accumulatedDamage += Mathf.Abs(ball.rigidbody.velocity.x);
            else
                accumulatedDamage += Mathf.Abs(ball.rigidbody.velocity.z);

            Debug.Log("Wall 2");
            Debug.Log("Velocity of ball at impact =" + ball.rigidbody.velocity);
            Debug.Log("accumulatedDamage = " + accumulatedDamage);

            if (accumulatedDamage >= maxAccDam)
            {
                aSource.Play();
                coll.enabled = false;
                mRend.enabled = false;
                Destroy(gameObject,.5f);
            }
        }
    }
}
