using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
//ahead  using distance
public class aheadcollision2d : MonoBehaviour {
	private AudioSource pp;
	public float time;
	private GameObject sub;
	private GameObject ob;
    private Rigidbody2D tt;
    private Rigidbody2D tt1;
    private float dis;
    private float relamass;
    public AudioClip tmp;
    private CircleCollider2D p1;
    private CircleCollider2D p2;
    private AudioSource pp1;
    float subr;
    float obr;
    StreamWriter sp;
    public static float  recordtime;
	// Use this for initialization
	void Start () {
		pp = GameObject.Find ("Subject").GetComponent<AudioSource> ();
        pp1 = GameObject.Find("Object").GetComponent<AudioSource>();
		sub = GameObject.Find ("Subject");
		ob = GameObject.Find ("Object");
        tt1 = GameObject.Find("Object").GetComponent<Rigidbody2D>();
        tt = GameObject.Find("Subject").GetComponent<Rigidbody2D>();
        relamass = 2 * tt.mass / (tt.mass + tt1.mass);
        p1 = GameObject.Find("Subject").GetComponent<CircleCollider2D>();
        p2 = GameObject.Find("Object").GetComponent<CircleCollider2D>();
        subr= GameObject.Find("Subject").GetComponent<CircleCollider2D>().radius;
        obr= GameObject.Find("Object").GetComponent<CircleCollider2D>().radius;
        print(subr);
        print(obr);
        sp = File.AppendText("c:/upennVR/RECORD.TXT");
        recordtime = time;
    }
	int cnt=0;
    int pcnt = 0;
    // Update is called once per frame
    void Update () {
		dis = Vector3.Distance (sub.transform.position, ob.transform.position);
        //print(dis);
        print((dis -subr/2 - obr/2));
		if (((dis - subr/2 - obr/2) /targetmove2d.speed)<= time&&cnt==0) {
            //pp.Play ();
            AudioSource.PlayClipAtPoint(tmp, tt.position, 1f);
            print("play");
            cnt++;
		}
        if (tt.velocity.magnitude != 0 && pcnt == 0&&pp.isPlaying==false)
        {
            pp.PlayOneShot(pp.clip,1.0f);
            pcnt++;
        }
    }
    void OnCollisionEnter2D()
    {
        // print("Wa");
        if(VRTK.Examples.UI_Interactions_2.cnt_red==1)
        {
            sp.WriteLine("2d : The distance is " + targetmove2d.distance + "Meters");
        }
        sp.WriteLine("2d: Ahead collision : " + recordtime + "s in advance");
        sp.Close();
        pp1.PlayOneShot(pp1.clip,1.0f);
        tt1.velocity = (ob.transform.position - sub.transform.position).normalized * targetmove2d.speed  * relamass;
        print(tt1.velocity.magnitude);
        //pp.volume = 1f;

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        pp.Stop();
    }

}
