using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circletrack : MonoBehaviour {
	public float r;
	public float sx;
	public float ox;
	private Transform cam;
	private Transform  ob;
	public static float radius;
	void OnAwake(){
	}
	// Use this for initialization
	void Start () {
		cam = GameObject.Find ("Main Camera").GetComponent<Transform>();
		radius = r;
		transform.position=new Vector3(cam.position.x+sx,transform.position.y,cam.position.z+Mathf.Sqrt(r*r-sx*sx));
		print ((transform.position-cam.position).magnitude);
		ob=GameObject.Find("Object").GetComponent<Transform>();
		ob.position = new Vector3 (cam.position.x+ox, ob.position.y, cam.position.z+Mathf.Sqrt (r*r -ox*ox));
        cam.LookAt(this.transform);
		print ((ob.position-cam.position).magnitude);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
