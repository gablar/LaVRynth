using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CelebrationTextController : MonoBehaviour {
    Text thisText;
	// Use this for initialization
	void Start () {
        thisText = GetComponent<Text>();
        Invoke("RollCredits",3.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void RollCredits() {
        thisText.enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);

    }

}
