using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle : MonoBehaviour {
	Vector3 linerspeed;
	Vector3 circledot;
	private float radius;
	private Rigidbody body;
	private float speed;
	private float omga;
	private GameObject pp;
	void Start(){
		body = gameObject.GetComponent<Rigidbody> ();
		linerspeed = Quaternion.Euler (0,0, -90) * (circledot - gameObject.transform.position);
		body.velocity = linerspeed;
		pp = GameObject.Find ("Main Camera");
		circledot = pp.transform.position;
		radius = (circledot - gameObject.transform.position).magnitude;
		speed = linerspeed.magnitude;
		omga = speed * speed / radius;
	}
	void Update(){
	}
	void FixedUpdate(){
		Vector3 fp = circledot - gameObject.transform.position;
		print(Vector3.Distance(circledot, gameObject.transform.position));
		fp = fp.normalized * body.mass * omga;
		body.AddForce (fp, ForceMode.Force);
	
	}
}
