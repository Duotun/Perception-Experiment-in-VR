using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class reguinstantcollision : MonoBehaviour {
    private AudioSource pp;
    public AudioClip csound;
    public AudioClip dsound;
    private Rigidbody tp;
    private Rigidbody tp1;
    private Transform target;
    private GameObject ob;
    float masschange;
    float updis;
    public SteamVR_Camera cam;
    private Transform camtransform;
    Transform subb;
    Vector3 rotateaxis;
    float sphereradius;
    AudioSource emitter;
    StreamWriter sp;
    float subradius;
    // Use this for initialization
    void Start()
    {
        pp = GameObject.Find("Object").GetComponent<AudioSource>();
        ob = GameObject.Find("Object");
        tp = GameObject.Find("Object").GetComponent<Rigidbody>();
        tp1 = GameObject.Find("Subject").GetComponent<Rigidbody>();
        emitter = GameObject.Find("emitter").GetComponent<AudioSource>();
        target = GameObject.Find("Object").GetComponent<Transform>();
        sphereradius = GameObject.Find("Object").GetComponent<SphereCollider>().radius;
        subradius = sphereradius * ob.transform.localScale.magnitude;
        camtransform = cam.GetComponent<Transform>();
        updis = Vector3.Distance(transform.position, camtransform.position);
        masschange = 2 * tp1.mass / (tp1.mass + tp.mass);
        subb = GameObject.Find("Object").GetComponent<Transform>();
        pp.clip = dsound;
        emitter.clip = csound;
        sp = File.AppendText("c:/upennVR/RECORD.TXT");
    }

    int cnt = 0;
    int pcnt = 0;
    // Update is called once per frame
    void Update()
    {
        print(pcnt);
        rotateaxis = Vector3.Cross(Vector3.up, (cam.transform.position - ob.transform.position));
        if (tp.velocity.magnitude!= 0 && pcnt== 0&&cnt==2)
        {
            // AudioSource.PlayClipAtPoint(dsound, tp.position, 10.0f);
            pp.Play();
            pcnt++;
        }
        if (cnt == 2)
        {
            //subb.transform.Rotate(rotateaxis * Time.deltaTime * tp.velocity.magnitude / (sphereradius * transform.localScale.magnitude));
            print(tp.velocity.magnitude);
        }
    }
    int p = 0;
    void OnCollisionEnter()
    {
        cnt += 1;
        if (cnt == 2 && p == 0)
        {
            emitter.Play();
            //pp.PlayOneShot(dsound);
            //AudioSource.PlayClipAtPoint(csound, tp1.position, 1.0f);
            //tp.velocity = Vector3.zero;
            //pp.volume = 0.3f;

            print(Time.deltaTime * regulartargetmoveVR.revervespeed * circletrack3d.radius);
            // AudioSource.PlayClipAtPoint(csound, transform.position,1.0f);
           // tp.velocity = (regulartargetmoveVR.revervespeed / 180f * circletrack3d.radius * Mathf.PI* (target.transform.position - transform.position).normalized);
            tp.velocity = (regulartargetmoveVR.revervespeed * masschange * (target.transform.position - transform.position).normalized);
            print(tp.velocity.magnitude);
            //StartCoroutine(wait());
            print(p);
            p += 1;
            if (VRTK.Examples.UI_Interactions_2.cnt_pinkonly == 1)
            {

                sp.WriteLine("3d-regular shape : The distance is " + circletrack3d.radius * circletrack3d.angle_now * Mathf.PI / 180F + "Meters");
            }
            sp.WriteLine(circletrack3d.angle_now);
            sp.WriteLine("3d-regular shape : Instant Collisioin : " );
            sp.WriteLine("3d-regular shape : Instant Collisioin : The radius of balls are" + ob.transform.localScale.magnitude * GameObject.Find("Object").GetComponent<SphereCollider>().radius + " Meters.");
            sp.Close();
        }
        //pp.clip = dsound;
    }
    IEnumerator wait()
    {
       // print("wori");
        yield return new WaitForSeconds(0.1f);
        pp.clip = dsound;
        pp.Play();
    }
}
