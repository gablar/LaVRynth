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

            anim.Stop();
            bColl.enabled = false;
            mRend.enabled = false;

            if (OnSizeDownUsed != null)
            {
                Debug.Log("Size Down Used messege sent");
                OnSizeDownUsed();
            }

            Invoke("EndSizeDown", sizeDownTime);
        }
    }

    void EndSizeDown()
    {

        if (OnSizeDownEnds != null)
        {
            Debug.Log("Size Down Ends messege sent");

            OnSizeDownEnds();
        }
        Destroy(gameObject);
    }
}
