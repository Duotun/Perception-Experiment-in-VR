﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class mulcontrol4 : MonoBehaviour {
    StreamWriter sp;
    int setoff_cnt;
    Rigidbody sub;
    Rigidbody ob;
    // Use this for initialization
    void Start()
    {
        setoff_cnt = 0;
        sp = File.AppendText("c:/upennVR/RECORD.TXT");
        sub = GameObject.Find("Subject4").GetComponent<Rigidbody>();
        ob = GameObject.Find("Object4").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (setoff_cnt == 0)
        {
            write();
            setoff_cnt++;
        }
    }
    void write()
    {
        if (VRTK.Examples.UI_Interactions_2.cnt_multiple == 1)
        {
            sp.WriteLine("VR Emerging : The track is " + 2.0f + " Meters long");
        }
        sp.WriteLine("VR Emerging -5: The mass ratio is " + sub.mass +" : " +ob.mass + ". So the blue ball is heavy than the red one.");
        sp.Close();
    }
}
