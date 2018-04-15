using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHRTF : MonoBehaviour {
	public enum ROOMSIZE{Small,Medium,Large,Nore};
	public ROOMSIZE room = ROOMSIZE.Small; //small 是最平(average)
	public float mingain=-96f;  //minimum gain limit
	public float maxgain=12f;
	public float unityGainDistance=1;
	public float bypassCurve=1; //if>0 will bypass
	AudioSource audiosource;
	void Awake(){
		audiosource = this.gameObject.GetComponent<AudioSource> ();
		if (audiosource == null) {
			print ("SetHERTF needs an audio source to do anything.");
			return;
		}
	
	
		audiosource.spatialize = true; //即调到3D那一块
		audiosource.spread=0;//
		audiosource.spatialBlend=1;
		audiosource.SetSpatializerFloat(1,(float)room); //1 is the room
		audiosource.SetSpatializerFloat(2,mingain);
		audiosource.SetSpatializerFloat (3, maxgain);// 增加效果
		audiosource.SetSpatializerFloat (4, unityGainDistance); //
		audiosource.SetSpatializerFloat (5, bypassCurve);    // 衰减效果
	} 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

