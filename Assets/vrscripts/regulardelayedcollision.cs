using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class regulardelayedcollision : MonoBehaviour {
    private AudioSource pp;
    public float time;
    private Rigidbody tp;
    private Vector3 tmp;
    private AudioClip tmpe;
    public AudioClip revert;
    private Transform target;
    private Rigidbody tp1;
    Transform subb;
    float masschange;
    int cnt;
    Vector3 rotateaxis;
    float sphereradius;
    public SteamVR_Camera cam;
    private GameObject ob;
    AudioSource emitter;
    StreamWriter sp;
    //private float timecount=0.0f;
    // Use this for initialization
    void Start()
    {
        cnt = 0;
        pp = GameObject.Find("Object").GetComponent<AudioSource>();
        target = GameObject.Find("Object").GetComponent<Transform>();
        tmpe = pp.clip;
        emitter = GameObject.Find("emitter").GetComponent<AudioSource>();
        tp = GameObject.Find("Object").GetComponent<Rigidbody>();
        tp1 = GameObject.Find("Subject").GetComponent<Rigidbody>();
        subb = GameObject.Find("Object").GetComponent<Transform>();
        ob = GameObject.Find("Object");
        masschange = tp1.mass * 2 / (tp.mass + tp1.mass);
        sphereradius = GameObject.Find("Object").GetComponent<SphereCollider>().radius;
        emitter.clip = revert;
        pp.clip = tmpe;
        sp = File.AppendText("c:/upennVR/RECORD.TXT");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rotateaxis = Vector3.Cross(Vector3.up, (cam.transform.position - ob.transform.position));
        /* if(cnt==2&&p==0)
         {
             pp.PlayOneShot(tmpe, 1.0f);
             cnt++;
         }
         */
        //  print(tp.velocity.magnitude);
        if (cnt==2)
        {
            //subb.Rotate(new Vector3(1, 0, 1) * tp.velocity.magnitude / 3.8f);
           // ob.transform.Rotate(rotateaxis * Time.deltaTime * tp.velocity.magnitude / (sphereradius * transform.localScale.magnitude));
            print(tp.velocity.magnitude);
        }
    }
    int p = 0;
    void OnCollisionEnter()
    {
        //print (cnt);
        cnt++;
        if (cnt == 2 && p == 0)
        {
            print(cnt);
          //  pp.clip = revert;
          //  pp.clip = tmpe;
            //pp.volume = Mathf.Clamp01(1 / time * 6f);
            pp.Play();
           // tp.velocity = Vector3.zero;
            tmp = (regulartargetmoveVR.revervespeed  * masschange * (target.transform.position - transform.position).normalized);
            tp.velocity = tmp;
            if(VRTK.Examples.UI_Interactions_2.cnt_pinkonly==1)
            {
                sp.WriteLine("3d-regular shape : The distance is " + circletrack3d.radius * circletrack3d.angle_now*Mathf.PI/180F + "Meters");
            }
            sp.WriteLine("3d-regular shape : Delay Collisioin : " + time + "s delay");
            sp.WriteLine("3d-regular shape : Delay Collisioin : The radius of balls are" + subb.localScale.magnitude * GameObject.Find("Object").GetComponent<SphereCollider>().radius + " Meters.");
            sp.Close();
            StartCoroutine(wait());
        }
    }
    IEnumerator wait()
    {
        // pp.Play();

        yield return new WaitForSeconds(time);
        if (p == 0)
        {
            emitter.Play();
            //tp.velocity=Vector3.forward*targetmove.revervespeed;
           // tp.velocity = tmp;
            //pp.Play ();
        }
        p++;
    }

}
