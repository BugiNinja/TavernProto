using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chance2 : MonoBehaviour {

    combat c;
    TextMesh tm;
    // Use this for initialization
    void Start () {
        c = transform.parent.parent.GetComponent<combat>();
        tm = GetComponent<TextMesh>();
    }
	
	// Update is called once per frame
	void Update () {
        tm.text = c.prop2.ToString() + "%";

    }
}
