using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChoiceEvent : Event
{
    [Tooltip("This will Show in Quest")]
    public int TextReferenceId = 001;
    TextManager tm;
    TextMesh DescText;
    public enum Stats {strength, dexterity, inteligence, charisma , none}
    
    public enum Reward {money, armor, weapon, exp, hp, extraEvent}
    [Serializable]
    public class ChooseReward
    {
        [Tooltip ("For Extra Events 0 = combat, 1 = pathfind, 2 = social, 3 = conflict")]
        public Reward RewardType;
        public int Amount;

        public ChooseReward(Reward newReward, int newAmount)
        {
            RewardType = newReward;
            Amount = newAmount;
        }
    }
    public ChooseReward[] Choice1;
    public Stats testedStat1;
    public ChooseReward[] Choice2;
    public Stats testedStat2;

    void Start()
    {
        tm = FindObjectOfType<TextManager>();
        DescText = transform.GetChild(0).GetComponent<TextMesh>();
        DescText.text = tm.GetText(TextReferenceId);
        CreateChoice(Choice1 , 1);
        CreateChoice(Choice2 , 2);
    }

    void CreateChoice(ChooseReward[] Choice, int index)
    {
        GameObject C1 = GameObject.CreatePrimitive(PrimitiveType.Quad);
        C1.name = "Choice" + index;
        C1.transform.parent = transform;
        C1.transform.localScale = new Vector3(5, 1.5f, 0);
        C1.transform.localPosition = new Vector3(0, 2 + ((index-1)*-1.7f), 0);
        C1.AddComponent<BoxCollider>();

        CreateChoiceText(Choice, C1.transform, 0);
        if (Choice.Length > 1)
        {
            CreateChoiceText(Choice, C1.transform, 1);
        }
    }

    void CreateChoiceText(ChooseReward[] Choice, Transform parent, int index)
    {
        GameObject merit = new GameObject();
        merit.transform.parent = parent;
        merit.transform.localPosition = new Vector3(-0.4f + (index*0.8f), 0.25f, 0);
        merit.transform.localScale = new Vector3(0.03f, 0.1f, 0);
        merit.AddComponent<MeshRenderer>();
        TextMesh meritT = merit.AddComponent<TextMesh>();
        meritT.color = Color.black;
        meritT.fontSize = 32;
        if (index != 0)
        {
            meritT.anchor = TextAnchor.UpperRight;
            meritT.alignment = TextAlignment.Right;
        }
        switch ((int)Choice[index].RewardType)
        {
            case 0:
                meritT.text = Choice[index].Amount + "g";
                break;
            case 1:
                meritT.text = "armor";
                break;
            case 2:
                meritT.text = "weapon";
                break;
            case 3:
                meritT.text = Choice[index].Amount + "exp";
                break;
            case 4:
                meritT.text = Choice[index].Amount + "hp";
                break;
            case 5:
                meritT.text = (EventManager.Events)Choice[index].Amount + "";
                break;
            default:
                break;
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
                    if (TestStat(testedStat1))
                    {
                        if(testedStat1 == Stats.none)
                        {
                            GetReward(Choice1[0].RewardType, Choice1[0].Amount);
                            if(Choice1.Length > 1)
                                GetReward(Choice1[1].RewardType, Choice1[1].Amount);
                        }
                        else
                        {
                            GetReward(Choice1[0].RewardType, Choice1[0].Amount);
                        }
                    }
                    else
                    {
                        if (Choice1.Length > 1)
                            GetReward(Choice1[1].RewardType, Choice1[1].Amount);
                    }
                    currentQuest.EventEnd();
                }
                else if (hit.transform.name == "Choice2")
                {
                    if (TestStat(testedStat2))
                    {
                        if (testedStat1 == Stats.none)
                        {
                            GetReward(Choice2[0].RewardType, Choice2[0].Amount);
                            if (Choice2.Length > 1)
                                GetReward(Choice2[1].RewardType, Choice2[1].Amount);
                        }
                        else
                        {
                            GetReward(Choice2[0].RewardType, Choice2[0].Amount);
                        }
                    }
                    else
                    {
                        if (Choice1.Length > 1)
                            GetReward(Choice2[1].RewardType, Choice2[1].Amount);
                    }
                    currentQuest.EventEnd();
                }
            }
        }
    }

    void GetReward(Reward type, int amount)
    {
        switch ((int)type)
        {
            case 0:
                currentQuest.c.coins += amount;
                break;
            case 1:
                Debug.Log("armor");
                //give player armor
                break;
            case 2:
                Debug.Log("weapon");
                //give player weapon
                break;
            case 3:
                for(int i = 0;i < Heroes.Length; i++)
                {
                    Heroes[i].GetComponent<HeroStats>().exp += amount;
                }
                break;
            case 4:
                for (int i = 0; i < Heroes.Length; i++)
                {
                    Heroes[i].GetComponent<HeroStats>().hp += amount;

                    //!!!!!!!!!ADD HP CHECK HERE!!!!!!!!!!

                }
                break;
            case 5:
                Debug.Log("Add " + (EventManager.Events)amount + "");
                currentQuest.AddEventToNext((EventManager.Events)amount);
                break;
        }
    }

    bool TestStat(Stats stat)
    {
        switch ((int)stat)
        {
            case 0:
                return TestStr();
            case 1:
                return TestDex();
            case 2:
                return TestKno();
            case 3:
                return TestCha();
            case 4:
                return true;
        }
        return false;
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
}
