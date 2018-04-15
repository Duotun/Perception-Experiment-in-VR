using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class counter : MonoBehaviour {
    public static int pass_pcnt;
    public static int pass_cnt;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void record1(int tmp1)
    {
        pass_cnt = tmp1;
       
    }
    void record2(int tmp2)
    {
        pass_pcnt = tmp2;
    }
}
