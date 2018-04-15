using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delaycollision : MonoBehaviour {
	private AudioSource pp;
	public float time;
	private Rigidbody tp;
	private Vector3 tmp;
	private AudioClip tmpe;
	public AudioClip revert;
	private Transform target;
	private Rigidbody tp1;
	float masschange;
	int cnt;
	//private float timecount=0.0f;
	// Use this for initialization
	void Start () {
		cnt = 0;
		pp = GameObject.Find ("Object").GetComponent<AudioSource> ();
		target = GameObject.Find ("Object").GetComponent<Transform> ();
		tmpe = pp.clip;
		tp = GameObject.Find ("Object").GetComponent<Rigidbody> ();
		tp1 = GameObject.Find ("Subject").GetComponent<Rigidbody> ();
		masschange = tp1.mass * 2 / (tp.mass + tp1.mass);
	}

	// Update is called once per frame
	void FixedUpdate () {
	}
	int p=0;
	void OnCollisionEnter ()
	{  
		//print (cnt);
		cnt++;
		if(cnt==2&&p==0)
		{
			print (cnt);
			pp.clip = revert;
			pp.volume=Mathf.Clamp01(1/time*6f);
			//tp.velocity = Vector3.zero;
			tmp =(Time.deltaTime* targetmove.revervespeed *circletrack.radius*masschange* (target.transform.position - transform.position).normalized);
            tp.velocity = tmp;
            StartCoroutine (wait ());
		}
	}
	IEnumerator wait(){
		  pp.Play();
		yield return new WaitForSeconds (time);
		if (p == 0) {	
			pp.clip = tmpe;
			//tp.velocity=Vector3.forward*targetmove.revervespeed;
			pp.Play ();
			//pp.Play ();
		}
		p++;
	}

} 
