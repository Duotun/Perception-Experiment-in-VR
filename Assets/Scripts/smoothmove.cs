using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoothmove : MonoBehaviour {
	GameObject p1;
	Vector2 _target;
	Vector2 _from;
	//private AudioSource pp;
	float movetime=5000f;
	float timecount=0; 
	// Use this for initialization
	void Start () {
		p1 = GameObject.Find ("Object");
		_target = p1.transform.position;
		_from = this.transform.position;
		//pp = GameObject.Find ("Subject").GetComponent<AudioSource> ();
	    
	}
	
	// Update is called once per frame
	void Update () {
		timecount += Time.deltaTime;
		//Vector2.MoveTowards (_from, _target,Time.deltaTime*300f);
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate (Vector2.right * 0.1f);
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Translate (Vector2.up * 0.1f);
		}
	}
	/*void OnCollisionEnter2D(){
		pp.Play ();
	}
*/
}
