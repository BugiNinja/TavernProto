using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChoiceEvent : MonoBehaviour
{
    Quest currentQuest;
    GameObject[] Heroes;
    public enum Stats {strength, dexterity, inteligence, charisma }
    public enum Reward {money, armor, weapon, exp, hp, extraEvent}
    [Serializable]
    public class ChooseReward
    {
        public Reward RewardType;
        public int Amount;

        public ChooseReward(Reward newReward, int newAmount)
        {
            RewardType = newReward;
            Amount = newAmount;
        }
    }
    public ChooseReward[] Choice1;
    public ChooseReward[] Choice2;

    void Start()
    {
        
        GameObject C1 = GameObject.CreatePrimitive(PrimitiveType.Quad);
        C1.transform.parent = transform;
        C1.transform.localScale = new Vector3(5, 1.5f, 0);
        C1.transform.localPosition = new Vector3(0, 2, 0);
        GameObject demerit = new GameObject();
        demerit.transform.parent = C1.transform;
        demerit.AddComponent<MeshRenderer>();
        TextMesh demeritT = demerit.AddComponent<TextMesh>();
        demeritT.color = Color.black;
        switch ((int)Choice1[0].RewardType)
        {
            case 0:
                demeritT.text = Choice1[0].Amount+"g";
                break;
            case 1:
                demeritT.text = "armor";
                break;
            case 2:
                demeritT.text = "weapon";
                break;
            case 3:
                demeritT.text = Choice1[0].Amount + "exp";
                break;
            case 4:
                demeritT.text = Choice1[0].Amount + "hp";
                break;
            case 5:
                demeritT.text = (EventManager.Events)Choice1[0].Amount + "";
                break;
            default:
                break;
        }
        if (Choice1.Length > 1)
        {
            GameObject merit = new GameObject();
            merit.transform.parent = C1.transform;
            demerit.AddComponent<MeshRenderer>();
            TextMesh meritT = demerit.AddComponent<TextMesh>();
        }

    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Choice1")
                {
                    if (TestCha())
                    {
                        
                    }
                    else
                    {
                       
                    }
                    currentQuest.NextEvent();
                }
                if (hit.transform.name == "Choice2")
                {
                    Debug.Log("no");

                    currentQuest.NextEvent();
                }
            }
        }
    }

    bool TestCha()
    {
        int bestCha = 0;
        for (int i = 0; i < Heroes.Length; i++)
        {
            HeroStats hs = Heroes[i].GetComponent<HeroStats>();
            if (hs.cha > bestCha)
            {
                bestCha = hs.cha;
            }
        }
        if (UnityEngine.Random.value < ((float)bestCha * 8 / 100))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    bool TestStr()
    {
        int bestStr = 0;
        for (int i = 0; i < Heroes.Length; i++)
        {
            HeroStats hs = Heroes[i].GetComponent<HeroStats>();
            if (hs.str > bestStr)
            {
                bestStr = hs.cha;
            }
        }
        if (UnityEngine.Random.value < ((float)bestStr * 8 / 100))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    bool TestDex()
    {
        int bestDex = 0;
        for (int i = 0; i < Heroes.Length; i++)
        {
            HeroStats hs = Heroes[i].GetComponent<HeroStats>();
            if (hs.dex > bestDex)
            {
                bestDex = hs.cha;
            }
        }
        if (UnityEngine.Random.value < ((float)bestDex * 8 / 100))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    bool TestKno()
    {
        int bestKno = 0;
        for (int i = 0; i < Heroes.Length; i++)
        {
            HeroStats hs = Heroes[i].GetComponent<HeroStats>();
            if (hs.kno > bestKno)
            {
                bestKno = hs.kno;
            }
        }
        if (UnityEngine.Random.value < ((float)bestKno * 8 / 100))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void SetQuest(Quest q)
    {
        currentQuest = q;
        Heroes = currentQuest.Heroes;
    }
}
