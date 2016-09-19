using UnityEngine;
using System.Collections;

public class EndLevelCelebration : MonoBehaviour {
    public AudioClip endClip;
    public AudioSource gameMusic;
    public RectTransform canvas;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider ball)
    {

        if (ball.gameObject.tag == "ball")
        {
            Invoke("ChangeMusic",3.0f);
        }

    }

    void ChangeMusic() {
        gameMusic.clip = endClip;
        gameMusic.Play();
        canvas.gameObject.SetActive(true);
        canvas.transform.GetChild(4).gameObject.SetActive(true);
    }
}
