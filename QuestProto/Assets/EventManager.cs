using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public enum Events { combat, pathfind, social, conflict }
    public List<GameObject> combatEvents;
    public List<GameObject> pathfindEvents;
    public List<GameObject> socialEvents;
    public List<GameObject> conflictEvents;
    private void Start()
    {
        for(int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            combatEvents.Add(transform.GetChild(0).GetChild(i).gameObject);
        }
        for (int i = 0; i < transform.GetChild(1).childCount; i++)
        {
            pathfindEvents.Add(transform.GetChild(1).GetChild(i).gameObject);
        }
        for (int i = 0; i < transform.GetChild(2).childCount; i++)
        {
            socialEvents.Add(transform.GetChild(2).GetChild(i).gameObject);
        }
        for (int i = 0; i < transform.GetChild(3).childCount; i++)
        {
            conflictEvents.Add(transform.GetChild(3).GetChild(i).gameObject);
        }
    }
    public GameObject GetEvent(Events eventType)
    {
        GameObject e;
        switch ((int)eventType)
        {
            case 0:
                e = GetRandom(combatEvents);
                break;
            case 1:
                e = GetRandom(pathfindEvents);
                break;
            case 2:
                e = GetRandom(socialEvents);
                break;
            case 3:
                e = GetRandom(conflictEvents);
                break;
            default:
                e = null;
                break;

        }
        return e;
    }
    GameObject GetRandom(List<GameObject> eventlist)
    {
        return eventlist[Random.Range(0,eventlist.Count)];
    }

}
