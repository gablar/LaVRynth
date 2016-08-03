using UnityEngine;
using System.Collections;

public class PlatformsController : MonoBehaviour {
    //the board main object
    public Transform boardTrans;
	// Use this for initialization
	void Start () {
        transform.position = boardTrans.position;

	}
	
}
