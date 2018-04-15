using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class aheadcollisionVR : MonoBehaviour {
    private AudioSource pp;
    private AudioSource pp1;
    public float time;
    private GameObject sub;
    private GameObject ob;
    public AudioClip tt;  //Pengqian
    public AudioClip tt1;  //peng hou
    private BoxCollider subb;
    private float dis;
    float subr;
    float obr;
    private Rigidbody tp;
    private Rigidbody tp1;
    private Transform target;
    private Transform cam;
    float masschange;
    float updis;
    Bounds ap;
    float cnttime;
    AudioSource emitter;
    public float wholetimebeforecollision;
    StreamWriter sp;
    // Use this for initialization
    void Start()
    {
        pp = GameObject.Find("Subject").GetComponent<AudioSource>();
        pp.clip = tt1;
        sub = GameObject.Find("Subject");
        // GetComponent<AudioSource>.
        ob = GameObject.Find("Object");
        emitter = GameObject.Find("emitter").GetComponent<AudioSource>();
        //subb.size.x += time;
        cnttime = time / 0.05f;
        //GameObject.Find("Subject").GetComponent<SphereCollider>().radius +=(cnttime*15f);
       // GameObject.Find("Subject").GetComponent<MeshCollider>().isTrigger = true;
       
        ap = GameObject.Find("Subject").GetComponent<MeshCollider>().bounds;
        subr = ap.size.magnitude/2;
        //print(updis);
        obr = GameObject.Find("Object").GetComponent<SphereCollider>().radius * GameObject.Find("Object").GetComponent<Transform>().localScale.magnitude/2;
        print(obr);
        print(subr);
        pp1 = GameObject.Find("Object").GetComponent<AudioSource>();
        tp = GameObject.Find("Object").GetComponent<Rigidbody>();
        tp1 = GameObject.Find("Subject").GetComponent<Rigidbody>();
        target = GameObject.Find("Object").GetComponent<Transform>();
       // cam = GameObject.Find("Main Camera").GetComponent<Transform>();
        //updis = Vector3.Distance(transform.position, cam.position);
        masschange = 2 * tp1.mass / (tp1.mass + tp.mass);
        //pp1.clip = tt1;
        emitter.clip = tt;
        sp = File.AppendText("c:/upennVR/RECORD.TXT");
        StartCoroutine(wait1());
    }
    IEnumerator wait1()
    {
        yield return new WaitForSeconds(3.652607f- time);
        pp.PlayOneShot(tt, 1.0f);
        print(Time.timeSinceLevelLoad);
    }
    int cnt = 0;
    int pcnt = 0;
    int playshotcnt = 0;
    // Update is called once per frame
    void Update()
    {
        dis = Vector3.Distance(sub.transform.position, ob.transform.position);
        if (tp.velocity.magnitude != 0 && pcnt == 0 )
        {
            pp1.Play();
            pcnt++;
            print(pcnt);
        }
       /* if((wholetimebeforecollision-Time.timeSinceLevelLoad)<=time&&playshotcnt==0)
        {
            // pp.PlayOneShot(tt, 1.0f);
            emitter.Play();
            playshotcnt++;
        }
        */
        // print (dis);
        //print(Mathf.Abs(dis - subr - obr));
        /*if (Mathf.Abs(dis-subr-obr) <= time &&cnt==0)
        {
          
            /*print(irregulartargetmoveVR.revervespeed);
            print(circletrack3d.radius);
            print(Time.deltaTime);
            print(Time.deltaTime * irregulartargetmoveVR.revervespeed * circletrack3d.radius);
            print(Mathf.Abs(dis - subr - obr) / (Time.deltaTime * irregulartargetmoveVR.revervespeed * circletrack3d.radius));
            print(cnt);
            pp.PlayOneShot(tt);
            //AudioSource.PlayClipAtPoint(tt, transform.position,1.0f);
            StartCoroutine (wait ());
            cnt++;
        }
        else
        {
            // pp.volume = 1.0f;
           // pp.clip = tt1;
            /* if(pp.isPlaying==false)
             {
                 pp.Play();
             }
             
        }
    */
       
    }
    int cnt1 = 0;
    int p = 0;
   /* void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Object")
        {
            print("wa");
            pp.PlayOneShot(tt, 1.0f);
            Destroy(GetComponent<SphereCollider>());
            
        }
    }
    */
    void OnCollisionEnter()
    {
        cnt1++;
        print(dis);

        //AudioSource.PlayClipAtPoint(tt, transform.position, 1.0f);
        if (cnt1 == 1 && p == 0)
        {
         
            print(irregulartargetmoveVR.revervespeed);
            print(circletrack3d.radius);
            print(Time.deltaTime);
            print(Time.deltaTime * irregulartargetmoveVR.revervespeed * circletrack3d.radius);
            tp.velocity = (Time.deltaTime * irregulartargetmoveVR.revervespeed * circletrack3d.radius * masschange * (target.transform.position - transform.position).normalized);
            print(tp.velocity.magnitude);
            print(Time.deltaTime * irregulartargetmoveVR.revervespeed * circletrack3d.radius / tp.velocity.magnitude);
            //pp1.Play();
            p++;
            if (VRTK.Examples.UI_Interactions_2.cnt_pinkwhole == 1)
            {
                sp.WriteLine("3d-Irregular shape : The distance is " + circletrack3d.radius * circletrack3d.angle_now*Mathf.PI/180F + "Meters");
            }
            sp.WriteLine("3d-Irregular shape : Ahead Collisioin : " + time + "s in advance");
            sp.Close();
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.1f);
        pp.clip = tt1;
        pp.Play();
    }





}
