using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class regulartargetmoveVR : MonoBehaviour {
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
    float sphereradius;
    private Vector3 linearvel;
    private Vector3 currentposition;
    LinkedList<Vector3>  position =new LinkedList<Vector3>();
    Rigidbody subpush;
    float subradius;
    Transform line;
    // Use this for initialization
    void Start()
    {
       
        cnt = 0;
        revervespeed = speed;
        tp1 = GetComponent<Rigidbody>();
        tp = GameObject.Find("Object").GetComponent<Rigidbody>();
        subpush = GameObject.Find("Subject").GetComponent<Rigidbody>();
        tt = GameObject.Find("Subject").GetComponent<AudioSource>();
        camtransform = cam.GetComponent<Transform>();
        updis = Vector3.Distance(camtransform.position, transform.position);
        line = GameObject.Find("line").GetComponent<Transform>();
        //tt.pitch = GetComponent<Rigidbody>().velocity.magnitude / (speed*updis);
        //tt.Play ();
        //tt.volume = 0.8f;
        sphereradius = GetComponent<SphereCollider>().radius;
        subradius = sphereradius * gameObject.transform.localScale.magnitude;
        //print(cnt);
        target = GameObject.Find("Object").GetComponent<Transform>();
        //pp.velocity = new Vector3 (0, 1, 0);

        /*tmp1 =target.transform.position-transform.position;
		linerspeed =Quaternion.Euler(0,90,0)*tmp1;
		pp.velocity = linerspeed;
		radius = (transform.position - target.transform.position).magnitude;
		print (radius);
		speed = linerspeed.magnitude;
		omga = speed * speed / radius;
		*/
        position.AddLast(transform.position);
    }
    Vector3 rotateaxis;
    // Update is called once per frame
    void Update()
    {
        //timecounter += Time.deltaTime;
        updis = Vector3.Distance(camtransform.position, transform.position);
        currentposition = transform.position;
        if(currentposition !=position.Last.Value)
        {
            linearvel = currentposition - position.Last.Value;
        }
        position.AddLast(currentposition);
        /* if(position.Count>10)
         {
             position.RemoveFirst();
         }*/
        //print(updis);

        // print(Vector3.Distance(camtransform.position, target.position));
        //rotateaxis = Vector3.Cross(Vector3.up, linearvel);
       // rotateaxis = Vector3.Normalize(rotateaxis);
        rotateaxis = -(currentposition - circletrack3d.centertransform);
        rotateaxis = Vector3.Normalize(rotateaxis);
        //print (radius);
        //pp.AddTorque(new Vector3(0,1,0)*speed);
        if (cnt <= 1)
        {
            tmp1 = transform.position - camtransform.position;
            //print(rotateaxis);
            // transform.Translate((tp.transform.position - transform.position).normalized*Time.deltaTime*speed );
            // transform.Rotate(rotateaxis, Time.fixedDeltaTime * speed*circletrack3d.radius/ subradius );
            transform.RotateAround(circletrack3d.centertransform, new Vector3(0, 1, 0), Time.fixedDeltaTime * speed);
           // print(speed * Mathf.PI / 180f * circletrack3d.radius);
            //line.RotateAround(circletrack3d.centertransform, new Vector3(0, 1, 0), Time.fixedDeltaTime * speed);
          //  print(circletrack3d.centertransform);
           // subpush.AddTorque(Vector3.up);
            //print(Time.fixedDeltaTime* linearvel.magnitude * 180f / subradius / Mathf.PI);
            updis = Vector3.Distance(transform.position, camtransform.position);
          //  print(updis);
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
           /* if (tt.isPlaying == false)
            {
                //tt.volume = Mathf.Clamp01(speed * 1.6f / updis);
                tt.Play();
            }
            */
            //StartCoroutine (wait());
            //tt.pitch = Mathf.Clamp(pp.velocity.magnitude / speed,0,1);

        }
    }
    void OnCollisionEnter()
    {
        cnt += 1;
        //print(cnt);
      
    }
     void OnCollisionExit()
    {
      
        if (cnt == 2)
        {
            StartCoroutine(wait());
           // tt.Stop();
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(0f);
        //tt.Stop();
    }
}
