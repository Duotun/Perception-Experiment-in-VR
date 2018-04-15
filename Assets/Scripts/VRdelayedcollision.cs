using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRdelayedcollision : MonoBehaviour {
    public AudioClip tmp;
    private Rigidbody Sub;
    private Rigidbody Ob;
    private float relamass;
    private Vector3 revert;
    public float time;
    // Use this for initialization
    void Start()
    {
        Sub = GameObject.Find("Subject").GetComponent<Rigidbody>();
        Ob = GameObject.Find("Object").GetComponent<Rigidbody>();
        relamass = 2 * Sub.mass / (Sub.mass + Ob.mass);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Object")
        {
            print("ku");
            revert = Ob.velocity * relamass;
            Ob.velocity = Vector3.zero;
            AudioSource.PlayClipAtPoint(tmp, transform.position, 1.0f);
            StartCoroutine(wait());
            // Debug.Log(collision.collider.name);
           
        }

    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(time);
        Ob.velocity = revert;
    }
}
