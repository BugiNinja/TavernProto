using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyInit : MonoBehaviour
{
    HeroStats es;

    // Start is called before the first frame update
    void Start()
    {
        es = gameObject.GetComponent<HeroStats>();
        InitEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InitEnemy()
    {
        es.maxhp = (int)Random.Range(1, 4);
        es.hp = es.maxhp;
        es.att = (int)Random.Range(1, 3);
        es.heroClass = (HeroStats.HeroClass)(int)Random.Range(0, 2);
    }
}
