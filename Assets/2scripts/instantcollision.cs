using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantcollision : MonoBehaviour {
	private AudioSource pp;
	public AudioClip csound;
	public AudioClip dsound;
	private Rigidbody tp;
	private Rigidbody tp1;
	private Transform target;
	private Transform cam;
	private GameObject ob;
	float masschange;
	float updis;

	// Use this for initialization
	void Start () {
		pp = GameObject.Find ("Object").GetComponent<AudioSource> ();
		ob = GameObject.Find ("Object");
		tp = GameObject.Find ("Object").GetComponent<Rigidbody> ();
		tp1 = GameObject.Find ("Subject").GetComponent<Rigidbody> ();
		target = GameObject.Find ("Object").GetComponent<Transform> ();
		cam=GameObject.Find ("Main Camera").GetComponent<Transform> ();
		updis = Vector3.Distance (transform.position, cam.position);
		masschange = 2 * tp1.mass / (tp1.mass + tp.mass);
	}

	int cnt=0;
	// Update is called once per frame
	void Update () {
		
	}
	int p=0;
	void OnCollisionEnter(){
		cnt += 1;
		if (cnt == 2&&p==0) {
			pp.clip = csound;
			//pp.volume = 0.3f;
			AudioSource.PlayClipAtPoint(csound,ob.transform.position,Mathf.Clamp01 (Time.deltaTime *targetmove.revervespeed* 2f / updis));
			tp.velocity=(Time.deltaTime* targetmove.revervespeed *circletrack.radius*masschange* (target.transform.position - transform.position).normalized);
			p+=1;
			pp.clip = dsound;
			pp.Play ();
			print (p);
		}
		//pp.clip = dsound;
	}

}
