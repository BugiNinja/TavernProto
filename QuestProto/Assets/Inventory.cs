using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] Heroes;
    public Transform heroHolder;
    public HeroStats[] heroS;
    public TextMesh EquipInfo;
    public GameObject next;
    bool first = true;
    // Start is called before the first frame update
    void Start()
    {
        Heroes = new GameObject[4];
        heroS = new HeroStats[4];
        for (int i = 0; i < 4; i++)
        {
            Heroes[i] = heroHolder.GetChild(i).gameObject;
            heroS[i] = Heroes[i].GetComponent<HeroStats>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (first)
        {
            heroHolder.gameObject.SetActive(true);
            for (int j = 0; j < heroS.Length; j++)
            {
                
                heroS[j].transform.GetChild(6).gameObject.SetActive(true);
            }
            first = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Exit")
                {
                    next.SetActive(true);
                    for (int j = 0; j < heroS.Length; j++)
                    {
                        heroS[j].transform.GetChild(6).gameObject.SetActive(false);
                    }
                    heroHolder.gameObject.SetActive(false);
                    first = true;
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
