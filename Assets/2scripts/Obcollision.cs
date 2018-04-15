
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obcollision : MonoBehaviour {
	private AudioSource pp;
	private Rigidbody tt;
	int cnt=0;
	float dis;
	private Transform  cam;
	float updis;
	// Use this for initialization
	void Start () {
		pp = GameObject.Find ("Object").GetComponent<AudioSource> ();
		pp.volume = 0;
		cam= GameObject.Find ("Main Camera").GetComponent<Transform> ();
		tt = GameObject.Find ("Object").GetComponent<Rigidbody> ();
		dis = Vector3.Distance (transform.position,cam.position);
	}
	
	// Update is called once per frame
	void Update () {
		if (cnt == 2) {
			updis=Vector3.Distance (transform.position,cam.position);
			pp.volume=Mathf.Clamp01 (targetmove.revervespeed/ updis*1.6f);

			    //这个问题可以晚解决 因为 声音四十多秒
		}
	}
     void OnCollisionEnter(){
		cnt++;
		print (cnt + "p");
	}
}
