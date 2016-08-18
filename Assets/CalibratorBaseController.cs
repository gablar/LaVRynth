using UnityEngine;
using System.Collections;

public class CalibratorBaseController : MonoBehaviour {
    private bool isPaused = true;
    public Transform OVRCamera;
    MeshRenderer mesh;
    BoxCollider coll;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        coll = GetComponent<BoxCollider>();
        mesh.enabled = true;
        
    }


    // Use this for initialization

    void FixedUpdate() {
        if (isPaused) {
            transform.rotation = OVRCamera.rotation;
        }

    }

    /*public void OnPointerEnter() {
        mesh.enabled = true;

    }

    public void OnPointerExit() {
        mesh.enabled = false;

    }
    */
    private void DisableComponents()
    {
        mesh.enabled = false;
        coll.enabled = false;
    }

    private void EnableComponents()
    {
        mesh.enabled = false;
        coll.enabled = false;
    }




    void OnEnable()
    {
        PauseController.OnPausePressed += PausePressed;

    }
    void OnDisable()
    {
        PauseController.OnPausePressed -= PausePressed;
    }
    private void PausePressed()
    {
        if (isPaused)
        {

            UnPause();
        }
        else
        {

            Pause();
        }
    }

    void Pause()
    {
        isPaused = true;
        coll.enabled = true;
       
    }

    void UnPause()
    {
        isPaused = false;
        coll.enabled = false;

    }
}
