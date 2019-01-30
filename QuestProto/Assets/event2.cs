using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class event2 : MonoBehaviour {
    public GameObject[] Heroes;
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
                    if (TestCha())
                    {
                        gm.QuestPoints++;
                    }
                    else
                    {
                        gm.QuestPoints--;
                    }
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

    bool TestCha()
    {
        int bestCha = 0;
        for(int i = 0; i < Heroes.Length; i++)
        {
            HeroStats hs = Heroes[i].GetComponent<HeroStats>();
            if(hs.cha > bestCha)
            {
                bestCha = hs.cha;
            }
        }
        Debug.Log(bestCha);
        if(Random.value < ((float)bestCha * 8/100))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
