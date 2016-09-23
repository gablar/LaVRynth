using UnityEngine;
using System.Collections;

public class InnerWallController : MonoBehaviour {
    AudioSource aSource;
	// Use this for initialization
	void Start () {
        aSource = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void OnTriggerEnter(Collider ball) {
        if (ball.gameObject.tag == "ball") {
            aSource.Play();
        }
    }
}
