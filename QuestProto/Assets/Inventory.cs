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
    public Equipment selection;
    public Equipment SlotSelection;
    public List<int> EquipIds;
    bool first = true;
    // Start is called before the first frame update
    void Start()
    {
        Heroes = new GameObject[4];
        heroS = new HeroStats[4];
        EquipInfo = transform.GetChild(0).GetComponent<TextMesh>();
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
                Heroes[j].transform.localPosition = heroS[j].InventoryLocation;
                heroS[j].transform.GetChild(6).gameObject.SetActive(true);
                heroS[j].StatDisplay.SetActive(true);
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
                        Heroes[j].transform.localPosition = heroS[j].MenuLocation;
                        heroS[j].transform.GetChild(6).gameObject.SetActive(false);
                        heroS[j].StatDisplay.SetActive(false);
                    }
                    first = true;
                    gameObject.SetActive(false);
                }
                if (hit.transform.tag == "HeroEquip")
                {
                    SlotSelection = hit.transform.GetComponent<Equipment>();
                    EquipInfo.text = SlotSelection.etype.ToString() + ": +" + SlotSelection.majorStat + " " + SlotSelection.majorStatName;
                    if (selection != null && SlotSelection.etype == selection.etype)
                    {
                        SlotSelection.CopyValues(selection);
                        SlotSelection.transform.parent.parent.GetComponent<HeroStats>().UpdateEquipStats();
                        selection.transform.GetChild(0).GetComponent<TextMesh>().text = SlotSelection.transform.parent.GetChild(5).GetComponent<TextMesh>().text;
                        SlotSelection = null;
                    }
                }
                else
                {
                    selection = hit.transform.GetComponent<Equipment>();
                    EquipInfo.text = selection.etype.ToString() + ": +" + selection.majorStat + " " + selection.majorStatName;
                    
                }
            }
        }
    }
}
