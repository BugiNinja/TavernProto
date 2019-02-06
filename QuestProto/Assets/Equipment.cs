using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public enum Etype { Weapon, Head, Torso, Legs, Charm}
    public Etype etype;
    public int id;
    public byte tier;
    public int str;
    public int dex;
    public int kno;
    public int cha;
    public int vit;
    public string majorStatName;
    public int majorStat;
    public Equipment HeroEquip;

    void Start()
    {
        if(str < dex)
        {
            majorStat = dex;
            majorStatName= "dex";
        }
        else if (str < kno)
        {
            majorStat = kno;
            majorStatName = "int";
        }
        else if (str < cha)
        {
            majorStat = cha;
            majorStatName = "cha";
        }
        else if (str < vit)
        {
            majorStat = vit;
            majorStatName = "vit";
        }
        else
        {
            majorStat = str;
            majorStatName = "str";
        }
    }

    public void CopyValues(Equipment e)
    {
        if(HeroEquip != null)
        {
            HeroEquip.EmptyEquipment();
            HeroEquip.transform.parent.parent.GetComponent<HeroStats>().UpdateEquipStats();
        }
        HeroEquip = this;
        id = e.id;
        tier = e.tier;
        str = e.str;
        dex = e.dex;
        kno = e.kno;
        cha = e.cha;
        vit = e.vit;
        majorStatName = e.majorStatName;
        majorStat = e.majorStat;
        transform.GetChild(1).GetComponent<TextMesh>().text = id.ToString();
    }
    public void EmptyEquipment()
    {
        id = 0;
        tier = 0;
        str = 0;
        dex = 0;
        kno = 0;
        cha = 0;
        vit = 0;
        transform.GetChild(1).GetComponent<TextMesh>().text = "e";
}
}
