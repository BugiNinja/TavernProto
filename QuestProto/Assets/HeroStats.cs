using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStats : MonoBehaviour {
    int lv = 1;
    public int exp = 0;
    public int hp = 10;
    public int maxhp = 10;
    public int vit = 100;
    public int str = 10;
    public int att = 2;
    public int dex = 10;
    public int kno = 10;
    public int cha = 10;
    public bool isActive;
    public enum HeroClass {warrior, mage, rogue};
    public HeroClass heroClass;
    public Vector3 CombatLocation;
    public Vector3 InventoryLocation = new Vector3(6, -3, 0);
    // Use this for initialization
    void Awake () {
        CombatLocation = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (exp > Mathf.Pow(lv * 10, 2))
        {
            lv++;
            if(heroClass == HeroClass.warrior)
            {
                vit = 100 + (lv * 3);
                maxhp = Mathf.FloorToInt(vit / 10);
                str = 20 + (lv * 3);
                att = Mathf.FloorToInt(str / 10);
                dex = 10 + (lv * 2);
                kno = 5 + (lv * 1);
                cha = 10 + (lv * 2);
            }else if (heroClass == HeroClass.mage)
            {
                vit = 70 + (lv * 2);
                maxhp = Mathf.FloorToInt(vit / 10);
                str = 10 + (lv * 2);
                dex = 20 + (lv * 3);
                att = Mathf.FloorToInt(dex / 10);
                kno = 5 + (lv * 1);
                cha = 15 + (lv * 3);
            }
            else if (heroClass == HeroClass.rogue)
            {
                vit = 60 + (lv * 2);
                maxhp = vit / 10;
                str = 10 + (lv * 1);
                dex = 10 + (lv * 1);
                kno = 15 + (lv * 3);
                att = Mathf.FloorToInt(kno / 10);
                cha = 10 + (lv * 3);
            }
            exp = exp - (int)Mathf.Pow(lv - 1 * 10, 2);
        }
	}

}
