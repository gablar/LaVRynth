using UnityEngine;
using System.Collections;

public class StarController : MonoBehaviour {
    public delegate void StarUsed();
    public static event StarUsed OnStarUsed;

    public delegate void InmunityEnds();
    public static event InmunityEnds OnInmunityEnds;

    public float inmunityTime;

    MeshRenderer mRend;
    BoxCollider bColl;
    Animator anim;

	// Use this for initialization
	void Start () {
        mRend = GetComponent<MeshRenderer>();
        bColl = GetComponent<BoxCollider>();
        anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider ball) {
        if (ball.gameObject.tag == "ball")
        {
            DisableStar();

            if (OnStarUsed != null)
            {
                OnStarUsed();
            }

            Invoke("EndInmunity", inmunityTime);
        }
    }

    void EndInmunity() {

        if (OnInmunityEnds != null)
        {
            OnInmunityEnds();
        }

        Invoke("EnableStar", 5);
    }

    private void DisableStar()
    {
        anim.SetBool("isActive", false);
        bColl.enabled = false;
        mRend.enabled = false;
    }

    private void EnableStar()
    {
        bColl.enabled = true;
        mRend.enabled = true;
        anim.SetBool("isActive", true);

    }


}
