using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatearound : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public float speed;
	// Update is called once per frame
	void Update () {
		transform.RotateAround (Camera.main.transform.position, new Vector3 (0, 1, 0), speed * Time.deltaTime);
	}
}
