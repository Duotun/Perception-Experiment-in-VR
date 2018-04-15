using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class instantcollision2d : MonoBehaviour {
	private AudioSource pp;
    private Rigidbody2D tt;
    private Rigidbody2D tt1;
    private AudioSource pp1;
    private float relamass;
    public AudioClip tmp;
    int cnt = 0;
    StreamWriter sp;
    // Use this for initialization
    void Start () {
		pp = GameObject.Find ("Subject").GetComponent<AudioSource> ();
        pp1 = GameObject.Find("Object").GetComponent<AudioSource>();
        tt1 = GameObject.Find("Object").GetComponent<Rigidbody2D>();
        tt = GameObject.Find("Subject").GetComponent<Rigidbody2D>();
        relamass = 2 * tt.mass / (tt.mass+tt1.mass);
        sp = File.AppendText("c:/upennVR/RECORD.TXT");
    }
    int pcnt = 0;
	// Update is called once per frame
	void Update () {
		if(tt.velocity.magnitude!=0&&pcnt==0)
        {
            pp1.Play();
            pcnt++;
        }
	}
	void OnCollisionEnter2D(){
        //pp.Stop();
        AudioSource.PlayClipAtPoint(tmp, tt.position, 1.0f);
        pp1.Play();
        // tt.velocity = tt.velocity * relamass;
        if (VRTK.Examples.UI_Interactions_2.cnt_red == 1)
        {
            sp.WriteLine("2d : The distance is " + targetmove2d.distance + "Meters");
        }
        sp.WriteLine("2d: Instant collision : ");
        sp.Close();
        tt1.velocity = (tt1.transform.position - tt.transform.position).normalized * targetmove2d.speed * relamass;
        
      //  pp.volume = 1f;
        
	}
    private void OnCollisionExit2D(Collision2D collision)
    {
        pp.Stop();
    }
}
