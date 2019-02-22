using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetStr : MonoBehaviour
{
    HeroStats hs;
    TextMesh tm;
    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponent<TextMesh>();
        hs = transform.parent.parent.GetComponent<HeroStats>();
    }

    // Update is called once per frame
    void Update()
    {
        tm.text = "Str:" + hs.str.ToString();
    }
}
