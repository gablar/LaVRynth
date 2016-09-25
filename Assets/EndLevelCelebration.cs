using UnityEngine;
using System.Collections;

public class EndLevelCelebration : MonoBehaviour {
    public AudioClip endClip;
    public AudioSource gameMusic;
    public RectTransform canvas;
    BaseControllerKong baseControllerKong;
	// Use this for initialization
	void Start () {
        baseControllerKong = transform.parent.GetComponent<BaseControllerKong>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider ball)
    {

        if (ball.gameObject.tag == "ball")
        {
            //disable pauseText for the current platform
            int thisPlatform = baseControllerKong.platform - 1;
            transform.parent.parent.GetChild(1).GetChild(thisPlatform).GetChild(3).gameObject.SetActive(false);
            //activate credits
            canvas.gameObject.SetActive(true);
            canvas.transform.GetChild(4).gameObject.SetActive(true);
            Invoke("ChangeMusic",1.0f);
        }

    }

    void ChangeMusic() {


        gameMusic.clip = endClip;
        gameMusic.Play();


        
    }
}
