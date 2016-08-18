using UnityEngine;
using System.Collections;

public class EndLevelController : MonoBehaviour {

    AudioSource aSource;
    public LevelObjectController levelToOpen;
     
	// Use this for initialization
	void Start () {
        aSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider ball) {
        
        if (ball.gameObject.tag == "ball") {
            levelToOpen.Unlock();
            aSource.Play();
            Destroy(ball.gameObject);
            GetComponent<MeshRenderer>().enabled = false;
            Destroy(gameObject, 2);
        }

    }
}
