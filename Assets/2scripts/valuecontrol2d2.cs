using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class valuecontrol2d2 : MonoBehaviour {

    AudioSource ob;
    float topspeed = 8f;
    float currentspeed;
    Rigidbody2D sub;
    Rigidbody2D obb;
    float relamass;
    // Use this for initialization
    void Start()
    {
        ob = GetComponent<AudioSource>();
        obb = GameObject.Find("Object").GetComponent<Rigidbody2D>();
        sub = GameObject.Find("Subject").GetComponent<Rigidbody2D>();
        relamass = 2 * sub.mass / (sub.mass + obb.mass);
    }

    // Update is called once per frame
    void Update()
    {
        currentspeed = targetmove2d.speed * relamass;
        enginesound();

    }
    void enginesound()
    {
        ob.pitch = currentspeed / topspeed+0.4F;
    }
}
