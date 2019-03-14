using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInput : MonoBehaviour
{
    GameManager gm;
    public GameObject QuestList;
    public GameObject CombatDemo;
    public GameObject inventory;
    QuestTimer qt;

    void Start()
    {
        qt = FindObjectOfType<QuestTimer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "QuestList"&&qt.q == null)
                {
                    QuestList.SetActive(true);
                    gameObject.SetActive(false);
                }
                if (hit.transform.name == "CombatDemo"&&qt.q == null)
                {
                    CombatDemo.SetActive(true);
                    gameObject.SetActive(false);
                }
                if (hit.transform.name == "Inventory")
                {
                    inventory.SetActive(true);
                    
                    gameObject.SetActive(false);
                }
                if (hit.transform.name == "EventButton")
                {
                    gameObject.SetActive(false);
                    hit.transform.gameObject.SetActive(false);
                    qt.q.NextEvent();
                }
            }
        }
    }
}
