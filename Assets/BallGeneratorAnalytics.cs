using UnityEngine;
using UnityEngine.Analytics;
using System.Collections.Generic;
using System.Collections;

public class BallGeneratorAnalytics : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnSubmit() {
        Analytics.CustomEvent("BoardReset", new Dictionary<string, object>
  {
    { "TimeOfBoardReset", Time.fixedTime },
  });
    }
}
