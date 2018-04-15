using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class valuecontrole2 : MonoBehaviour {
    AudioSource ob;
    float topspeed = 36f;
    float currentspeed;
    Rigidbody sub;
    Rigidbody obb;
    float relamass;
    // Use this for initialization
    void Start()
    {
        ob = GetComponent<AudioSource>();
        obb = GameObject.Find("Object").GetComponent<Rigidbody>();
        sub = GameObject.Find("Subject").GetComponent<Rigidbody>();
        relamass = 2 * sub.mass/(sub.mass + obb.mass);
    }

    // Update is called once per frame
    void Update()
    {
        currentspeed = regulartargetmoveVR.revervespeed*relamass;
        enginesound();

    }
    void enginesound()
    {
        ob.pitch = currentspeed / topspeed;
    }
}
