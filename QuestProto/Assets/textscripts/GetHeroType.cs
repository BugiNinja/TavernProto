using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHeroType : MonoBehaviour
{
    HeroStats hs;
    TextMesh tm;
    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponent<TextMesh>();
        hs = transform.parent.GetComponent<HeroStats>();
    }

    // Update is called once per frame
    void Update()
    {
        switch ((int)hs.heroClass)
        {
            case 0:
                tm.text = "War";
                break;
            case 1:
                tm.text = "Mag";
                break;
            case 2:
                tm.text = "Rog";
                break;
        }
    }
}
