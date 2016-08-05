using UnityEngine;
using System.Collections;

public class Inmune : MonoBehaviour {
    private bool isInmune;
    public float inmunityTime;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool IsInmune
    {
        get
        {
            return isInmune;
        }

        set
        {
            isInmune = value;
        }
    }

}
