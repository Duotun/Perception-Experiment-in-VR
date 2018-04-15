using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class targetmove2d : MonoBehaviour {
	public GameObject target;
	private Rigidbody2D pp;
    private GameObject steamvr;
	public float disv;
	int cnt=0;
    float times = 0f;
    public static float speed;
    public static float distance;
    float angularvelocity;
	public SteamVR_Camera cam;
	private Transform camtransform;
    //public float screendistance;
	// Use this for initialization
	void Start () {
		pp = GetComponent<Rigidbody2D> ();
        distance = (target.transform.position - transform.position).magnitude;
		camtransform = cam.GetComponent<Transform>();
        angularvelocity = 13.2f*Mathf.PI/180f;
        speed = angularvelocity;
        // steamvr = GameObject.Find("SteamVR");
        //steamvr.transform.position = new Vector3(steamvr.transform.position.x,steamvr.transform.position.y,screendistance);
    }
    // distance is from the z axis !!!
	// Update is called once per frame
	void Update () {
		if (cnt == 0) {
			//pp.AddForce (pp.mass*(target.transform.position - transform.position));
		    
			Vector2 t=(target.transform.position-transform.position).normalized;
			//transform.Translate (t*angularvelocity* disv/Mathf.Cos(13.2f*(Time.timeSinceLevelLoad)*Mathf.PI/180f) * Time.deltaTime);
			transform.Translate(t*angularvelocity*(transform.position-camtransform.position).magnitude* Time.deltaTime);
			//pp.velocity=t*angularvelocity* disv/Mathf.Cos(13.2f*(Time.timeSinceLevelLoad)*Mathf.PI/180f);
            times += Time.deltaTime;

		
           
		} 
        /*if(Time.timeSinceLevelLoad-times>0f)
        {
            times++;6
        }*/

	}

	void OnCollisionEnter2D(){
		    cnt+=1;
		pp.velocity = Vector2.zero;
       // print(Time.timeSinceLevelLoad);
		 //  print(cnt);
	}
}
