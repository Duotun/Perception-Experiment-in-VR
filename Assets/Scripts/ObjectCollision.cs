using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour {
    private Rigidbody2D tp;
    private AudioSource pp;
    private Rigidbody2D tp1;
	// Use this for initialization
	void Start () {
        tp = GameObject.Find("Object").GetComponent<Rigidbody2D>();
        pp = GameObject.Find("Object").GetComponent<AudioSource>();
        tp1 = GameObject.Find("Object").GetComponent<Rigidbody2D>();
	}
    float cnt = 0;
	// Update is called once per frame
	void Update () {
        print(cnt);
        if (tp.velocity.magnitude != 0 && cnt == 0)
        {
            //pp.Play();
            cnt++;
        }
        else
        {
            if (pp.isPlaying == true)
            {

                cnt += Time.deltaTime/6f;
                pp.volume = 1.0f / cnt;
            }
        }
	}
}
