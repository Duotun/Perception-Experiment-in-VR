using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRaheadcollision : MonoBehaviour {
    public AudioClip tmp;
    private Rigidbody Sub;
    private Rigidbody Ob;
    private SphereCollider Sup;
    private SphereCollider Op;
    private float relamass;
    private Transform sut;
    private Transform ot;
    private float dis;
    public float offset;
    // Use this for initialization
    void Start()
    {
        Sub = GameObject.Find("Subject").GetComponent<Rigidbody>();
        Ob = GameObject.Find("Object").GetComponent<Rigidbody>();
        Sup = GameObject.Find("Subject").GetComponent<SphereCollider>();
        Op = GameObject.Find("Object").GetComponent<SphereCollider>();
        sut = GameObject.Find("Subject").GetComponent<Transform>();
        ot = GameObject.Find("Object").GetComponent<Transform>();
        relamass = 2 * Sub.mass / (Sub.mass + Ob.mass);
    }
    int cnt = 0;
    // Update is called once per frame
    void Update()
    {
        dis = (sut.position - ot.position).magnitude - Sup.radius * transform.localScale.magnitude / 2 - Op.radius * ot.transform.localScale.magnitude/2 ;  // 
        //print(dis);
        if (dis<=offset&&cnt==0)
        {
            // Debug.Log(collision.collider.name);
            AudioSource.PlayClipAtPoint(tmp, transform.position, 1.0f);
            cnt++;
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Ob.velocity *= relamass;
        //AudioSource.PlayClipAtPoint(tmp, transform.position, 1.0f);

    }
}
