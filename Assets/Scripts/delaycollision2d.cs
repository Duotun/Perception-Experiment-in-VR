using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class delaycollision2d : MonoBehaviour {
	private AudioSource pp;
    private AudioSource pp1;
	public float time;
	private Rigidbody2D tp;
    private Rigidbody2D tp1;
	private Vector2 tmp;
    public AudioClip tmp1;
    private float relamass;
    public static float recordtime;
    StreamWriter sp;
    int cnt;
    GameObject ob;
    float subr;
	//private float timecount=0.0f;
	// Use this for initialization
	void Start () {
		pp = GameObject.Find ("Subject").GetComponent<AudioSource> ();
        pp1 = GameObject.Find("Object").GetComponent<AudioSource>();
		tp = GameObject.Find ("Object").GetComponent<Rigidbody2D> ();
        tp1 = GameObject.Find("Subject").GetComponent<Rigidbody2D>();
        subr = GameObject.Find("Subject").GetComponent<CircleCollider2D>().radius;
        relamass = 2 * tp1.mass / (tp.mass + tp1.mass);
        recordtime = time;
        ob = GameObject.Find("Object");
        sp = File.AppendText("c:/upennVR/RECORD.TXT");
        cnt = 0;
    }
    int pcnt = 0;
	// Update is called once per frame
	void FixedUpdate () {
        /* if (tp.velocity.magnitude != 0 && pcnt == 0)
         {
             pp1.Play();
             pcnt++;
         }
         */
      /*  if (cnt == 1)
        {
            ob.transform.Translate((tp.transform.position - tp1.transform.position).normalized * targetmove2d.speed * relamass*Time.deltaTime);
        }
        */
    }
	void OnCollisionEnter2D(){
        pp1.Play();
        cnt++;
        // pp.Stop();
        //AudioSource.PlayClipAtPoint(tmp1, tp1.position, 1.0f);
        //tmp = tp.velocity*relamass;
        //tp.velocity = tmp;
        if (VRTK.Examples.UI_Interactions_2.cnt_red == 1)
        {
            sp.WriteLine("2d : The distance is " + targetmove2d.distance + "Meters");
        }
        sp.WriteLine("2d: Delay collision : " +recordtime + "s delay");
        sp.Close();
        tp.velocity = (tp.transform.position - tp1.transform.position).normalized * targetmove2d.speed * relamass;
        //tp.velocity = Vector2.zero;
        StartCoroutine (wait());

	}
    private void OnCollisionExit2D(Collision2D collision)
    {
       // StartCoroutine(perfect());
        pp.Stop();
    }
    IEnumerator perfect()
    {
        yield return new WaitForSeconds(1f);
        pp.Stop();
    }
    IEnumerator wait(){
     
        yield return new WaitForSeconds (time);
        //tp.velocity = tmp;
        AudioSource.PlayClipAtPoint(tmp1, tp1.position);

    }

} 
