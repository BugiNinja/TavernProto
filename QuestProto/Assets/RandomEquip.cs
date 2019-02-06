using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEquip : MonoBehaviour
{
    Equipment e;
    Inventory inv;
    void Start()
    {
        inv = transform.parent.GetComponent<Inventory>();
        e = gameObject.GetComponent<Equipment>();
        
        e.id = (int)Random.Range(1, 100);
        if (inv.EquipIds.Count > 98) { }
        else {
            for (int i = 0; i < inv.EquipIds.Count; i++)
            {
                if (inv.EquipIds[i] == e.id)
                {
                    e.id = (int)Random.Range(1, 100);
                    i = 0;
                }
            }
            inv.EquipIds.Add(e.id);
        }
        e.tier = (byte)Random.Range(1, 3);
        int major = (int)Random.Range(1, 5);
        switch (major)
        {
            case 1:
                e.majorStatName = "str";
                e.str = (int)Random.Range(1, 3) * e.tier;
                e.majorStat = e.str;
                break;
            case 2:
                e.majorStatName = "dex";
                e.dex = (int)Random.Range(1, 3) * e.tier;
                e.majorStat = e.dex;
                break;
            case 3:
                e.majorStatName = "int";
                e.kno = (int)Random.Range(1, 3) * e.tier;
                e.majorStat = e.kno;
                break;
            case 4:
                e.majorStatName = "cha";
                e.cha = (int)Random.Range(1, 3) * e.tier;
                e.majorStat = e.cha;
                break;
            case 5:
                e.majorStatName = "vit";
                e.vit = (int)Random.Range(3, 6) * e.tier;
                e.majorStat = e.vit;
                break;
        }

    }

    void Update()
    {
        
    }
}
