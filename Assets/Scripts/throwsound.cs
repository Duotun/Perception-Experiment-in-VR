using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwsound : MonoBehaviour {
    public AudioClip throwsoundtmp;
    private Rigidbody ball;
    private Transform floor;
    public SteamVR_Camera cam;
    private AudioSource ballsound;
    public AudioClip hitsound;
    float initialdis;
    float nowdis;
    int acnt=1;
    int bcnt=1;
	// Use this for initialization
	void Start () {
        ball =this. GetComponent<Rigidbody>();
        floor = GameObject.Find("Floor").GetComponent<Transform>();
        ballsound = this.GetComponent<AudioSource>();
        initialdis = Vector3.Distance(cam.transform.position, ball.position);
        // print(acnt);
    }
	
	// Update is called once per frame
	void Update () {
		 if(ball.velocity.magnitude>=0f)
        {
            print("wa");
           // ballsound.volume = ball.velocity.magnitude/ Vector3.Distance(transform.position, cam.transform.position);
            print(ballsound.volume);
            ballsound.Play();
            
        }
         else
        { 
            ballsound.Pause();
        }
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (ballsound.isPlaying == false && (collision.gameObject.tag == "Hit" || collision.gameObject.tag == "Collision") && ball.velocity.magnitude >= 0.1f)
        {
            //print(sphere.velocity.magnitude);
            nowdis = Vector3.Distance(cam.transform.position, ball.position);
            AudioSource.PlayClipAtPoint(hitsound, transform.position, Mathf.Clamp01(initialdis / nowdis));
        }
    }

}
