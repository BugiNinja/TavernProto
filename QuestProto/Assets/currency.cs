using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class currency : MonoBehaviour
{

    TextMesh tm;
    public int coins = 0;


    void Start()
    {
        tm = GetComponent<TextMesh>();
    }

   
    void Update()
    {
        tm.text = "Gold: "+coins.ToString();
    }
}
