using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BallGeneratorController : MonoBehaviour {
    public Transform ball;
    public Transform SpawnLocation;

    Vector3 initScale;
    AudioSource aSource;
    public bool isPaused = true;
    SphereCollider sCollider;
    MeshRenderer mRend;


    // Use this for initialization
    void Start () {
        //GameObject ball =  GameObject.Find("ball");
        initScale = transform.localScale;
        sCollider = GetComponent<SphereCollider>();
        mRend = GetComponent<MeshRenderer>();
        aSource = GetComponent<AudioSource>();
        if (isPaused) Pause(); else UnPause();

    }

    // Update is called once per frame


    public void OnPointerEnter() {

        if (isPaused) transform.localScale = initScale * 2.0f;
    }

    public void OnPointerExit()
    {   
        if (isPaused) transform.localScale = initScale;
    }

    public void OnSubmit() {
        GameObject gameBall = GameObject.FindGameObjectWithTag("ball");
        if (!gameBall && isPaused) {
            aSource.Play();
            Instantiate(ball,SpawnLocation.position, Quaternion.identity);
        }


        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


    }

    public void UnPause() {
        transform.localScale = initScale;
        sCollider.enabled = false;
        mRend.enabled = false;
        isPaused = false;
    }

    public void Pause() {
        sCollider.enabled = true;
        mRend.enabled = true;
        isPaused = true;
    }
}
