using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MenuStatus : MonoBehaviour
{
    HeroStats hs;
    TextMesh timer;
    float hpTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        hs = transform.parent.GetComponent<HeroStats>();
        hs.transform.localPosition = hs.MenuLocation;
        timer = transform.GetChild(0).GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hs.inQuest)
        {
            timer.gameObject.SetActive(true);
            HpRegen();
        }
        else
        {
            timer.gameObject.SetActive(false);
        }
        if(hpTimer <=0 && hs.hp < hs.maxhp)
        {
            
            hpTimer = 5;
        }
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            InstantHpRegen();
        }
    }
    void HpRegen()
    {
        if (hpTimer > 0)
        {
            hpTimer -= Time.deltaTime;
            
            if (hpTimer < 0)
            {
                hpTimer = 0;
                hs.hp++;
            }
            timer.text = hpTimer.ToString();
        }
    }
    void InstantHpRegen()
    {
        hs.hp = hs.maxhp;
        hpTimer = 0;
    }
}
