using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInput : MonoBehaviour
{
    GameManager gm;
    public GameObject quest1;
    public GameObject quest2;
    public GameObject inventory;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Quest1")
                {
                    quest1.SetActive(true);
                    quest1.transform.GetChild(0).gameObject.SetActive(true);
                    gameObject.SetActive(false);
                }
                if (hit.transform.name == "Quest2")
                {
                    quest2.SetActive(true);
                    quest2.transform.GetChild(0).gameObject.SetActive(true);
                    gameObject.SetActive(false);
                }
                if (hit.transform.name == "Inventory")
                {
                    inventory.SetActive(true);
                    
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
