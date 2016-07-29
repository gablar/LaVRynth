using UnityEngine;
using System.Collections;

public class BallGeneratorController : MonoBehaviour {
    public Transform ball;
    public Transform SpawnLocation;
    Vector3 initScale;
	// Use this for initialization
	void Start () {
        //GameObject ball =  GameObject.Find("ball");
        initScale = transform.localScale;

    }

    // Update is called once per frame
    void Update () {
        /*if (Input.GetMouseButtonDown(0)) {
            Instantiate(ball,transform.position,Quaternion.identity);
        }*/
    }

    public void OnPointerEnter() {
        transform.localScale = initScale * 2.0f;
    }

    public void OnPointerExit()
    {
        transform.localScale = initScale;
    }

    public void OnSubmit() {
        GameObject gameBall = GameObject.FindGameObjectWithTag("ball");
        if (gameBall) { }
        else
        {
            Rigidbody ballrgb = (Rigidbody)Instantiate(ball,SpawnLocation.position, Quaternion.identity);
            ballrgb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }


}
