using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class mulcontrol3 : MonoBehaviour {
    StreamWriter sp;
    int setoff_cnt;
    Rigidbody sub;
    Rigidbody ob;
    // Use this for initialization
    void Start()
    {
        setoff_cnt = 0;
        sp = File.AppendText("c:/upennVR/RECORD.TXT");
        sub = GameObject.Find("Subject3").GetComponent<Rigidbody>();
        ob = GameObject.Find("Object3").GetComponent<Rigidbody>();
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
        sp.WriteLine("VR Emerging -4: The mass ratio is " + sub.mass+ " : " +ob.mass + ". So the blue ball is heavy than the red one.");
        sp.Close();
    }
}
