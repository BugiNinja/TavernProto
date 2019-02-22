using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class event1 : MonoBehaviour {

    GameManager gm;
    public GameObject next;
	// Use this for initialization
	void Start () {
        gm = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Yes")
                {
                    Debug.Log("yes");
                    gm.QuestPoints++;
                    next.SetActive(true);
                    gameObject.SetActive(false);
                }
                if (hit.transform.name == "No")
                {
                    Debug.Log("no");
                    next.SetActive(true);
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
