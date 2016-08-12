using UnityEngine;
using System.Collections;
using System;

public class LevelObjectController : MonoBehaviour {
    private bool isPaused = false;
    private Vector3 initScale;
    AudioSource aSource;
    Animator anim;

    // Use this for initialization
    void Start () {
        initScale = transform.localScale;
        aSource = GetComponent<AudioSource>();
        

    }

    // Update is called once per frame
    void Update () {
	
	}

    public void OnPointerEnter()
    {
       

        if (isPaused)
        {
            transform.localScale = initScale * 3.0f;
            anim.SetBool("isSpining", false);
        }
    }

    public void OnPointerExit()
    {


        if (isPaused) {
            transform.localScale = initScale;
            anim.SetBool("isSpining", true);
        }
    }

    public void OnSubmit()
    {

        Debug.Log("Submited");

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


    }

    void OnEnable()
    {
        PauseController.OnPausePressed += PausePressed;

        anim = GetComponent<Animator>();

    }


    void OnDisable()
    {
        PauseController.OnPausePressed -= PausePressed;

    }


    private void PausePressed()
    {
        if (isPaused) {
         
            UnPause();
        } else {

            Pause(); }
    }

    void Pause() {
        isPaused = true;
        anim.SetBool("isSpining", true);
    }

    void UnPause() {
        isPaused = false;
        anim.SetBool("isSpining", false);
    }
}
