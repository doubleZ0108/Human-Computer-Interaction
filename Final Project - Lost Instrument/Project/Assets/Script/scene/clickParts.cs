using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class clickParts : MonoBehaviour
{
    private DateTime t1, t2;
    public bool startToChange = false;
    public bool setDoubldClickValuable = true;

    public int levelToMove;
    

    // Start is called before the first frame update
    void Start()
    {
        t1 = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown()
    {
        if (setDoubldClickValuable)
        {
            t2 = DateTime.Now;
            if (t2 - t1 < new TimeSpan(0, 0, 0, 0, 500))
            {
                //你的代码
                startToChange = true;
            }
            t1 = t2;
        }
    }
}
