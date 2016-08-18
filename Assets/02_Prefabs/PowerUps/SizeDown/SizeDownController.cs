using UnityEngine;
using System.Collections;

public class SizeDownController : MonoBehaviour {
    public delegate void SizeDownUsed();
    public static event SizeDownUsed OnSizeDownUsed;

    public delegate void SizeDownEnds();
    public static event SizeDownEnds OnSizeDownEnds;

    public float sizeDownTime;

    MeshRenderer mRend;
    BoxCollider bColl;
    Animator anim;

    // Use this for initialization
    void Start()
    {
        mRend = GetComponent<MeshRenderer>();
        bColl = GetComponent<BoxCollider>();
        anim = GetComponent<Animator>();

    }


    void OnTriggerEnter(Collider ball)
    {
        if (ball.gameObject.tag == "ball")
        {
            DisableSizeDown();

            if (OnSizeDownUsed != null)
            {
                OnSizeDownUsed();
            }

            Invoke("EndSizeDown", sizeDownTime);
        }
    }

    private void DisableSizeDown()
    {
        anim.SetBool("isActive", false);
        bColl.enabled = false;
        mRend.enabled = false;
    }

    private void EnableSizeDown()
    {
        bColl.enabled = true;
        mRend.enabled = true;
        anim.SetBool("isActive",true);

    }

    void EndSizeDown()
    {

        if (OnSizeDownEnds != null)
        { 
            OnSizeDownEnds();
        }
        Invoke("EnableSizeDown", 15);
    }

}
