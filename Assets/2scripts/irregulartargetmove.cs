using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class irregulartargetmove : MonoBehaviour {
	public Transform target;
	private Transform cam;
	private Rigidbody tp1;
	private Rigidbody tp;
	public float disv;
	private AudioSource tt;
	private AudioClip ty;
	public float speed;
	Vector3 tmp1;
	Vector3 tmp;
	int cnt=0;
	public static float revervespeed;
	float updis;
	float masschange;
	// Use this for initialization
	void Start () {
		cnt = 0;
		revervespeed = speed;
		tp1 = GetComponent<Rigidbody> ();
		tp = GameObject.Find ("Object").GetComponent<Rigidbody> ();
		tt = GameObject.Find ("Subject").GetComponent<AudioSource> ();
		//tt.Play ();
		tt.volume=0.3f;
		print (cnt);
        target = GameObject.Find("Object").GetComponent<Transform>();
        //pp.velocity = new Vector3 (0, 1, 0);
        cam = GameObject.Find ("Main Camera").GetComponent<Transform> ();
		/*tmp1 =target.transform.position-transform.position;
		linerspeed =Quaternion.Euler(0,90,0)*tmp1;
		pp.velocity = linerspeed;
		radius = (transform.position - target.transform.position).magnitude;
		print (radius);
		speed = linerspeed.magnitude;
		omga = speed * speed / radius;
		*/
	}
	
	// Update is called once per frame
	void Update () {
        //timecounter += Time.deltaTime;
        updis = Vector3.Distance(cam.position, transform.position);
        //print(updis);
        //print(Vector3.Distance(cam.position,target.position));
        
	 	//print (radius);
		//pp.AddTorque(new Vector3(0,1,0)*speed);
		if(cnt<=1){
			tmp1 = transform.position - cam.position;
			transform.Rotate (Vector3.forward * speed/7f);
			transform.RotateAround (cam.transform.position, new Vector3 (0, 1, 0), Time.deltaTime * speed);
			updis = Vector3.Distance (transform.position, cam.position);
			//pp.AddForce (tmp1 * Time.deltaTime);
			tt.volume = Mathf.Clamp01 ( speed *1.6f / updis);
			//Quaternion deltarotarion=Quaternion.Euler(euleranglevelocity*Time.deltaTime*3f);
			//pp.MoveRotation (pp.rotation * deltarotarion);
			//timecounter+=Time.deltaTime;

			//print (Vector3.Distance (transform.position,cam.position));
			//Vector3 fp = cam.transform.position-transform.position;
			//fp = fp.normalized * pp.mass * omga;
			/*tmp1 =target.transform.position-transform.position;
			pp.AddForce(tmp1*Time.deltaTime*speed);
			*/
			//tmp = new Vector3(Mathf.Cos(timecounter)*60f,cam.position.y,Mathf.Sin(timecounter));
			//pp.AddTorque(new Vector3(0,0,1));
			//tt.volume=Mathf.Clamp01(pp.angularVelocity.magnitude/speed);
			/*if (pp.velocity.magnitude >= 0) {
				tt.volume = Mathf.Clamp01 (pp.velocity.magnitude / speed);
			}
			*/
			//transform.position = tmp;
			//pp.AddForce (fp,ForceMode.Force);
			if (tt.isPlaying == false) {
				tt.volume = Mathf.Clamp01 (speed*1.6f/updis);
				tt.Play ();
			}
            
			//StartCoroutine (wait());
			//tt.pitch = Mathf.Clamp(pp.velocity.magnitude / speed,0,1);

		}
	}
	void OnCollisionEnter(){
		cnt += 1;
		print (cnt);
		if (cnt == 2) {
			tt.Stop (); 
		}

	}
}
