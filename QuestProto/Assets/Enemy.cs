using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int hp = 5;
    TextMesh tm;
	// Use this for initialization
	void Start () {
        tm = GetComponentInChildren<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
        tm.text = hp.ToString() + "hp";
	}
}
