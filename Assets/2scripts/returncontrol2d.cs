using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Examples;
using UnityEngine.SceneManagement;
using System.IO;
public class returncontrol2d : MonoBehaviour {
    public static int cnt=0;
    public static int cnt_1 = 0;
    public static int cnt_2 = 0;
    public static int pcnt;
    GameObject tp;
    StreamWriter sp;
    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }
    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
    // Use this for initialization
    void Start () {
        tp = GameObject.Find("empty");

        //cnt = counter.pass_cnt;
        // pcnt = counter.pass_pcnt;
        cnt = VRTK.Examples.UI_interaction_set.cnt_red;

    }
	
	// Update is called once per frame
	void Update () {
        /*if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
           
            /*   pcnt++;
               cnt ++;
               print(cnt);
               if(cnt>3)
               {
                   cnt = 1;
               }

               if (pcnt == 3)
               {
                   SceneManager.LoadScene("BUILDER2");
               }
               else
               {
                    switch(cnt)
                   {
                       case 1:  tp.SendMessage("record1", cnt); tp.SendMessage("record2", pcnt); SceneManager.LoadScene("collisionahead"); break;
                       case 2:  tp.SendMessage("record1", cnt); tp.SendMessage("record2", pcnt); SceneManager.LoadScene("collisiondelay"); break;
                       case 3:  tp.SendMessage("record1", cnt); tp.SendMessage("record2", pcnt); SceneManager.LoadScene("collisioninstant"); break;

                   }
               }
               
               SceneManager.LoadScene("BUILDER2");
        }
            */        
    }
}
