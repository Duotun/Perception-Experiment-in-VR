using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ahead  using distance
public class aheadcollision : MonoBehaviour {
	private AudioSource pp;
	private AudioSource pp1;
	public float time;
	private GameObject sub;
	private GameObject ob;
	public AudioClip tt;  //Pengqian
	public AudioClip tt1;  //peng hou
	private float dis;
	float subr;
	float obr;
	private Rigidbody tp;
	private Rigidbody tp1;
	private Transform target;
	private Transform cam;
	float masschange;
	float updis;
	// Use this for initialization
	void Start () {
		pp = GameObject.Find ("Subject").GetComponent<AudioSource> ();
		sub = GameObject.Find ("Subject");
		ob = GameObject.Find ("Object");
		subr = GameObject.Find ("Subject").GetComponent<SphereCollider> ().radius;
		obr = GameObject.Find ("Object").GetComponent<SphereCollider> ().radius;
		pp1 = GameObject.Find ("Object").GetComponent<AudioSource> ();
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
		dis = Vector3.Distance (sub.transform.position, ob.transform.position);
		//print (dis-subr-obr);
		if ((dis-subr-obr) <= time && cnt == 0) {
			print (cnt);
			AudioSource.PlayClipAtPoint (tt,ob.transform.position,Mathf.Clamp01 (targetmove.revervespeed / updis*1.6f));
			//StartCoroutine (wait ());
			cnt++;
		} else {
			pp.clip = tt1;
		}
	}
	int cnt1=0;
	int p=0;
	void OnCollisionEnter(){
		cnt1++;
		if (cnt1 == 2 && p == 0) {
			print (Time.deltaTime * targetmove.revervespeed * circletrack.radius);
			tp.velocity = (Time.deltaTime * targetmove.revervespeed * circletrack.radius * masschange * (target.transform.position - transform.position).normalized);
			print (tp.velocity.magnitude);
			print (Time.deltaTime * targetmove.revervespeed * circletrack.radius / tp.velocity.magnitude);
            pp1.Play();
			p++;
		}
	}
	IEnumerator wait(){
		yield return new WaitForSeconds (0.3f);
		pp.Play ();
	}





}
