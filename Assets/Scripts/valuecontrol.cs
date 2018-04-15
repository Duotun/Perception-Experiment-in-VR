using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class valuecontrol : MonoBehaviour {
    AudioSource ob;
    float topspeed=36f;
    float currentspeed;
	// Use this for initialization
	void Start () {
        ob = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        currentspeed = regulartargetmoveVR.revervespeed;
        enginesound();
        
	}
    void enginesound()
    {
        ob.pitch = currentspeed / topspeed;
    }
}
