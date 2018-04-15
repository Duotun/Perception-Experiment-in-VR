using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class valuecontrol2d : MonoBehaviour {
    AudioSource ob;
    float topspeed = 8f;
    float currentspeed;
    // Use this for initialization
    void Start()
    {
        ob = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        currentspeed = targetmove2d.speed;
        enginesound();

    }
    void enginesound()
    {
        ob.pitch = currentspeed / topspeed+0.4F;
    }
}
