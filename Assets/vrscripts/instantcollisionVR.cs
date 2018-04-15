using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class instantcollisionVR : MonoBehaviour {
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
    AudioSource emitter;
    StreamWriter sp;
    // Use this for initialization
    void Start()
    {
        pp = GameObject.Find("Object").GetComponent<AudioSource>();
        ob = GameObject.Find("Object");
        tp = GameObject.Find("Object").GetComponent<Rigidbody>();
        tp1 = GameObject.Find("Subject").GetComponent<Rigidbody>();
        target = GameObject.Find("Object").GetComponent<Transform>();
        emitter = GameObject.Find("emitter").GetComponent<AudioSource>();
        camtransform = cam.GetComponent<Transform>();
        updis = Vector3.Distance(transform.position, camtransform.position);
        masschange = 2 * tp1.mass / (tp1.mass + tp.mass);
        emitter.clip = csound;
        sp = File.AppendText("c:/upennVR/RECORD.TXT");
        // pp.clip = dsound;
    }
    
    int cnt = 0;
    int pcnt = 0;
    // Update is called once per frame
    void Update()
    {
         if(pcnt==0&&tp.velocity.magnitude!=0)
        {
            pp.Play();
            pcnt++;
       }
    }
    int p = 0;
    void OnCollisionEnter()
    {
        cnt += 1;

        if (cnt == 1 && p == 0)
        {
            print("The whole time is"+Time.timeSinceLevelLoad);
           
            tp.velocity = (Time.deltaTime * irregulartargetmoveVR.revervespeed * circletrack3d.radius * masschange * (target.transform.position - transform.position).normalized);
            //pp.clip = csound;
            //pp.volume = 0.3f;
            emitter.Play();
            //.PlayOneShot(csound);  // really works on multiple sounds
            // AudioSource.PlayClipAtPoint(csound, transform.position,1.0f);
            // AudioSource.PlayClipAtPoint(csound, transform.position,1.0f);
            if (VRTK.Examples.UI_Interactions_2.cnt_pinkwhole == 1)
            {
                sp.WriteLine("3d-Irregular shape : The distance is " + circletrack3d.radius * circletrack3d.angle_now * Mathf.PI / 180F + "Meters");
            }
            sp.WriteLine("3d-Irregular shape : Instant Collisioin : ");
            sp.Close();
            print(tp.velocity.magnitude);
          // StartCoroutine( wait());
            print(p);
            p += 1;
        }
        //pp.clip = dsound;
    }
    IEnumerator wait()
    {
        print("wori");
        yield return new WaitForSeconds(0.1f);
         pp.clip = dsound;
         pp.Play();
    }
}
