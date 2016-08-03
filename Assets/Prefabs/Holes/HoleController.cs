using UnityEngine;
using System.Collections;

public class HoleController : MonoBehaviour {

    AudioSource aSource;
    // Use this for initialization
    void Start () {
        aSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnTriggerEnter(Collider other) {
        Destroy(other.gameObject);
        aSource.Play();

    }
}
