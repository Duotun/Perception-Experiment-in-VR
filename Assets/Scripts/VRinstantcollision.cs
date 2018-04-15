using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRinstantcollision : MonoBehaviour {
    public AudioClip tmp;
    private Rigidbody Sub;
    private Rigidbody Ob;
    private float relamass;
    private Vector3 record;
    int cnt;
    // Use this for initialization
    void Start()
    {
        Sub = this.GetComponent<Rigidbody>();
        Ob = GameObject.FindGameObjectWithTag("Obj").GetComponent<Rigidbody>();
        relamass = 2 * Sub.mass / (Sub.mass + Ob.mass);
        cnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
         if (cnt==0)
        {
            record = Sub.velocity;
        }
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obj")
        {
            cnt++;
            collision.rigidbody.velocity = relamass*record;
            Sub.velocity = (Sub.mass - Ob.mass) / (Sub.mass + Ob.mass)*record;
            //Ob.velocity *= relamass;
           // if (collision.collider.name == "Object")
           // {
                // Debug.Log(collision.collider.name);
                AudioSource.PlayClipAtPoint(tmp, transform.position, 1.0f);
           // }
        }
    }
}
