using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetmove : MonoBehaviour {
	public GameObject target;
	private Transform cam;
	private Rigidbody pp;
	private Rigidbody tp;
	public float disv;
	private AudioSource tt;
	private AudioClip ty;
	public float speed;
	Vector3 tmp1;
	Vector3 tmp;
	float timecounter=0;
	int cnt;
	float omga;
	float radius;
	public static float revervespeed;
	Vector3 linerspeed;
	private Rigidbody tp1;
	float masschange;
	// Use this for initialization
	void Start () {
		cnt = 0;
		revervespeed = speed;
		pp = GetComponent<Rigidbody> ();
		tp = GameObject.Find ("Object").GetComponent<Rigidbody> ();
		tp1 = GameObject.Find ("Subject").GetComponent<Rigidbody> ();
		tt = GameObject.Find ("Subject").GetComponent<AudioSource> ();
		masschange = 2 * tp1.mass / (tp1.mass + tp.mass);
		//tt.Play ();
		tt.volume=0.3f;
		print (cnt);
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
	void play()
	{
		tt.Play ();
	}
	float updis;
	// Update is called once per frame
	void Update () {
		timecounter += Time.deltaTime;
		//print (radius);
		//pp.AddTorque(new Vector3(0,1,0)*speed);
		if(cnt<=1){
		tmp1 = transform.position - cam.position;
            transform.Rotate (Vector3.forward,speed*Time.deltaTime*updis);
			transform.RotateAround (cam.transform.position, new Vector3 (0, 1, 0), Time.deltaTime * speed);
		updis = Vector3.Distance (transform.position, cam.position);
		//pp.AddForce (tmp1 * Time.deltaTime);
			tt.volume = Mathf.Clamp01 (  speed  / updis*1.6f);
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
				tt.volume = Mathf.Clamp01 (Time.deltaTime *targetmove.revervespeed* 5f / updis);
			tt.Play ();
		}

		//StartCoroutine (wait());
		//tt.pitch = Mathf.Clamp(pp.velocity.magnitude / speed,0,1);

	}
	}

	/*IEnumerator wait(){
		yield return new WaitForSeconds(1/pp.velocity.magnitude);
		if (cnt <= 1) {
			tt.Play ();
		}
	}
	*/
	// should simulate the collision speed 
	void OnCollisionEnter()
	{   cnt += 1;
		print (cnt);
		if (cnt == 2) {
			tt.Stop ();
			//tp.AddForce (Time.deltaTime* speed *circletrack.radius* (target.transform.position - transform.position));
			//tp.velocity = (Time.deltaTime* speed *circletrack.radius*masschange*(target.transform.position - transform.position));
			//print (tp.velocity.magnitude);
			//tp.velocity = Time.deltaTime * speed*Vector3.forward;
		}
		//pp.velocity = Vector3.zero;
	}
	void OnCollisionStay(){
		if (cnt == 2) {
			//print (circletrack.radius);
			//tp.AddForce (speed *circletrack.radius* Time.deltaTime*(target.transform.position - transform.position));
			//tp.velocity = (Time.deltaTime* speed *circletrack.radius* (target.transform.position - transform.position));
		}
	}

}
