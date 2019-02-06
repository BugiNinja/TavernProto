using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getId : MonoBehaviour
{
    TextMesh tm;
    Equipment e;
    // Start is called before the first frame update
    void Start()
    {
        tm = gameObject.GetComponent<TextMesh>();
        e = transform.parent.GetComponent<Equipment>();
    }

    // Update is called once per frame
    void Update()
    {
        tm.text = e.id.ToString();
    }
}
