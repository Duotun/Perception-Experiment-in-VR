using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitcollision : MonoBehaviour {
    public AudioClip tmp;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
      
        if (collision.collider.name == "Object")
         {
           // Debug.Log(collision.collider.name);
            AudioSource.PlayClipAtPoint(tmp, transform.position, 1.0f);
        }

    }
}
