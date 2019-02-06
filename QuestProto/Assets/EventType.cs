using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventType : MonoBehaviour
{
    Quest q;
    bool first;
    
    void Start()
    {
        q = transform.parent.parent.GetComponent<Quest>();
    }

    private void Update()
    {
        if (!first)
        {
            for (int i = 0; i < q.Events.Count; i++)
            {
                GameObject QuestType = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                QuestType.transform.parent = transform;
                QuestType.transform.localPosition = new Vector3(1 + i, -3, 0);
                QuestType.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                switch ((int)q.Events[i])
                {
                    case 0:
                        QuestType.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
                        break;
                    case 1:
                        QuestType.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 1);
                        break;
                    case 2:
                        QuestType.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 1);
                        break;
                    case 3:
                        QuestType.GetComponent<Renderer>().material.color = new Color(1, 0.5f, 0, 1);
                        break;
                }
                
            }
            first = true;
        }
        
        
    }
}
