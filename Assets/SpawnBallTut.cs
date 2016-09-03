using UnityEngine;
using System.Collections;

public class SpawnBallTut : MonoBehaviour {
    public RectTransform rTrans;
    // Use this for initialization
    public void OnSubmit() {
        rTrans.gameObject.SetActive(false);
    }
}
