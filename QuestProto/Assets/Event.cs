using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    public Quest currentQuest;
    public GameObject[] Heroes;
    public Transform heroHolder;
    public HeroStats[] heroS;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void SetQuest(Quest q)
    {
        currentQuest = q;
        Heroes = currentQuest.Heroes;
        heroS = currentQuest.heroS;
        heroHolder = currentQuest.heroHolder;
    }
}
