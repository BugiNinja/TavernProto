using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatDEmo : MonoBehaviour {
    public GameObject[] Heroes;
    public GameObject[] Enemies;
    public HeroStats[] heroS;
    public HeroStats[] enemyS;

    HeroStats heroSelection;
    HeroStats enemySelection;
    
    public GameObject next;
    // Use this for initialization
    void Start () {
        heroS = new HeroStats[Heroes.Length];
        for (int i = 0; i < Heroes.Length; i++)
        {
            heroS[i] = Heroes[i].GetComponent<HeroStats>();
        }
        enemyS = new HeroStats[Enemies.Length];
        for (int i = 0; i < Enemies.Length; i++)
        {
            enemyS[i] = Enemies[i].GetComponent<HeroStats>();
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Hero1")
                {
                    if (hit.transform.GetComponent<HeroStats>().isActive)
                    {
                        if (heroSelection != null)
                        {
                            heroSelection.transform.GetChild(5).gameObject.SetActive(false);
                        }
                        heroSelection = hit.transform.GetComponent<HeroStats>();
                        heroSelection.transform.GetChild(5).gameObject.SetActive(true);
                    }
                }



                else if (hit.transform.name == "Hero2")
                {
                    if (hit.transform.GetComponent<HeroStats>().isActive)
                    {
                        if (heroSelection != null)
                        {
                            heroSelection.transform.GetChild(5).gameObject.SetActive(false);
                        }
                        heroSelection = hit.transform.GetComponent<HeroStats>();
                        heroSelection.transform.GetChild(5).gameObject.SetActive(true);

                    }
                }
                else if (hit.transform.name == "Hero3")
                {
                    if (hit.transform.GetComponent<HeroStats>().isActive)
                    {
                        if (heroSelection != null)
                        {
                            heroSelection.transform.GetChild(5).gameObject.SetActive(false);
                        }
                        heroSelection = hit.transform.GetComponent<HeroStats>();
                        heroSelection.transform.GetChild(5).gameObject.SetActive(true);

                    }
                }
                else if (hit.transform.name == "Hero4")
                {
                    if (hit.transform.GetComponent<HeroStats>().isActive)
                    {
                        if (heroSelection != null)
                        {
                            heroSelection.transform.GetChild(5).gameObject.SetActive(false);
                        }
                        heroSelection = hit.transform.GetComponent<HeroStats>();
                        heroSelection.transform.GetChild(5).gameObject.SetActive(true);

                    }
                }
                else if (hit.transform.name == "Enemy1")
                {
                    if (hit.transform.GetComponent<HeroStats>().isActive)
                    {
                        if (enemySelection != null)
                        {
                            enemySelection.transform.GetChild(5).gameObject.SetActive(false);
                        }
                        enemySelection = hit.transform.GetComponent<HeroStats>();
                        enemySelection.transform.GetChild(5).gameObject.SetActive(true);

                    }
                }
                else if (hit.transform.name == "Enemy2")
                {
                    if (hit.transform.GetComponent<HeroStats>().isActive)
                    {
                        if (enemySelection != null)
                        {
                            enemySelection.transform.GetChild(5).gameObject.SetActive(false);
                        }
                        enemySelection = hit.transform.GetComponent<HeroStats>();
                        enemySelection.transform.GetChild(5).gameObject.SetActive(true);

                    }
                }
                else if (hit.transform.name == "Enemy3")
                {
                    if (hit.transform.GetComponent<HeroStats>().isActive)
                    {
                        if (enemySelection != null)
                        {
                            enemySelection.transform.GetChild(5).gameObject.SetActive(false);
                        }
                        enemySelection = hit.transform.GetComponent<HeroStats>();
                        enemySelection.transform.GetChild(5).gameObject.SetActive(true);

                    }
                }
                else if (hit.transform.name == "Enemy4")
                {
                    if (hit.transform.GetComponent<HeroStats>().isActive)
                    {
                        if (enemySelection != null)
                        {
                            enemySelection.transform.GetChild(5).gameObject.SetActive(false);
                        }
                        enemySelection = hit.transform.GetComponent<HeroStats>();
                        enemySelection.transform.GetChild(5).gameObject.SetActive(true);

                    }

                }
            }



            if (heroSelection != null && enemySelection != null)
            {
                enemySelection.hp -= heroSelection.att;
                Debug.Log(heroSelection.name + " dealed " + heroSelection.att + " DMG to " + enemySelection.name);
                if (heroSelection.heroClass == HeroStats.HeroClass.warrior || heroSelection.heroClass == HeroStats.HeroClass.rogue && enemySelection.heroClass == HeroStats.HeroClass.rogue)
                {
                    heroSelection.hp -= enemySelection.att;
                    Debug.Log(enemySelection.name + " retaliated " + enemySelection.att + " DMG to " + heroSelection.name);
                }
                
                heroSelection.isActive = false;
                heroSelection.transform.GetChild(4).gameObject.SetActive(true);
                heroSelection.transform.GetChild(5).gameObject.SetActive(false);
                enemySelection.transform.GetChild(5).gameObject.SetActive(false);
                heroSelection = null;
                enemySelection = null;

            }
            int heroActionsUsed = 0;
            for(int i = 0; i < heroS.Length; i++)
            {
                if (!heroS[i].isActive)
                {
                    heroActionsUsed++;
                }
                
            }
            CheckEnemyHealth();
            if (heroActionsUsed == heroS.Length)
            {
                //enemyturn here
                for (int i = 0; i < enemyS.Length; i++)
                {
                    if (enemyS[i].isActive)
                    {
                        HeroStats targetHero = heroS[(int)(Random.Range(0, 3))];
                        targetHero.hp -= enemyS[i].att;
                        Debug.Log(enemyS[i].name + " dealed " + enemyS[i].att + " DMG to " + targetHero.name);
                        if (enemyS[i].heroClass == HeroStats.HeroClass.warrior || enemyS[i].heroClass == HeroStats.HeroClass.rogue && targetHero.heroClass == HeroStats.HeroClass.rogue)
                        {
                            enemyS[i].hp -= targetHero.att;
                            Debug.Log(targetHero.name + " retaliated " + targetHero.att + " DMG to " + enemyS[i].name);
                        }

                    }
                }


                for (int i = 0; i < heroS.Length; i++)
                {
                    heroS[i].isActive = true;
                    heroS[i].transform.GetChild(4).gameObject.SetActive(false);
                }
            }
            CheckEnemyHealth();
        }

    }
    void CheckEnemyHealth()
    {
        int deadenemies = 0;
        for (int i = 0; i < enemyS.Length; i++)
        {
            if (enemyS[i].hp > 0)
            {

            }
            else
            {
                deadenemies++;
                enemyS[i].isActive = false;
                Enemies[i].SetActive(false);
                

            }

            if (deadenemies == enemyS.Length)
            {
                next.SetActive(true);
                gameObject.SetActive(false);
                for (int j = 0; j < Enemies.Length; j++)
                {
                    Enemies[j].SetActive(true);
                    enemyS[j].isActive = true;
                    enemyS[j].hp = enemyS[j].maxhp;
                }
                for (int j = 0; j < heroS.Length; j++)
                {
                    heroS[j].isActive = true;
                    heroS[i].transform.GetChild(4).gameObject.SetActive(false);
                    heroS[i].transform.GetChild(5).gameObject.SetActive(false);
                }
            }
        }
    }
}
