using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class irregulartargetmoveVR : MonoBehaviour {

    public Transform target;
    private Rigidbody tp1;
    private Rigidbody tp;
    public float disv;
    private AudioSource tt;
    private AudioClip ty;
    public float speed;
    Vector3 tmp1;
    Vector3 tmp;
    int cnt = 0;
    public static float revervespeed;
    float updis;
    float masschange;
    public SteamVR_Camera cam;
    private Transform camtransform;
    private float obr;
    StreamWriter sp;
    // Use this for initialization
    void Start()
    {
        cnt = 0;
        revervespeed = speed;
        tp1 = GetComponent<Rigidbody>();
        tp = GameObject.Find("Object").GetComponent<Rigidbody>();
        tt = GameObject.Find("Subject").GetComponent<AudioSource>();
        //tt.Play ();
        //tt.volume = 0.8f;
        print(cnt);
        target = GameObject.Find("Object").GetComponent<Transform>();
        //pp.velocity = new Vector3 (0, 1, 0);
        camtransform = cam.GetComponent<Transform>();
        /*tmp1 =target.transform.position-transform.position;
		linerspeed =Quaternion.Euler(0,90,0)*tmp1;
		pp.velocity = linerspeed;
		radius = (transform.position - target.transform.position).magnitude;
		print (radius);
		speed = linerspeed.magnitude;
		omga = speed * speed / radius;
		*/
        obr = GameObject.Find("Object").GetComponent<SphereCollider>().radius;
       
    }
    float cnttime = 0;
    private float subradius;
    private  float obradius;

    // Update is called once per frame
    void Update()
    {
        //timecounter += Time.deltaTime;
        updis = Vector3.Distance(camtransform.position, transform.position);
        //print(updis);
       // print(Vector3.Distance(camtransform.position, target.position));

        //print (radius);
        //pp.AddTorque(new Vector3(0,1,0)*speed);
        if (cnt ==0)
        {
            tmp1 = transform.position - camtransform.position;
            transform.Rotate(new Vector3(0,1,0)* speed / 7f);
            //obradius=
            //subradius = Mathf.Sqrt(transform.lossyScale.x * transform.lossyScale.x + transform.lossyScale.z * transform.lossyScale.z) / 2;
            //obradius = obr * target.lossyScale.magnitude;
           // print(obradius);
           // print(transform.lossyScale.z/2);
           // print(GetComponent<Collider>)
            transform.RotateAround(cam.transform.position, new Vector3(0, 1, 0), Time.deltaTime * speed);
            updis = Vector3.Distance(transform.position, camtransform.position);
            //pp.AddForce (tmp1 * Time.deltaTime);
            //tt.volume = Mathf.Clamp01(speed * 6f / updis);
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
            cnttime += Time.deltaTime;
            if (cnttime >= 0.5f)
            {
                if (tt.isPlaying == false)
                {

                    tt.Play();



                }
            }
        
           
            //StartCoroutine (wait());
            //tt.pitch = Mathf.Clamp(pp.velocity.magnitude / speed,0,1);

        }
    }
    void OnCollisionEnter()
    {
        cnt += 1;
        print(cnt);

    }
    private void OnCollisionExit(Collision collision)
    {
        if (cnt == 1)
        {
            tt.Stop();
        }
    }
}
