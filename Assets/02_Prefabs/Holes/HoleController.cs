using UnityEngine;
using System.Collections;

public class HoleController : MonoBehaviour {

    AudioSource aSource;
    // Use this for initialization

    bool isInmune;
    void Start () {
        aSource = GetComponent<AudioSource>();

    }


    void OnTriggerEnter(Collider other) {
        if (!isInmune && other.gameObject.tag == "ball")
        {
            Destroy(other.gameObject);
            aSource.Play();
        }

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

        isInmune = false;
    }

    private void StarUsed()
    {
        isInmune = true;
    }
}
