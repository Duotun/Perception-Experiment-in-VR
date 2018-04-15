using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class text3 : MonoBehaviour {
    Text ss;
    public static GameObject choose;
    public static GameObject submit;
    public static GameObject rating;
    // Use this for initialization
    void Start () {
        ss = GameObject.Find("yes").GetComponent<Text>();
        
        ss.text = 
            "是红色的小球弹射出了蓝色的小球么？是 / 否";
        choose = GameObject.Find("choose");
        choose.SetActive(false);
        submit = GameObject.Find("SUBMITNOW");
        submit.SetActive(false);
        rating = GameObject.Find("RATING");
        rating.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
