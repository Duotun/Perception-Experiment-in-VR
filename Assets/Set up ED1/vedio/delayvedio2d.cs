using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
public class delayvedio2d : MonoBehaviour {
	private AudioSource pp;
	private AudioSource pp1;
	public float time;
	private Rigidbody2D tp;
	private Rigidbody2D tp1;
	private Vector2 tmp;
	public AudioClip tmp1;
	private float relamass;
	public static float recordtime;
	static int vediocnt=0;
	StreamWriter sp;
	int cnt;
	GameObject ob;
	AudioSource emitter;
	float subr;
	GameObject scroll;
	GameObject rating;
	GameObject submit;
	GameObject sub;
	GameObject obj;
	float vary;
	public SteamVR_Camera cam;
	private Transform camtransform;
	private float soundtime;
	//private float timecount=0.0f;
	// Use this for initialization
	private void Awake()
	{

	}
	void Start()
	{
		// print(VRTK.Examples.UI_interaction_set.cnt_pinkonly);
		camtransform = cam.GetComponent<Transform>();
		time = VRTK.Examples.UI_interaction_set.delaytime;
		time *= (float)0.05;
		sub = GameObject.Find("Subject");
		obj = GameObject.Find("Object");
		pp = GameObject.Find("Subject").GetComponent<AudioSource>();
		pp1 = GameObject.Find("Object").GetComponent<AudioSource>();
		/*sp = File.AppendText("c:/upennVR/RECORD.TXT");
		sp.WriteLine("");
		sp.Write("Trial " + VRTK.Examples.UI_interaction_set.cnt_red + " :   ");
		// pp.Stop();
		*/
		if (vediocnt != 0) {
			pp.Play();
		}

		/*if (VRTK.Examples.UI_interaction_set.soundset==2)
		{
			
			//sp.WriteLine("Have rolling sound.");
			//sp.Write("    √        ");

		}
		else
		{
		//	sp.Write("    ×        ");
		}*/
	

		tp = GameObject.Find("Object").GetComponent<Rigidbody2D>();
		tp1 = GameObject.Find("Subject").GetComponent<Rigidbody2D>();
		relamass = 2 * tp1.mass / (tp.mass + tp1.mass);
		subr = GameObject.Find("Subject").GetComponent<CircleCollider2D>().radius;
		subr *= tp1.transform.localScale.magnitude;
		print(subr);
		if (VRTK.Examples.UI_interaction_set.delaytime != 0)
		{
			recordtime = time;
			soundtime = time / 2;
		}
		else
		{
			recordtime = 0f;
			soundtime = 0f;
		}

		ob = GameObject.Find("Object");
		emitter = GameObject.Find("emitter").GetComponent<AudioSource>();
		cnt = 0;
		/*  scroll = GameObject.Find("choose");
        scroll.SetActive(false);
        rating = GameObject.Find("rating");
        rating.SetActive(false);
        submit = GameObject.Find("submit");
        submit.SetActive(false);
        */
	}
	int pcnt = 0;
	// Update is called once per frame
	void FixedUpdate()
	{
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
	private void Update()
	{

	}
	private void locationvary()
	{
		AudioSource.PlayClipAtPoint(tmp1,new Vector3(transform.position.x+0.5f*vary, transform.position.y, transform.position.z));

	}
	void OnCollisionEnter2D()
	{
		//SceneManager.LoadScene("BUILDER2");
		/* if(cnt==1)
         {
             locationvary();
         }*/
		// pp.Stop();
		pp.volume = 0f;
		cnt++;
		// tp.velocity = (tp.transform.position - tp1.transform.position).normalized * targetmove2d.speed*(tp.transform.position-camtransform.position).magnitude* relamass;
		//tp.velocity = Vector2.zero;
		StartCoroutine(movewait());
		// pp.Stop();
		//AudioSource.PlayClipAtPoint(tmp1, tp1.position, 1.0f);
		//tmp = tp.velocity*relamass;
		//tp.velocity = tmp;
		/* if (VRTK.Examples.UI_Interactions_2.cnt_red == 1)
        {
            sp.WriteLine("2d : The distance is " + targetmove2d.distance + "Meters");
        }
        */
		//sp.Write("Delay : " + recordtime + "s.      ");
		// sp.Close();


	}
	private void OnCollisionExit2D(Collision2D collision)
	{
		// StartCoroutine(perfect());

	}
	IEnumerator perfect()
	{
		yield return new WaitForSeconds(1f);
		pp.Stop();
	}
	IEnumerator movewait()
	{
		StartCoroutine(wait());
		yield return new WaitForSeconds(soundtime);
		tp.velocity = (tp.transform.position - tp1.transform.position).normalized * targetmove2d.speed * (tp.transform.position - camtransform.position).magnitude * relamass;
		if (vediocnt!=0)
		{
			pp1.Play();
		}
		StartCoroutine(waitfortherating());
	}
	IEnumerator wait()
	{

		yield return new WaitForSeconds(soundtime);
		//tp.velocity = tmp;
		if (vediocnt != 0)
		{
			emitter.Play();
			//sp.WriteLine("Have collision sound.");
			//sp.Write("     √      ");
		}
		else
		{
			//sp.Write("     ×      ");
		}
		//sp.Close();


	}
	IEnumerator waitfortherating()
	{
		yield return new WaitForSeconds(2f);
		/*sub.SetActive(false);
        obj.SetActive(false);
        scroll.SetActive(true);
        rating.SetActive(true);
        submit.SetActive(true);
        */

		if (vediocnt == 0) {
			vediocnt++;
			SceneManager.LoadScene ("2dvedio");
		}
		else{
		SceneManager.LoadScene("Instruction_2dbegindelay");
		}
	}

}
