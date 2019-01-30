using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combat : MonoBehaviour {
    HeroStats hs;
    GameManager gm;
    public Enemy e;
    public Enemy team;
    public int prop1 = 0;
    public int prop2 = 0;
    public GameObject next;
    public GameObject nextCombat;
    public GameObject end;
    public GameObject ok;
    HeroStats hs1;
    HeroStats hs2;
    // Use this for initialization
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.useHpCombat)
        {
            e.gameObject.SetActive(true);
            if(!gm.individualHp)
                team.gameObject.SetActive(true);
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Hero")
                {
                    hs = hit.transform.parent.GetComponent<HeroStats>();
                    if(hs.hp <= 0)
                    {
                        hs.hp = 0;
                        hs = null;
                    }
                }
                if(hit.transform.tag == "CombatEvent" && hs != null)
                {
                    if(hit.transform.parent.name == "CombatEvent2")
                    {
                        prop1 = 50 + hs.dex * 2 + hs.RanAtt * 2;
                        hs1 = hs;
                    }
                    else if(hit.transform.parent.name == "CombatEvent1")
                    {
                        prop2 = 50 + hs.str * 2 + hs.PhyAtt * 2;
                        hs2 = hs;
                    }
                    else if (hit.transform.parent.name == "CombatEvent3")
                    {
                        prop2 = 50 + hs.cha * 2 + hs.MagDef * 2;
                        hs2 = hs;
                    }
                    else if (hit.transform.parent.name == "CombatEvent4")
                    {
                        prop1 = 50 + hs.dex * 2 + hs.RanDef * 2;
                        hs1 = hs;
                    }
                    if(hs1 != null && hs2 != null)
                    {
                        ok.SetActive(true);
                    }
                    
                }
                if (hit.transform.name == "Ok")
                {
                    if(Random.value < ((float)prop1 / 100))
                    {
                        
                        if (gm.useHpCombat)
                        {
                            if(gameObject.name == "CombatDEF")
                            {
                                if (gm.retaliation)
                                {
                                    e.hp--;
                                }
                            }
                            else
                            {
                                e.hp--;
                            }
                        }
                        else
                        {
                            gm.QuestPoints++;
                            hs1.hp--;
                        }
                    }
                    else
                    {
                        if (gm.useHpCombat)
                        {
                            if (gameObject.name == "CombatDEF")
                            {
                                if (gm.individualHp)
                                {
                                    hs1.hp--;
                                }
                                else
                                {
                                    team.hp--;
                                }
                            }
                            else
                            {
                                if (gm.retaliation)
                                {
                                    if (gm.individualHp)
                                    {
                                        hs1.hp--;
                                    }
                                    else
                                    {
                                        team.hp--;
                                    }
                                }
                            }
                        }
                        else
                        {
                            hs1.hp--;
                            hs1.hp--;
                        }
                        
                    }
                    if (Random.value < ((float)prop2 / 100))
                    {
                        if (gm.useHpCombat)
                        {
                            if (gameObject.name == "CombatDEF")
                            {
                                if (gm.retaliation)
                                {
                                    e.hp--;
                                }
                            }
                            else
                            {
                                e.hp--;
                            }
                        }
                        else
                        {
                            gm.QuestPoints++;
                            hs2.hp--;
                        }

                    }
                    else
                    {
                        if (gm.useHpCombat)
                        {
                            if (gameObject.name == "CombatDEF")
                            {
                                if (gm.individualHp)
                                {
                                    hs2.hp--;
                                }
                                else
                                {
                                    team.hp--;
                                }
                            }
                            else
                            {
                                if (gm.retaliation)
                                {
                                    if (gm.individualHp)
                                    {
                                        hs2.hp--;
                                    }
                                    else
                                    {
                                        team.hp--;
                                    }
                                }
                            }
                        }
                        else
                        {
                            hs2.hp--;
                            hs2.hp--;
                        }

                    }
                    hs1 = null;
                    hs2 = null;
                    prop1 = 0;
                    prop2 = 0;
                    if (gm.useHpCombat)
                    {
                        if (e.hp <= 0)
                        {
                            e.hp = 5;
                            team.hp = 10;
                            e.gameObject.SetActive(false);
                            team.gameObject.SetActive(false);
                            gm.QuestPoints += 2;
                            next.SetActive(true);
                        }
                        else if (team.hp <= 0)
                        {
                            e.hp = 5;
                            team.hp = 10;
                            e.gameObject.SetActive(false);
                            team.gameObject.SetActive(false);
                            gm.QuestPoints = 0;
                            end.SetActive(true);
                        }
                        else
                        {
                            nextCombat.SetActive(true);
                        }
                    }
                    else
                    {
                        nextCombat.SetActive(true);
                    }
                    hit.transform.gameObject.SetActive(false);
                    gameObject.SetActive(false);

                }
            }
        }
    }
}
