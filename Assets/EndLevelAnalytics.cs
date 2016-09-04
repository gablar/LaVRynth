using UnityEngine;
using UnityEngine.Analytics;
using System.Collections.Generic;
using System.Collections;


public class EndLevelAnalytics : MonoBehaviour {
    static int level = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider ball) {
        level++;
        Analytics.CustomEvent("LevelOpened", new Dictionary<string, object>
  {
    { "levelUnlockedTime", Time.fixedTime },
    {"levelUnlockNum",level},
  });
    }
}
