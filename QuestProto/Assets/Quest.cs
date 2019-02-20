using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    EventManager em;
    public string Qname = "QuestName";
    int EventProgress = 0;
    public int Reward = 1000;
    public int Exp = 100;
    public currency c;
    public List<EventManager.Events> Events;
    public List<GameObject> eventGameObjects;
    TextMesh Tname;
    TextMesh Treward;
    TextMesh Texp;
    TextMesh TDuration;
    public Transform heroHolder;
    public GameObject[] Heroes;
    public HeroStats[] heroS;

    private void Start()
    {
        em = FindObjectOfType<EventManager>();
        c = FindObjectOfType<currency>();
        Tname = transform.GetChild(0).GetChild(0).GetComponent<TextMesh>();
        Tname.text = name;
        Treward = transform.GetChild(0).GetChild(1).GetComponent<TextMesh>();
        Treward.text = Reward.ToString()+"g";
        Texp = transform.GetChild(0).GetChild(2).GetComponent<TextMesh>();
        Texp.text = Exp.ToString()+"exp";
        TDuration = transform.GetChild(0).GetChild(3).GetComponent<TextMesh>();
        heroHolder = FindObjectOfType<HeroSelection>().transform;
        Heroes = new GameObject[4];
        heroS = new HeroStats[4];
        for (int i = 0; i < 4; i++)
        {
            Heroes[i] = heroHolder.GetChild(i).gameObject;
            heroS[i] = Heroes[i].GetComponent<HeroStats>();
        }

    }
    public void NextEvent()
    {
        eventGameObjects[EventProgress].SetActive(false);
        EventProgress++;
        if(EventProgress == eventGameObjects.Count)
        {
            Result();
        }
        eventGameObjects[EventProgress].SetActive(true);
    }
    public void AddEventToNext(EventManager.Events eventType)
    {
        Events.Insert(EventProgress++, eventType);
    }
    public void InitQuest()
    {
        for(int i = 0; i < Events.Count; i++)
        {
            GameObject ev = em.GetEvent(Events[i]);
            eventGameObjects.Add(ev);
            ev.GetComponent<Event>().SetQuest(this);

        }
        EventProgress = 0;
        eventGameObjects[EventProgress].SetActive(true);
    }
    void Result()
    {
        c.coins += Reward;
        for(int i = 0; i < heroS.Length; i++)
        {
            heroS[i].exp += Exp;
        }
    }

}
