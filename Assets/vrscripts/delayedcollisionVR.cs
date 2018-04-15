using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class delayedcollisionVR : MonoBehaviour {
    private AudioSource pp;
    public float time;
    private Rigidbody tp;
    private Vector3 tmp;
    private AudioClip tmpe;
    public AudioClip revert;
    private Transform target;
    private Rigidbody tp1;
    float masschange;
    int cnt;
    AudioSource pp1;
    AudioSource emitter;
    StreamWriter sp;
    //private float timecount=0.0f;
    // Use this for initialization
    void Start()
    {
        cnt = 0;
        pp = GameObject.Find("Object").GetComponent<AudioSource>();
        pp1= GameObject.Find("Subject").GetComponent<AudioSource>();
        target = GameObject.Find("Object").GetComponent<Transform>();
        emitter = GameObject.Find("emitter").GetComponent<AudioSource>();
        tmpe = pp.clip;
        tp = GameObject.Find("Object").GetComponent<Rigidbody>();
        tp1 = GameObject.Find("Subject").GetComponent<Rigidbody>();
        masschange = tp1.mass * 2 / (tp.mass + tp1.mass);
        pp.clip = tmpe;
        emitter.clip = revert;
        sp = File.AppendText("c:/upennVR/RECORD.TXT");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }
    int p = 0;
    void OnCollisionEnter()
    {
        //print (cnt);

        cnt++;
        if (cnt == 1 && p == 0)
        {
            print(cnt);
            pp.volume = Mathf.Clamp01(1 / time * 6f);
            pp.Play();
            tmp = (irregulartargetmoveVR.revervespeed  * masschange *circletrack3d.radius*Time.deltaTime* (target.transform.position - transform.position).normalized);
            tp.velocity = tmp;
            if (VRTK.Examples.UI_Interactions_2.cnt_pinkwhole == 1)
            {
                sp.WriteLine("3d-Irregular shape : The distance is " + circletrack3d.radius * circletrack3d.angle_now * Mathf.PI / 180F + "Meters");
            }
            sp.WriteLine("3d-Irregular shape : Delay Collisioin : " + time + "s delay");
            sp.Close();
            print(tp.velocity.magnitude);
            StartCoroutine(wait());

        }
    }
    IEnumerator wait()
    {
       // pp.Play();
        yield return new WaitForSeconds(time);
        if (p == 0)
        {
            //tp.velocity=Vector3.forward*targetmove.revervespeed;
            //tp.velocity = tmp;
            // pp.Play();
            emitter.Play();
            //pp.Play ();
        }
        p++;
    }

}
