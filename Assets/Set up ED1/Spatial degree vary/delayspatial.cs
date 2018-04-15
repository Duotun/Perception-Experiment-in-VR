﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
public class delayspatial : MonoBehaviour {
	private AudioSource pp;
	private AudioSource subp;
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
	GameObject scroll;
	GameObject rating;
	GameObject submit;
	GameObject sub;
	GameObject obj;
	float vary;
	float recordtime;
	private float soundtime;
	//private float timecount=0.0f;
	// Use this for initialization
	void Start()
	{
		time = VRTK.Examples.UI_interaction_set.delaytime;
		time *= (float)0.05;
		cnt = 0;
		sub = GameObject.Find("Subject");
		obj = GameObject.Find("Object");
		pp = GameObject.Find("Object").GetComponent<AudioSource>();
		subp= GameObject.Find("Subject").GetComponent<AudioSource>();
		target = GameObject.Find("Object").GetComponent<Transform>();
		sp = File.AppendText("c:/upennVR/RECORDspatial.TXT");
		sp.WriteLine("");
		sp.Write("Trial " + VRTK.Examples.UI_interaction_set.cnt_multiple + " :   ");
		if (VRTK.Examples.UI_interaction_set.soundset == 2)
		{
			subp.Play();
			//sp.WriteLine("Have rolling sound.");
			sp.Write("          √        ");
		}
		else
		{
			sp.Write("          ×        ");
		}
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
		if (VRTK.Examples.UI_interaction_set.delaytime != 0)
		{
			recordtime = time;
			soundtime = time / 2;
		}
		else
		{
			recordtime = 0f;
			soundtime = 0;
		}
		/* scroll = GameObject.Find("choose");
         scroll.SetActive(false);
         rating = GameObject.Find("rating");
         rating.SetActive(false);
         submit = GameObject.Find("submit");
         submit.SetActive(false);*/

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
		if (cnt == 2)
		{
			//subb.Rotate(new Vector3(1, 0, 1) * tp.velocity.magnitude / 3.8f);
			// ob.transform.Rotate(rotateaxis * Time.deltaTime * tp.velocity.magnitude / (sphereradius * transform.localScale.magnitude));
			//print(tp.velocity.magnitude);
		}
	}
	int p = 0;
	private void locationvary()
	{
		AudioSource varysource;
		float radius;
		float angle;
		radius = circletrack3d.radius;
		sp.Write ("  "+VRTK.Examples.UI_interaction_set.angleset*20f + "    ");
		if (VRTK.Examples.UI_interaction_set.angleset < 0) {
			angle = Mathf.Abs (VRTK.Examples.UI_interaction_set.angleset) * 20f * Mathf.PI / 180f;
			varysource = GameObject.Instantiate (emitter, new Vector3 (emitter.transform.position.x - radius*Mathf.Sin(angle), emitter.transform.position.y,emitter.transform.position.z*Mathf.Cos(angle)), emitter.transform.rotation) as AudioSource;
			varysource.Play ();
			//sp.Write ("  "+angle + "    ");
		}
		else {
			angle = Mathf.Abs (VRTK.Examples.UI_interaction_set.angleset) * 20f * Mathf.PI / 180f;
			varysource = GameObject.Instantiate (emitter, new Vector3 (emitter.transform.position.x + radius*Mathf.Sin(angle), emitter.transform.position.y, transform.position.z*Mathf.Cos(angle)), emitter.transform.rotation) as AudioSource;
			varysource.Play ();
			//sp.Write ("  "+angle + "    ");
		}


	}
	/* private void OnCollisionExit(Collision collision)
    {
        subp.Stop();
    }
    */
	void OnCollisionEnter()
	{
		//print (cnt);
		cnt++;
		if (cnt == 2 && p == 0)
		{
			//print(cnt);
			//subp.Stop();
			subp.volume = 0f;
			//  pp.clip = revert;
			//  pp.clip = tmpe;
			//pp.volume = Mathf.Clamp01(1 / time * 6f);

			//pp.Play();
			// tp.velocity = Vector3.zero;
			// tmp = (regulartargetmoveVR.revervespeed*Mathf.PI/180f*circletrack3d.radius* masschange * (target.transform.position - transform.position).normalized);
			// tp.velocity = tmp;
//			print(regulartargetmoveVR.revervespeed * Mathf.PI / 180f * circletrack3d.radius * masschange);
//			print(Time.timeSinceLevelLoad);
			// print(tp.velocity.magnitude);
			StartCoroutine(movewait());

			/* if (VRTK.Examples.UI_Interactions_2.cnt_pinkonly == 1)
             {
                 sp.WriteLine("3d-regular shape : The distance is " + circletrack3d.radius * circletrack3d.angle_now * Mathf.PI / 180F + "Meters");
             }
             */
			// sp.WriteLine("3d-regular shape : Delay Collisioin : " + recordtime + "s delay");
			sp.Write("Delay : " + recordtime + "s.      ");
			// sp.WriteLine("3d-regular shape : Delay Collisioin : The radius of balls are" + subb.localScale.magnitude * GameObject.Find("Object").GetComponent<SphereCollider>().radius + " Meters.");


		}
	}
	IEnumerator movewait()
	{
		StartCoroutine(wait());
		yield return new WaitForSeconds(soundtime);
		tmp = (regulartargetmoveVR.revervespeed * Mathf.PI / 180f * circletrack3d.radius * masschange * (target.transform.position - transform.position).normalized);
		tp.velocity = tmp;
		if (VRTK.Examples.UI_interaction_set.soundset == 2)
		{
			pp.Play();
		}
		StartCoroutine(waitfortherating());

	}
	IEnumerator wait()
	{
		// pp.Play();

		yield return new WaitForSeconds(soundtime);
		if (p == 0)
		{
			print(VRTK.Examples.UI_interaction_set.soundset);
			if (VRTK.Examples.UI_interaction_set.soundset != 0)
			{
				//emitter.Play();
				locationvary();
				//sp.WriteLine("Have collision sound.");
				sp.Write("     √      ");
			}
			else
			{   sp.Write("  " + 0 + "    ");
				sp.Write("     ×      ");
			}
			sp.Close();
			//tp.velocity=Vector3.forward*targetmove.revervespeed;
			// tp.velocity = tmp;
			//pp.Play ();
			StartCoroutine( waitfortherating());
		}
		p++;
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
		SceneManager.LoadScene("submit_spatial");
	}

}