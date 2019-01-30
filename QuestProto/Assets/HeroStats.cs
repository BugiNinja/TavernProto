using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStats : MonoBehaviour {
    public int hp = 10;
    public int maxhp = 10;
    public int vit = 100;
    public int str = 10;
    public int att = 2;
    public int dex = 10;
    public int kno = 10;
    public int cha = 10;
    public int PhyAtt = 0;
    public int PhyDef = 0;
    public int RanAtt = 0;
    public int RanDef = 0;
    public int MagAtt = 0;
    public int MagDef = 0;
    public bool isActive;
    public enum HeroClass {warrior, mage, rogue};
    public HeroClass heroClass;
    // Use this for initialization
    void Start () {
		if(heroClass == HeroClass.warrior)
        {
            PhyAtt = Mathf.FloorToInt(str * 1.0f + dex * 0.25f);
            PhyDef = Mathf.FloorToInt(str * 0.84f + dex * 0.42f);
            RanAtt = Mathf.FloorToInt(dex * 0.6f + str * 0.25f);
            RanDef = Mathf.FloorToInt(dex * 0.5f + str * 0.15f);
            MagAtt = Mathf.FloorToInt(kno * 0.17f + cha * 0.33f);
            MagDef = Mathf.FloorToInt(kno * 0.17f + cha * 0.33f);
        }
        else if(heroClass == HeroClass.mage)
        {
            PhyAtt = Mathf.FloorToInt(str * 0.6f + dex * 0.25f);
            PhyDef = Mathf.FloorToInt(str * 0.5f + dex * 0.15f);
            RanAtt = Mathf.FloorToInt(dex * 1.0f + str * 0.25f);
            RanDef = Mathf.FloorToInt(dex * 0.84f + str * 0.42f);
            MagAtt = Mathf.FloorToInt(kno * 0.17f + cha * 0.33f);
            MagDef = Mathf.FloorToInt(kno * 0.17f + cha * 0.33f);
        }
        else
        {
            PhyAtt = Mathf.FloorToInt(str * 0.33f + dex * 0.17f);
            PhyDef = Mathf.FloorToInt(str * 0.33f + dex * 0.17f);
            RanAtt = Mathf.FloorToInt(dex * 0.6f + str * 0.25f);
            RanDef = Mathf.FloorToInt(dex * 0.5f + str * 0.15f);
            MagAtt = Mathf.FloorToInt(kno * 1f + cha * 0.25f);
            MagDef = Mathf.FloorToInt(kno * 0.25f + cha * 1f);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
