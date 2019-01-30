using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{


    GameManager gm;
    TextMesh tm;
    public GameObject next;
    // Use this for initialization
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        tm = GetComponent<TextMesh>();
    }
    // Update is called once per frame
    void Update()
    {
        if (gm.QuestPoints >= 4)
        {
            tm.text = "Perfect!";
        }
        else if (gm.QuestPoints >= 2)
        {
            tm.text = "Good!";
        }
        else
        {
            tm.text = "FAil!";
        }
        if (Input.GetMouseButtonDown(0))
        {
            gm.QuestPoints = 0;
            next.SetActive(true);
            transform.parent.gameObject.SetActive(false);
        }
    }
}
