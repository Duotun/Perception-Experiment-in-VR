using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundtrainingcontrol : MonoBehaviour {
    private float speed;
    private Rigidbody sphere;
    private AudioSource ballsound;
    public AudioClip hitsound;
    float initialdis;
    float nowdis;
    public SteamVR_Camera cam;
    // Use this for initialization
    void Start()
    {
        sphere = this.GetComponent<Rigidbody>();
        sphere.velocity = Vector3.zero;
        ballsound = this.GetComponent<AudioSource>();
        initialdis = Vector3.Distance(cam.transform.position, sphere.position);
    }
    private void FixedUpdate()
    {
        speed = sphere.velocity.magnitude;
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionStay(Collision collision)
    {
        if (ballsound.isPlaying == false && speed >= 0.1f && collision.gameObject.tag == "Collision")
        {
            ballsound.Play();
        }
        else if (ballsound.isPlaying == true && speed < 0.1f && collision.gameObject.tag == "Collision")
        {
            ballsound.Pause();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (ballsound.isPlaying == true && collision.gameObject.tag == "Collision")
        {
            ballsound.Pause();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (ballsound.isPlaying == false && (collision.gameObject.tag == "Collision") && sphere.velocity.magnitude >= 0.3f)
        {
            //print(sphere.velocity.magnitude);
            nowdis = Vector3.Distance(cam.transform.position, sphere.position);
            AudioSource.PlayClipAtPoint(hitsound, transform.position, Mathf.Clamp01(initialdis / nowdis / 10));
        }
        if(collision.gameObject.tag== "Hit" && sphere.velocity.magnitude >= 0.3)
        {
            AudioSource.PlayClipAtPoint(hitsound, transform.position, Mathf.Clamp01(initialdis / nowdis / 10));
        }
    }
}
