using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousedrag : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (OnMouseDown ());
	}
	IEnumerator OnMouseDown(){//利用按下鼠标 不停更新 从start开始
		Vector3 sceenspace = Camera.main.WorldToScreenPoint (transform.position);
		//三维坐标到2vector
		Vector3 offset=transform.position-Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,sceenspace.z));
			while(Input.GetMouseButton(0)){
				Vector3 curscreenspace=new Vector3(Input.mousePosition.x,Input
					.mousePosition.y,sceenspace.z);
				Vector3 curposition=Camera.main.ScreenToWorldPoint(curscreenspace)+offset;
				transform.position=curposition;
			}
			yield return new WaitForFixedUpdate();//irate execute
	}
	// Update is called once per frame
	void Update () {
		
	}
}
