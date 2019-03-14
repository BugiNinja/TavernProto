using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    EventManager em;
    QuestTimer qt;
    public string Qname = "QuestName";
    public int EventProgress = 0;
    public int Reward = 1000;
    public int Exp = 100;
    public int duration = 30;
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
    bool extraEvent;
    bool waitForEvent;

    private void Start()
    {
        qt = FindObjectOfType<QuestTimer>();
        em = FindObjectOfType<EventManager>();
        c = FindObjectOfType<currency>();
        Tname = transform.GetChild(0).GetChild(0).GetComponent<TextMesh>();
        Tname.text = name;
        Treward = transform.GetChild(0).GetChild(1).GetComponent<TextMesh>();
        Treward.text = Reward.ToString()+"g";
        Texp = transform.GetChild(0).GetChild(2).GetComponent<TextMesh>();
        Texp.text = Exp.ToString()+"exp";
        TDuration = transform.GetChild(0).GetChild(3).GetComponent<TextMesh>();
        TDuration.text = duration / 60 + ":" + duration;
        heroHolder = FindObjectOfType<HeroSelection>().transform;
        Heroes = new GameObject[4];
        heroS = new HeroStats[4];
        for (int i = 0; i < 4; i++)
        {
            Heroes[i] = heroHolder.GetChild(i).gameObject;
            heroS[i] = Heroes[i].GetComponent<HeroStats>();
        }

    }
    public void EventEnd()
    {
        eventGameObjects[EventProgress].SetActive(false);
        EventProgress++;
        
        if(qt.NextEventTime(EventProgress))
        {
            NextEvent();
        }
        else if (extraEvent)
        {
            extraEvent = false;
            NextEvent();
        }
        else
        {
            waitForEvent = true;
        }
    }
    public void NextEvent()
    {
        if (EventProgress >= eventGameObjects.Count)
        {
            Result();
        }
        eventGameObjects[EventProgress].SetActive(true);
        waitForEvent = false;
    }
    public void AddEventToNext(EventManager.Events eventType)
    {
        GameObject ev = em.GetEvent(eventType);
        eventGameObjects.Insert(EventProgress + 1, ev);
        extraEvent = true;
    }
    public void InitQuest()
    {
        for(int i = 0; i < Events.Count; i++)
        {
            GameObject ev = em.GetEvent(Events[i]);
            eventGameObjects.Add(ev);
            ev.GetComponent<Event>().SetQuest(this);

        }
        for(int i = 0; i < heroS.Length; i++)
        {
            heroS[i].inQuest = true;
        }
        EventProgress = 0;
        eventGameObjects[EventProgress].SetActive(true);
        qt.SetQuestTimer(duration, eventGameObjects.Count, this);
    }
    void Result()
    {
        qt.NullQuestTimer();
        c.coins += Reward;
        for(int i = 0; i < heroS.Length; i++)
        {
            heroS[i].exp += Exp;
            heroS[i].inQuest = false;
        }
        eventGameObjects.Clear();
        GetComponentInParent<QuestList>().EndQuest();
    }
    void ResetQuest()
    {
        eventGameObjects = null;
    }
    public bool WaitForEvent()
    {
        return waitForEvent;
    }
}
