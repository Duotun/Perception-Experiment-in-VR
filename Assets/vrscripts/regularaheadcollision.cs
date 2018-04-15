using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class regularaheadcollision : MonoBehaviour {
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
    public SteamVR_Camera cam;
    float masschange;
    float updis;
    Vector3 tmp;
    Vector3 rotateaxis;
    float sphereradius;
    AudioSource emitter;
    StreamWriter sp;
    // Use this for initialization
    void Start()
    {
        pp = GameObject.Find("Subject").GetComponent<AudioSource>();
        sub = GameObject.Find("Subject");
        ob = GameObject.Find("Object");
        emitter = GameObject.Find("emitter").GetComponent<AudioSource>();
        subr = GameObject.Find("Subject").GetComponent<SphereCollider>().radius;
        obr = GameObject.Find("Object").GetComponent<SphereCollider>().radius;
        print(obr);
        print(subr);
        sphereradius =GameObject.Find("Object").GetComponent<SphereCollider>().radius;
        //sphereradius = sphereradius * ob.transform.localScale.magnitude;
        pp1 = GameObject.Find("Object").GetComponent<AudioSource>();
        tp = GameObject.Find("Object").GetComponent<Rigidbody>();
        tp1 = GameObject.Find("Subject").GetComponent<Rigidbody>();
        target = GameObject.Find("Object").GetComponent<Transform>();
        // cam = GameObject.Find("Main Camera").GetComponent<Transform>();
        //updis = Vector3.Distance(transform.position, cam.position);
        sp = File.AppendText("c:/upennVR/RECORD.TXT");
        masschange = 2 * tp1.mass / (tp1.mass + tp.mass);
        subr =subr* sub.transform.lossyScale.magnitude/2;
        obr = obr * ob.transform.lossyScale.magnitude / 2;
        print(subr);
        print(obr);
        emitter.clip = tt;

    }
    int cnt = 0;
    int pcnt = 0;
    // Update is called once per frame
    void Update()
    {
        rotateaxis = Vector3.Cross(Vector3.up, (cam.transform.position - ob.transform.position));
        if (tp.velocity.magnitude != 0 && pcnt == 0 &&cnt!=2)
        {
           // pp1.Play();
            pcnt++;
        }
        dis = Vector3.Distance(sub.transform.position, ob.transform.position);
        print(dis);
        //print(subr);
        dis =dis-subr-obr-0.24f;
        
        print(dis / regulartargetmoveVR.revervespeed);
        if ((dis / regulartargetmoveVR.revervespeed) <= time && cnt == 0)
        {
            print(cnt);
            emitter.Play();
            //AudioSource.PlayClipAtPoint(tt, transform.position, 1.0f);
            //StartCoroutine (wait ());
            cnt++;
        }
        else
        {
            pp.clip = tt1;
        }
        if (p != 0)
        {
            // pp1.Play();
           // ob.transform.Rotate(rotateaxis * Time.deltaTime * tp.velocity.magnitude / (sphereradius * transform.localScale.magnitude));
            print(tp.velocity.magnitude);
        }
    }
    int cnt1 = 0;
    int p = 0;
    void OnCollisionEnter()
    {
        cnt1++;

        if (cnt1 == 2 && p == 0)
        {
            pp1.Play();
            print(Time.deltaTime * regulartargetmoveVR.revervespeed * circletrack3d.radius);
            tp.velocity = (regulartargetmoveVR.revervespeed *masschange * (target.transform.position - transform.position).normalized);
            print(tp.velocity.magnitude);
            tmp = tp.velocity;
            print(Time.deltaTime * regulartargetmoveVR.revervespeed * circletrack3d.radius / tp.velocity.magnitude);
            p++;
            if (VRTK.Examples.UI_Interactions_2.cnt_pinkonly == 1)
            {
                sp.WriteLine("3d-regular shape : The distance is " + circletrack3d.radius * circletrack3d.angle_now * Mathf.PI / 180F + "Meters");
            }
            sp.WriteLine("3d-regular shape : Ahead Collisioin : " + time + "s in advance");
            sp.WriteLine("3d-regular shape : Ahead Collisioin : The radius of balls are" + sub.transform.localScale.magnitude * GameObject.Find("Subject").GetComponent<SphereCollider>().radius + " Meters.");
            sp.Close();
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.3f);
        pp.Play();
    }




}
