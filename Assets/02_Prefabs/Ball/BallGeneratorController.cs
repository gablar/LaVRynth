using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BallGeneratorController : MonoBehaviour {
    public Transform ball;
    public Transform SpawnLocation;
    public Transform lavBase;

    Vector3 initScale;
    AudioSource aSource;
    public bool isPaused = true;
    BoxCollider bCollider;
    MeshRenderer mRend;

   


    // Use this for initialization
    void Start () {
        //GameObject ball =  GameObject.Find("ball");
        initScale = transform.localScale;
        bCollider = GetComponent<BoxCollider>();
        mRend = GetComponent<MeshRenderer>();
        aSource = GetComponent<AudioSource>();
       // if (isPaused) Pause(); else UnPause();

    }

    // Update is called once per frame


    public void OnPointerEnter() {

        if (isPaused) { transform.localScale = initScale * 1.2f; }
    }

    public void OnPointerExit()
    {   
        if (isPaused) transform.localScale = initScale;
    }

    public void OnSubmit() {
        GameObject gameBall = GameObject.FindGameObjectWithTag("ball");
        if (!gameBall && isPaused) {
            aSource.Play();
            lavBase.rotation = Quaternion.identity;
            Instantiate(ball,SpawnLocation.position, Quaternion.identity);
        }


        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


    }

    public void UnPause() {
        transform.localScale = initScale;
        bCollider.enabled = false;
        mRend.enabled = false;
        isPaused = false;
    }

    public void Pause() {
        bCollider.enabled = true;
        mRend.enabled = true;
        isPaused = true;
    }
}
