using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStats : MonoBehaviour {
    public int id = 0;
    public int lv = 0;
    public int exp = 1;
    public int hp = 10;
    public int maxhp = 10;
    public int vit = 100;
    public int str = 10;
    public int att = 2;
    public int dex = 10;
    public int kno = 10;
    public int cha = 10;
    int b_vit = 100;
    int b_str = 10;
    int b_dex = 10;
    int b_kno = 10;
    int b_cha = 10;
    public bool inQuest;
    public bool isActive;
    public enum HeroClass {warrior, mage, rogue};
    public HeroClass heroClass;
    public Vector3 MenuLocation;
    public Vector3 CombatLocation;
    public Vector3 InventoryLocation = new Vector3(6, -3, 0);
    public Equipment[] equipments;
    public GameObject StatDisplay;
    public bool updateDatabase;
    DatabaseManager dm;
    
    // Use this for initialization
    void Awake () {
        CombatLocation = transform.localPosition;
	}
    private void Start()
    {
        dm = FindObjectOfType<DatabaseManager>();
        dm.GetHeroSave(this);
        if(transform.childCount > 6)
        {
            equipments = new Equipment[5];
            for(int i = 0; i < 5; i++)
            {
                equipments[i] = transform.GetChild(6).GetChild(i).GetComponent<Equipment>();
            }
            StatDisplay = transform.GetChild(7).gameObject;
        }
    }
    
    // Update is called once per frame
    void Update () {

        if (updateDatabase)
        {
            dm.UpdateHeroSave(this);
            updateDatabase = false;
        }

        if (exp > Mathf.Pow(lv * 10, 2))
        {
            lv++;
            if(heroClass == HeroClass.warrior)
            {
                b_vit = 100 + (lv * 3);
                maxhp = Mathf.FloorToInt(vit / 10);
                b_str = 20 + (lv * 3);
                att = Mathf.FloorToInt(str / 10);
                b_dex = 10 + (lv * 2);
                b_kno = 5 + (lv * 1);
                b_cha = 10 + (lv * 2);
            }
            else if (heroClass == HeroClass.mage)
            {
                b_vit = 60 + (lv * 2);
                maxhp = Mathf.FloorToInt(vit / 10);
                b_str = 10 + (lv * 1);
                b_dex = 10 + (lv * 1);
                b_kno = 15 + (lv * 3);
                att = Mathf.FloorToInt(kno / 10);
                b_cha = 10 + (lv * 3);
                
            }
            else if (heroClass == HeroClass.rogue)
            {
                b_vit = 70 + (lv * 2);
                maxhp = Mathf.FloorToInt(vit / 10);
                b_str = 10 + (lv * 2);
                b_dex = 20 + (lv * 3);
                att = Mathf.FloorToInt(dex / 10);
                b_kno = 5 + (lv * 1);
                b_cha = 15 + (lv * 3);
            }
            vit = b_vit;
            str = b_str;
            dex = b_dex;
            kno = b_kno;
            cha = b_cha;
            UpdateEquipStats();
            exp = exp - (int)Mathf.Pow((lv - 1) * 10, 2);
        }
	}
    public void UpdateEquipStats()
    {
        vit = b_vit;
        str = b_str;
        dex = b_dex;
        kno = b_kno;
        cha = b_cha;
        for (int i = 0;i < 5; i++)
        {
            switch (equipments[i].majorStatName)
            {
                case "str":
                    str += equipments[i].majorStat;
                    break;
                case "dex":
                    dex += equipments[i].majorStat;
                    break;
                case "int":
                    kno += equipments[i].majorStat;
                    break;
                case "cha":
                    cha += equipments[i].majorStat;
                    break;
                case "vit":
                    vit += equipments[i].majorStat;
                    break;
            }
        }
        maxhp = Mathf.FloorToInt(vit / 10);
        if (heroClass == HeroClass.warrior)
        {
            att = Mathf.FloorToInt(str / 10);
        }
        else if (heroClass == HeroClass.mage)
        {
            att = Mathf.FloorToInt(kno / 10);
        }
        else if (heroClass == HeroClass.rogue)
        {
            att = Mathf.FloorToInt(dex / 10);
        }
    }
    public int TotalEXP()
    {
        int TotalEXP;
        TotalEXP = exp;
        for(int i= 1; i <= lv; i++)
        {
            TotalEXP += (int)Mathf.Pow((i - 1) * 10, 2);
        }
        return TotalEXP;
    }

}
