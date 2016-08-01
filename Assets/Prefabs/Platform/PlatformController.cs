using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {
    private bool isPaused = true;
    private Vector3 initScale;

    // Use this for initialization
    void Start () {

        initScale = transform.localScale;

    }

    // Update is called once per frame
    void Update () {
	
	}
    public void OnPointerEnter()
    {

        if (isPaused) transform.localScale = initScale * 1.2f;
    }

    public void OnPointerExit()
    {
        if (isPaused) transform.localScale = initScale;
    }

    public void OnSubmit()
    {
       // if (!gameBall && isPaused)
           
    }

    public void Pause() {
        isPaused = true;
    }

    public void UnPause() {
        isPaused = false;
    }
}
