using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circletrack3d : MonoBehaviour {
    public float r;
    public float sx;
    public float ox;
    private Transform ob;
    public static float radius;
    public SteamVR_Camera cam;
    private Transform camtransform;
    float angle_subject;
    float angle_object;
    public static float angle_now;
    public static Vector3 centertransform;
    // Use this for initialization
    void Start () {
        camtransform = cam.GetComponent<Transform>();
        centertransform = camtransform.position;
        print(centertransform);
        radius = r;
        transform.position = new Vector3(camtransform.position.x + sx, transform.position.y, camtransform.position.z + Mathf.Sqrt(r * r - sx * sx));
        camtransform.LookAt(transform.position);
        angle_subject = Mathf.Atan(transform.position.z / transform.position.x);
        //print((transform.position - camtransform.position).magnitude);
        //print(angle_subject);
        Vector3 pp = new Vector3(camtransform.position.x, transform.position.y, camtransform.position.z);
        ob = GameObject.Find("Object").GetComponent<Transform>();
        ob.position = new Vector3(camtransform.position.x + ox, transform.position.y, camtransform.position.z + Mathf.Sqrt(r * r - ox * ox));
        angle_object = Mathf.Atan(ob.position.z / ob.position.x);
        //print(angle_object);
        angle_now = Vector3.Angle(transform.position - pp, ob.transform.position - pp);
        print(angle_now);
        //print(Vector3.Distance(camtransform.position, transform.position));
        //print(Vector3.Distance( ob.position,camtransform.position));
//        print(radius);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
