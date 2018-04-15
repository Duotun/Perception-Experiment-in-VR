using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class valuecontrollVR : MonoBehaviour {
    AudioSource ob;
    float topspeed = 6f;
    float currentspeed;
    Rigidbody now;
    // Use this for initialization
    void Start()
    {
        ob = GetComponent<AudioSource>();
        now = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //print(now.velocity.magnitude);
        currentspeed =now.velocity.magnitude ;
        enginesound();

    }
    void enginesound()
    {
        ob.pitch = currentspeed / topspeed;
    }
}
