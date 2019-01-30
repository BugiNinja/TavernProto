using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPtext : MonoBehaviour {

    HeroStats hs;
    TextMesh tm;
	// Use this for initialization
	void Start () {
        tm = GetComponent<TextMesh>();
        hs = transform.parent.GetComponent<HeroStats>();
	}
	
	// Update is called once per frame
	void Update () {

        tm.text = hs.hp.ToString();
	}
}
