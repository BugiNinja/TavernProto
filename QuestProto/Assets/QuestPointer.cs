using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPointer : MonoBehaviour {
    public GameObject gmo;
    public GameObject pointer;
    GameManager gm;
	// Use this for initialization
	void Start () {
        gm = gmo.GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        pointer.transform.localPosition = new Vector3(0, gm.QuestPoints, 0);

	}
}
