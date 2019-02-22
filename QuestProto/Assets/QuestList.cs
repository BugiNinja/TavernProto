using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestList : MonoBehaviour
{
    public List<Quest> quests;
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            quests.Add(transform.GetChild(i).GetComponent<Quest>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                for(int i = 0; i < quests.Count; i++)
                {
                    if (hit.transform.parent.name == "Quest"+(i+1))
                    {
                        HideQuestInfo();
                        quests[i].InitQuest();
                    }
                }
            }
        }
    }
    public void EndQuest()
    {
        ShowQuestInfo();
        menu.SetActive(true);
        gameObject.SetActive(false);
    }
    void HideQuestInfo()
    {
        for(int i= 0; i < quests.Count; i++)
        {
            quests[i].transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    void ShowQuestInfo()
    {
        for (int i = 0; i < quests.Count; i++)
        {
            quests[i].transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
