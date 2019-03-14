using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTimer : MonoBehaviour
{
    float QuestTime;
    float NextEvent;
    float QuestLength;
    int EventCount;
    public GameObject EventButton;
    public Quest q;
    public TextMesh PartyInfo;
    public TextMesh EventInfo;
    public MenuInput mi;
    // Start is called before the first frame update
    void Start()
    {
        EventButton.SetActive(false);
        mi = FindObjectOfType<MenuInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (q != null)
        {
            if (QuestLength > QuestTime)
            {
                QuestTime += Time.deltaTime;
                PartyInfo.text = "In Quest " + (int)QuestTime / 60 + "." + (int)QuestTime + "/" + (int)QuestLength / 60 + "." + (int)QuestLength;
            }
            if (QuestTime > NextEvent && q.WaitForEvent()&& mi.isActiveAndEnabled)
            {
                
                EventButton.SetActive(true);
                if(QuestLength <= QuestTime)
                {
                    EventInfo.text = "Quest Complete";
                }
                else
                {
                    EventInfo.text = "New Event";
                }
            }
        }
        else
        {
            PartyInfo.text = "No Quest";
        }

    }
    public void SetQuestTimer(float QuestLength, int EventCount, Quest quest)
    {
        this.QuestLength = QuestLength;
        this.EventCount = EventCount;
        q = quest;
        QuestTime = 0;
    }
    void SetNextEvent(float time)
    {
        NextEvent = time;
    }
    public bool NextEventTime(int nextevent)
    {
        NextEvent = QuestLength / EventCount * (nextevent+1);
        if (QuestTime > NextEvent || QuestLength <= QuestTime)
        {
            return true;
        }
        return false;
    }
    public void NullQuestTimer()
    {
        q = null;
    }
}
