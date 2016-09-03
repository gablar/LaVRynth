using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogController : MonoBehaviour {
    Button button;
	// Use this for initialization
	void Start () {
        button = GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseEnter() {
        button.transform.GetChild(0).GetComponent<Text>().text = "Mouse Enter";
        Debug.Log("Mouse Entered");
    }

    void OnMouseExit()
    {
        button.transform.GetChild(0).GetComponent<Text>().text = "Mouse Exit";
        Debug.Log("Mouse Exited");
    }
}
